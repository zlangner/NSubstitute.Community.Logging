using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xunit;

namespace NSubstitute.Community.Logging.Test
{
    public class CallToLogPredicateTests
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        [Fact]
        public void CallToLog_ILogStateVerifier_exact_predicate()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);

            // this verifies the log matches exactly
            Target.Received(1)
                .CallToLog(LogLevel.Warning,
                _ => _.OriginalFormat.Equals("there were {oopies} things you might want to know about. {where} {when}")
                    && _.KeyEquals("oopies", 13)
                    && _.KeyEquals("where", "earth")
                    && _.KeyEquals("when", now)
                );
        }

        [Fact]
        public void CallToLog_ILogStateVerifier_general_predicate()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);
            var planets = new[] { "mars", "earth" };

            // this verifies the log matches generally
            Target.Received(1)
                .CallToLog(LogLevel.Warning,
                _ => _.OriginalFormat.StartsWith("there were {oopies}")
                    && _.TryGetValue("oopies", out int oopies) && oopies > 10
                    && _.TryGetValue("where", out string where) && planets.Contains(where)
                    && _.TryGetValue("when", out DateTime when) && when <= DateTime.Now
                );
        }

        [Fact]
        public void CallToLog_ILogStateVerifier_negative_predicate()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, "Application {AppName} could not load {When}", "Web 2.0", now);

            // sanity check, make sure the message template didn't change
            Target.Received(1)
                .CallToLog(LogLevel.Critical, "Application {AppName} could not load {When}");

            // Assert
            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("When", now.Add(TimeSpan.FromTicks(1))));

            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("when", now));

            Target.DidNotReceive()
                .CallToLog(LogLevel.Critical, _ => _.KeyEquals("Dog", 2));
        }

        [Fact]
        public void CallToLog_ILogStateVerifier_KeyEquals_Key_Case_Matters()
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

        [Fact]
        public void CallToLog_ILogStateVerifier_OriginalFormat_Is_Same_Reference()
        {
            var template = "This is a log message";
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, template);

            Target.Received(1)
                .CallToLog(LogLevel.Trace, _ => object.ReferenceEquals(_.OriginalFormat, template));

            Target.Received(1)
                .CallToLog(LogLevel.Trace, _ => _.OriginalFormat.Equals(template));

            Target.Received(1)
                .CallToLog(LogLevel.Trace, template);
        }
    }
}
