using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace NSubstitute.Community.Logging.Test
{
    public class CallToLogTests
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        [Fact]
        public void CallToLog_RequiresLogger()
        {
            ILogger target = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                target.CallToLog(LogLevel.Warning);
            });

            Assert.Contains("logger", ex.Message);
        }

        [Fact]
        public void CallToLog_RequiresLogger_predicate()
        {
            ILogger target = null;

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                target.CallToLog(LogLevel.Warning, _ => _.OriginalFormat.Equals("smith"));
            });

            Assert.Contains("logger", ex.Message);
        }

        [Fact]
        public void CallToLog_LogLevel_Only()
        {
            var now = DateTime.Now;
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "there were {oopies} things you might want to know about. {where} {when}", 13, "earth", now);
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, "whatever, one more");

            // matches any warning
            Target.Received(2)
                .CallToLog(LogLevel.Warning);

            // matches any warning with this message
            Target.Received(1)
                .CallToLog(LogLevel.Warning, "whatever, one more");

            // matches any information
            Target.DidNotReceive()
                .CallToLog(LogLevel.Information);
        }

        [Fact]
        public void CallToLog_LogLevel_Exception()
        {
            var ex = new Exception();
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, ex, "something bad happened");
            var ex2 = new InvalidOperationException("don't do that");
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, ex2, "There was another error.");

            // matches any error with this exception
            Target.Received(1)
                .CallToLog(LogLevel.Error, ex);

            // any error with this message
            Target.Received(1)
                .CallToLog(LogLevel.Error, "something bad happened");

            // any error with this exception and message
            Target.Received(1)
                .CallToLog(LogLevel.Error, ex, "something bad happened");

            var otherEx = new Exception();
            Target.DidNotReceive()
                .CallToLog(LogLevel.Error, otherEx);
        }

        [Fact]
        public void BeginScope_State()
        {
            using var scope = Target.BeginScope<IReadOnlyCollection<KeyValuePair<string, object>>>(new Dictionary<string, object> {
                { "UserId", 123456 },
                { "UserEmail","Mike@example.com" },
                { "Address","login.example.com" },
            });

            // this exact BeginScope call happened
            Target.Received(1)
                .CallToBeginScope(_ => _.KeyEquals("UserId", 123456)
                    && _.KeyEquals("UserEmail", "Mike@example.com")
                    && _.KeyEquals("Address", "login.example.com")
            );
        }
    }
}
