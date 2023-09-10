using Logging.Test.Internals;
using System;
using Xunit;

namespace NSubstitute.Community.Logging.Test
{
    /// <summary>
    /// These tests show what it would look like when geting log calls made by a class that uses Microsoft.Extensions.Logging
    /// </summary>
    public class DoScopedLoggingTests
    {
        private readonly Microsoft.Extensions.Logging.ILogger<DoScopedLogging> _logger;
        private readonly DoScopedLogging Target;

        public DoScopedLoggingTests()
        {
            _logger = Substitute.For<Microsoft.Extensions.Logging.ILogger<DoScopedLogging>>();
            Target = new DoScopedLogging(_logger);
        }

        [Fact]
        public void Add_calls_LogTrace()
        {
            var a = 13;
            var b = -7;
            var expectedResult = a + b;

            var result = Target.Add(a, b);

            Assert.Equal(expectedResult, result);

            // a scope was started
            _logger.Received(1)
                .BeginScope("Enter {MethodName} {param1} {param2} {param3}", "Add", 1, 2, 3);

            // a LogTrace happened with the expected message template
            _logger.Received(1)
                .CallToLog(Microsoft.Extensions.Logging.LogLevel.Trace, "{a} + {b} = {c}");

            // the LogTrace happened exactly as expected
            _logger.Received(1)
                .LogTrace("{a} + {b} = {c}", a, b, expectedResult);

            // no errors or warnings were logged
            _logger.DidNotReceive()
                .CallToLog(Microsoft.Extensions.Logging.LogLevel.Error);
            _logger.DidNotReceive()
                .CallToLog(Microsoft.Extensions.Logging.LogLevel.Warning);
        }

        [Fact]
        public void Throw_calls_LogError()
        {
            var thrownEx = Assert.Throws<NotSupportedException>(() =>
            {
                Target.Throw();
            });

            Assert.NotNull(thrownEx);
            Assert.Equal("Don't do that", thrownEx.Message);

            // a scope was started
            _logger.Received(1)
                .BeginScope("Enter {MethodName} {param1} {param2} {param3}", "Throw", 1, 2, 3);

            // the LogError happened exactly as expected
            _logger.Received(1)
                .LogError(thrownEx, "Error encountered in {MethodName} and rethrown.", "Throw");
        }
    }
}
