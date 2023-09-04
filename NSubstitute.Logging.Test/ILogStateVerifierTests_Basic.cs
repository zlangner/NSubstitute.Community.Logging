using System;
using Microsoft.Extensions.Logging;
using Xunit;

namespace NSubstitute.Logging.Test
{
    [Trait("Category", "Unit")]
    public class ILogStateVerifierTests_Basic
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        [Fact]
        public void MessageTemplateReturnedIsSameReferenceAsWhatWasLogged()
        {
            var template = "This is a log message";
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, template);

            Target.Received(1)
                .CallToLog(LogLevel.Trace, _ => object.ReferenceEquals(_.MessageTemplate, template));

            Target.Received(1)
                .CallToLog(LogLevel.Trace, _ => _.MessageTemplate.Equals(template));
        }

        [Fact]
        public void ExceptionReturnedIsSameReferenceAsWhatWasLogged()
        {
            var ex = new InvalidOperationException("don't do that");
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, ex, "There was an error.");

            Target.Received(1)
                .CallToLog(LogLevel.Warning, ex);
        }

        [Fact]
        public void CanPerformExactMatchOnMessageTemplate()
        {
            var ex = new InvalidOperationException($"Error Code {Guid.NewGuid()}: blah blah detail");
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, ex, "There was an error.");

            Target.Received(1)
                .CallToLog(LogLevel.Warning, "There was an error.");
            Target.Received(1)
                .CallToLog(LogLevel.Warning, Arg.Is("There was an error."));
        }

        [Fact]
        public void CanPerformContainsCheckOnMessageTemplate()
        {
            var ex = new InvalidOperationException($"Error Code {Guid.NewGuid()}: blah blah detail");
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, ex, "There was an error.");

            Target.Received(1)
                .CallToLog(LogLevel.Warning, Arg.Is<string>(_ => _.Contains("was an")));
        }

        [Fact]
        public void SimpleCallToLogRequiresLogger()
        {
            ILogger target = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                target.CallToLog(LogLevel.Warning);
            });

            Assert.Contains("logger", ex.Message);
        }

        [Fact]
        public void ComplexCallToLogRequiresLogger()
        {
            ILogger target = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                target.CallToLog(LogLevel.Warning, _ => _.MessageTemplate.Equals("smith"));
            });

            Assert.Contains("logger", ex.Message);
        }
    }
}
