using System;
using Microsoft.Extensions.Logging;
using Xunit;

namespace NSubstitute.Logging.Test
{
    [Trait("Category", "Unit")]
    public class ILoggerVerificationExtensionsTests_CallToLog
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        [Fact]
        public void JustByLogType()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "whatever, one more");

            Target.Received(2)
                .CallToLog(LogLevel.Warning); // any warning

            // no information
            Target.DidNotReceive()
                .CallToLog(LogLevel.Information);
        }

        [Fact]
        public void ByLogTypeAndException()
        {
            var ex = new Exception();
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, ex, "something bad happened");

            Target.Received()
                .CallToLog(LogLevel.Error, ex); // any error with this exception

            Target.Received(1)
                .CallToLog(LogLevel.Error, "something bad happened"); // any error with this message template

            Target.Received(1)
                .CallToLog(LogLevel.Error, ex, "something bad happened"); // this error and this message template

            var otherEx = new Exception();
            Target.DidNotReceive()
                .CallToLog(LogLevel.Error, otherEx);
        }

        [Fact]
        public void BasicStructuredLogging_Warning()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);

            // this verifies the message template
            Target.Received(1)
                .CallToLog(LogLevel.Warning,
                _ => _.MessageTemplate.Equals("there were {oopies} things you might want to know about. {where} {when}")
                    && _.KeyEquals("oopies", 13)
                    && _.KeyEquals("where", "earth")
                    && _.KeyEquals("when", now)
                );
        }

        [Fact]
        public void CannotFindLogsThatDidNotHappen()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, "Application {AppName} could not load {When}", "Web 2.0", now);

            // sanity check, make sure the message template didn't change
            Target.Received(1)
                .CallToLog(LogLevel.Critical, _ => _.MessageTemplate.Equals("Application {AppName} could not load {When}"));

            // Assert
            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("When", now.Add(TimeSpan.FromTicks(1))));

            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("when", now));

            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("Dog", 2));
        }

        [Fact]
        public void KeyCaseMattersToKeyEquals()
        {
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, "the number is {Number}", 42);

            // this verifies the value is seen
            Target.Received(1)
                .CallToLog(LogLevel.Information, _ => _.KeyEquals("Number", 42));

            // this verifies the value is seen
            Target.DidNotReceive()
                .CallToLog(LogLevel.Information, _ => _.KeyEquals("number", 42));

            // this verifies the value is seen
            Target.DidNotReceive()
                .CallToLog(LogLevel.Information, _ => _.KeyEquals("Number", 24));
        }

    }
}
