using Example.Test.Internals;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using Xunit;

namespace Example.Test
{
    // import inside namespace so these extension methods are used over Microsoft.Extensions.Logging
    using NSubstitute.Community.Logging;

    /// <summary>
    /// These tests show what it would look like when geting log calls made by a class that uses Microsoft.Extensions.Logging
    /// </summary>
    public class DoLoggingTests
    {
        private readonly ILogger<DoLogging> _logger;
        private readonly DoLogging Target;

        public DoLoggingTests()
        {
            _logger = Substitute.For<ILogger<DoLogging>>();
            Target = new DoLogging(_logger);
        }

        [Fact]
        public void Add_calls_LogTrace()
        {
            var a = 13;
            var b = -7;
            var expectedResult = a + b;

            var result = Target.Add(a, b);

            Assert.Equal(expectedResult, result);

            // a LogTrace happened with the expected message template
            _logger.Received(1)
                .CallToLog(LogLevel.Trace, "{a} + {b} = {c}");

            // the LogTrace happened exactly as expected
            _logger.Received(1)
                .LogTrace("{a} + {b} = {c}", a, b, expectedResult);

            // no errors or warnings were logged
            _logger.DidNotReceive()
                .CallToLog(LogLevel.Error);
            _logger.DidNotReceive()
                .CallToLog(LogLevel.Warning);
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

            // the LogError happened exactly as expected
            _logger.Received(1)
                .LogError(thrownEx, "Error encountered in {MethodName} and rethrown.", "Throw");
        }
    }
}
