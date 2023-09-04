# Introduction 
NSubstitute.Logging is a collection of helper methods that make it easy to inject substitute loggers into an IServiceProvider and verify that specific logging activity occurred. 

# Getting Started fake
First install NSubstitute.Logging into your Test project from the internal nuget server.

## Substitute Logger
Just call `.AddSubstituteLoggers()` on your ServiceCollection before buiding it into an IServiceProvider to add ILoggerFactory, ILogger, and ILogger<T> generated using NSubstitute.

``` csharp
var serviceProvider = new ServiceCollection().AddSubstituteLoggers().BuildServiceProvider();

var mockLoggerFactory = serviceProvider.GetService<ILoggerFactory>();
var mockLogger = serviceProvider.GetService<ILogger>();
var mockLoggerT = serviceProvider.GetService<ILogger<MyClass>>();
```

## Log Verification
NSubstitute.Logging lets you easily assert that specific logging took place. All you need is any [NSubstitute](https://nsubstitute.github.io/) substitute ILogger. 
Then can verify log events by:
- log level
- message template starts with, contains, or exact match
- inclusion of one or more specific keys in the structured log
- event Id
- exception
- any combination of the above in the same log!

NOTE: `CallToLog` methods work with any [NSubstitute Recieved Calls](https://nsubstitute.github.io/help/received-calls/)

### Make sure no warnings or errors were logged while the test was running
``` csharp
var logger = Substitute.For<ILogger>();

logger.LogInformation("I am an informational log.");

logger.CallToLog(LogLevel.Warning)
  .MustNotHaveHappened();

logger.CallToLog(LogLevel.Error)
  .MustNotHaveHappened();
```

### Make sure a specific message was logged
``` csharp
var logger = Substitute.For<ILogger>();

logger.LogInformation("I am an informational log.");

logger.CallToLog(LogLevel.Information, "I am an informational log.")
  .MustHaveHappenedOnceExactly();
```

### Make sure a structured log was created with specific values
``` csharp
var logger = Substitute.For<ILogger>();

logger.LogInformation("the number is {Number}", 42);

logger.CallToLog(LogLevel.Information, _ =>
   _.MessageTemplate.Contains("the number is {Number}")
   && _.KeyEquals("Number", 42)
)
  .MustHaveHappenedOnceExactly();

logger.CallToLog(LogLevel.Information, _ =>
   _.MessageTemplate.Contains("the number is {Number}")
   && _.KeyEquals("Number", 123)
)
  .MustNotHaveHappened();
```

### More Examples
See the tests for more examples!!!