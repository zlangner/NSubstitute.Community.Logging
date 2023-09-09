# Introduction 
NSubstitute.Community.Logging is a collection of helper methods that make it easy to inject substitute loggers into an IServiceProvider and verify that specific logging activity occurred. 

# Getting Started fake
First install NSubstitute.Community.Logging into your Test project from the internal nuget server.

## Substitute Logger
Just call `.AddSubstituteLoggers()` on your ServiceCollection before buiding it into an IServiceProvider to add ILoggerFactory, ILogger, and ILogger<T> generated using NSubstitute.

``` csharp
var serviceProvider = new ServiceCollection().AddSubstituteLoggers().BuildServiceProvider();

var mockLoggerFactory = serviceProvider.GetService<ILoggerFactory>();
var mockLogger = serviceProvider.GetService<ILogger>();
var mockLoggerT = serviceProvider.GetService<ILogger<MyClass>>();
```

## Log Verification: Basic
NSubstitute.Community.Logging lets you easily assert that specific logging took place. All you need is any [NSubstitute](https://nsubstitute.github.io/) substitute ILogger.
Then you can verify logs using syntax similar to how the application wrote them.
See [LoggerExtensionsTests](https://github.com/zlangner/NSubstitute.Community.Logging/blob/main/NSubstitute.Community.Logging.Test/LoggerExtensionsTests.cs) for more examples.

### Make sure specific LogInformation call occured
``` csharp
var Target = Substitute.For<ILogger>();
var exception = new KeyNotFoundException();
var message = "This is a {log} message";
var args = new object[] { "log" };
Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, exception, message, args);

Target.Received(1)
    .LogInformation(exception, message, args);

Target.DidNotReceive()
    .LogInformation(exception, message);
Target.DidNotReceive()
    .LogInformation(message, args);
Target.DidNotReceive()
    .LogInformation(message);
```

## Log Verification: Advanced
Sometimes you don't want to or can't match on every nuance of a log message. For these cases there is `CallToLog` which behaves like `Arg.Is`
for any provided argument and behaves like `Arg.Any` for omitted arguments. This allows you to verify log events by:
- log level
- OriginalFormat
- event Id
- exception
- any combination of the above in the same log!

NOTE: `CallToLog` methods work with any [NSubstitute Recieved Calls](https://nsubstitute.github.io/help/received-calls/)

### Make sure no warnings or errors were logged while the test was running
``` csharp
var Target = Substitute.For<ILogger>();
Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, "I am an informational log.");

Target.DidNotReceive()
    .CallToLog(LogLevel.Warning);

Target.DidNotReceive()
    .CallToLog(LogLevel.Error);
```

### Make sure a similar message was logged
``` csharp
var Target = Substitute.For<ILogger>();
Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, "I am an informational log.");

Target.Received(1)
    .CallToLog(LogLevel.Information, "I am an informational log.");
```

## Log Verification: Custom Logic
Somes you want to verify the value of arguments provided to a Log but cannot match all the arguments or cannot match the exact value that was used.
See [CallToLogPredicateTests](https://github.com/zlangner/NSubstitute.Community.Logging/blob/main/NSubstitute.Community.Logging.Test/CallToLogPredicateTests.cs) for more examples.

### Match the message and some arguments exactly
``` csharp
var Target = Substitute.For<ILogger>();
Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "{ErrorCode} There were {ErrorCount} errors that happened on {Where}.", Guid.NewGuid(), 13, "earth");

Target.Received(1)
    .CallToLog(LogLevel.Warning,
    _ => _.OriginalFormat.Equals("{ErrorCode} There were {ErrorCount} errors that happened on {Where}.")
        && _.KeyEquals("ErrorCount", 13)
        && _.KeyEquals("Where", "earth")
    );
```

### Match the message and arguments more generally
``` csharp
var Target = Substitute.For<ILogger>();
var now = DateTime.Now;
Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);
var planets = new[] { "mars", "earth" };

Target.Received(1)
    .CallToLog(LogLevel.Warning,
    _ => _.OriginalFormat.StartsWith("there were {oopies}")
        && _.TryGetValue("oopies", out int oopies) && oopies > 10
        && _.TryGetValue("where", out string where) && planets.Contains(where)
        && _.TryGetValue("when", out DateTime when) && when <= DateTime.Now
    );
```

## More Examples
See the tests for more examples!!!