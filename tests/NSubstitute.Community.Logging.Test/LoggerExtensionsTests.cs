using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NSubstitute.Community.Logging.Test
{
    public class LoggerExtensionsTests
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        //------------------------------------------DEBUG------------------------------------------//

        [Fact]
        public void LogDebug_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogDebug(eventId, exception, message, args);
            Target.Received(1)
                .LogDebug(eventId, exception, message);

            Target.DidNotReceive()
                .LogDebug(eventId, message);
            Target.DidNotReceive()
                .LogDebug(exception, message);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogDebug(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogDebug(eventId, exception, message);
            Target.DidNotReceive()
                .LogDebug(eventId, message, args);
            Target.DidNotReceive()
                .LogDebug(eventId, message);
            Target.DidNotReceive()
                .LogDebug(exception, message, args);
            Target.DidNotReceive()
                .LogDebug(exception, message);
            Target.DidNotReceive()
                .LogDebug(message, args);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, eventId, message, args);

            Target.Received(1)
                .LogDebug(eventId, message, args);
            Target.Received(1)
                .LogDebug(eventId, message);

            Target.DidNotReceive()
                .LogDebug(message, args);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, eventId, message, args);

            Target.Received(1)
                .LogDebug(eventId, message, args);

            Target.DidNotReceive()
                .LogDebug(eventId, message);
            Target.DidNotReceive()
                .LogDebug(message, args);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, exception, message, args);

            Target.Received(1)
                .LogDebug(exception, message, args);
            Target.Received(1)
                .LogDebug(exception, message);

            Target.DidNotReceive()
                .LogDebug(message, args);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_exception_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, exception, message, args);

            Target.Received(1)
                .LogDebug(exception, message, args);

            Target.DidNotReceive()
                .LogDebug(exception, message);
            Target.DidNotReceive()
                .LogDebug(message, args);
            Target.DidNotReceive()
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, message, args);

            Target.Received(1)
                .LogDebug(message, args);
            Target.Received(1)
                .LogDebug(message);
        }

        [Fact]
        public void LogDebug_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Target, message, args);

            Target.Received(1)
                .LogDebug(message, args);

            Target.DidNotReceive()
                .LogDebug(message);
        }

        //------------------------------------------TRACE------------------------------------------//

        [Fact]
        public void LogTrace_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogTrace(eventId, exception, message, args);
            Target.Received(1)
                .LogTrace(eventId, exception, message);

            Target.DidNotReceive()
                .LogTrace(eventId, message);
            Target.DidNotReceive()
                .LogTrace(exception, message);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogTrace(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogTrace(eventId, exception, message);
            Target.DidNotReceive()
                .LogTrace(eventId, message, args);
            Target.DidNotReceive()
                .LogTrace(eventId, message);
            Target.DidNotReceive()
                .LogTrace(exception, message, args);
            Target.DidNotReceive()
                .LogTrace(exception, message);
            Target.DidNotReceive()
                .LogTrace(message, args);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, eventId, message, args);

            Target.Received(1)
                .LogTrace(eventId, message, args);
            Target.Received(1)
                .LogTrace(eventId, message);

            Target.DidNotReceive()
                .LogTrace(message, args);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, eventId, message, args);

            Target.Received(1)
                .LogTrace(eventId, message, args);

            Target.DidNotReceive()
                .LogTrace(eventId, message);
            Target.DidNotReceive()
                .LogTrace(message, args);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, exception, message, args);

            Target.Received(1)
                .LogTrace(exception, message, args);
            Target.Received(1)
                .LogTrace(exception, message);

            Target.DidNotReceive()
                .LogTrace(message, args);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_exception_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, exception, message, args);

            Target.Received(1)
                .LogTrace(exception, message, args);

            Target.DidNotReceive()
                .LogTrace(exception, message);
            Target.DidNotReceive()
                .LogTrace(message, args);
            Target.DidNotReceive()
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, message, args);

            Target.Received(1)
                .LogTrace(message, args);
            Target.Received(1)
                .LogTrace(message);
        }

        [Fact]
        public void LogTrace_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Target, message, args);

            Target.Received(1)
                .LogTrace(message, args);

            Target.DidNotReceive()
                .LogTrace(message);
        }

        //------------------------------------------INFORMATION------------------------------------------//

        [Fact]
        public void LogInformation_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogInformation(eventId, exception, message, args);
            Target.Received(1)
                .LogInformation(eventId, exception, message);

            Target.DidNotReceive()
                .LogInformation(eventId, message);
            Target.DidNotReceive()
                .LogInformation(exception, message);
            Target.DidNotReceive()
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogInformation(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogInformation(eventId, exception, message);
            Target.DidNotReceive()
                .LogInformation(eventId, message, args);
            Target.DidNotReceive()
                .LogInformation(eventId, message);
            Target.DidNotReceive()
                .LogInformation(exception, message, args);
            Target.DidNotReceive()
                .LogInformation(exception, message);
            Target.DidNotReceive()
                .LogInformation(message, args);
            Target.DidNotReceive()
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, eventId, message, args);

            Target.Received(1)
                .LogInformation(eventId, message, args);
            Target.Received(1)
                .LogInformation(eventId, message);

            Target.DidNotReceive()
                .LogInformation(message, args);
            Target.DidNotReceive()
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, eventId, message, args);

            Target.Received(1)
                .LogInformation(eventId, message, args);

            Target.DidNotReceive()
                .LogInformation(eventId, message);
            Target.DidNotReceive()
                .LogInformation(message, args);
            Target.DidNotReceive()
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, exception, message, args);

            Target.Received(1)
                .LogInformation(exception, message, args);
            Target.Received(1)
                .LogInformation(exception, message);

            Target.DidNotReceive()
                .LogInformation(message, args);
            Target.DidNotReceive()
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_exception_args()
        {
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
        }

        [Fact]
        public void LogInformation_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, message, args);

            Target.Received(1)
                .LogInformation(message, args);
            Target.Received(1)
                .LogInformation(message);
        }

        [Fact]
        public void LogInformation_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Target, message, args);

            Target.Received(1)
                .LogInformation(message, args);

            Target.DidNotReceive()
                .LogInformation(message);
        }

        //------------------------------------------WARNING------------------------------------------//

        [Fact]
        public void LogWarning_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogWarning(eventId, exception, message, args);
            Target.Received(1)
                .LogWarning(eventId, exception, message);

            Target.DidNotReceive()
                .LogWarning(eventId, message);
            Target.DidNotReceive()
                .LogWarning(exception, message);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogWarning(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogWarning(eventId, exception, message);
            Target.DidNotReceive()
                .LogWarning(eventId, message, args);
            Target.DidNotReceive()
                .LogWarning(eventId, message);
            Target.DidNotReceive()
                .LogWarning(exception, message, args);
            Target.DidNotReceive()
                .LogWarning(exception, message);
            Target.DidNotReceive()
                .LogWarning(message, args);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, eventId, message, args);

            Target.Received(1)
                .LogWarning(eventId, message, args);
            Target.Received(1)
                .LogWarning(eventId, message);

            Target.DidNotReceive()
                .LogWarning(message, args);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, eventId, message, args);

            Target.Received(1)
                .LogWarning(eventId, message, args);

            Target.DidNotReceive()
                .LogWarning(eventId, message);
            Target.DidNotReceive()
                .LogWarning(message, args);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, exception, message, args);

            Target.Received(1)
                .LogWarning(exception, message, args);
            Target.Received(1)
                .LogWarning(exception, message);

            Target.DidNotReceive()
                .LogWarning(message, args);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_exception_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, exception, message, args);

            Target.Received(1)
                .LogWarning(exception, message, args);

            Target.DidNotReceive()
                .LogWarning(exception, message);
            Target.DidNotReceive()
                .LogWarning(message, args);
            Target.DidNotReceive()
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, message, args);

            Target.Received(1)
                .LogWarning(message, args);
            Target.Received(1)
                .LogWarning(message);
        }

        [Fact]
        public void LogWarning_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, message, args);

            Target.Received(1)
                .LogWarning(message, args);

            Target.DidNotReceive()
                .LogWarning(message);
        }

        //------------------------------------------ERROR------------------------------------------//

        [Fact]
        public void LogError_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogError(eventId, exception, message, args);
            Target.Received(1)
                .LogError(eventId, exception, message);

            Target.DidNotReceive()
                .LogError(eventId, message);
            Target.DidNotReceive()
                .LogError(exception, message);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogError(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogError(eventId, exception, message);
            Target.DidNotReceive()
                .LogError(eventId, message, args);
            Target.DidNotReceive()
                .LogError(eventId, message);
            Target.DidNotReceive()
                .LogError(exception, message, args);
            Target.DidNotReceive()
                .LogError(exception, message);
            Target.DidNotReceive()
                .LogError(message, args);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, eventId, message, args);

            Target.Received(1)
                .LogError(eventId, message, args);
            Target.Received(1)
                .LogError(eventId, message);

            Target.DidNotReceive()
                .LogError(message, args);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, eventId, message, args);

            Target.Received(1)
                .LogError(eventId, message, args);

            Target.DidNotReceive()
                .LogError(eventId, message);
            Target.DidNotReceive()
                .LogError(message, args);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, exception, message, args);

            Target.Received(1)
                .LogError(exception, message, args);
            Target.Received(1)
                .LogError(exception, message);

            Target.DidNotReceive()
                .LogError(message, args);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_exception_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, exception, message, args);

            Target.Received(1)
                .LogError(exception, message, args);

            Target.DidNotReceive()
                .LogError(exception, message);
            Target.DidNotReceive()
                .LogError(message, args);
            Target.DidNotReceive()
                .LogError(message);
        }

        [Fact]
        public void LogError_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, message, args);

            Target.Received(1)
                .LogError(message, args);
            Target.Received(1)
                .LogError(message);
        }

        [Fact]
        public void LogError_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogError(Target, message, args);

            Target.Received(1)
                .LogError(message, args);

            Target.DidNotReceive()
                .LogError(message);
        }

        //------------------------------------------CRITICAL------------------------------------------//

        [Fact]
        public void LogCritical_with_eventId_exception_no_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogCritical(eventId, exception, message, args);
            Target.Received(1)
                .LogCritical(eventId, exception, message);

            Target.DidNotReceive()
                .LogCritical(eventId, message);
            Target.DidNotReceive()
                .LogCritical(exception, message);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_eventId_exception_args()
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, eventId, exception, message, args);

            Target.Received(1)
                .LogCritical(eventId, exception, message, args);

            Target.DidNotReceive()
                .LogCritical(eventId, exception, message);
            Target.DidNotReceive()
                .LogCritical(eventId, message, args);
            Target.DidNotReceive()
                .LogCritical(eventId, message);
            Target.DidNotReceive()
                .LogCritical(exception, message, args);
            Target.DidNotReceive()
                .LogCritical(exception, message);
            Target.DidNotReceive()
                .LogCritical(message, args);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_eventId_no_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, eventId, message, args);

            Target.Received(1)
                .LogCritical(eventId, message, args);
            Target.Received(1)
                .LogCritical(eventId, message);

            Target.DidNotReceive()
                .LogCritical(message, args);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_eventId_args()
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, eventId, message, args);

            Target.Received(1)
                .LogCritical(eventId, message, args);

            Target.DidNotReceive()
                .LogCritical(eventId, message);
            Target.DidNotReceive()
                .LogCritical(message, args);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_exception_no_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, exception, message, args);

            Target.Received(1)
                .LogCritical(exception, message, args);
            Target.Received(1)
                .LogCritical(exception, message);

            Target.DidNotReceive()
                .LogCritical(message, args);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_exception_args()
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, exception, message, args);

            Target.Received(1)
                .LogCritical(exception, message, args);

            Target.DidNotReceive()
                .LogCritical(exception, message);
            Target.DidNotReceive()
                .LogCritical(message, args);
            Target.DidNotReceive()
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_no_args()
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, message, args);

            Target.Received(1)
                .LogCritical(message, args);
            Target.Received(1)
                .LogCritical(message);
        }

        [Fact]
        public void LogCritical_with_args()
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Target, message, args);

            Target.Received(1)
                .LogCritical(message, args);

            Target.DidNotReceive()
                .LogCritical(message);
        }

        //------------------------------------------LogLevel------------------------------------------//

        public static IEnumerable<object[]> AllLogLevels => GetAllLogLevels().Select(s => new object[] { s });
        public static IEnumerable<LogLevel> GetAllLogLevels()
        {
            yield return LogLevel.Trace;
            yield return LogLevel.Debug;
            yield return LogLevel.Information;
            yield return LogLevel.Warning;
            yield return LogLevel.Error;
            yield return LogLevel.Critical;
            yield return LogLevel.None;
            yield return (LogLevel)42;
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_eventId_exception_no_args(LogLevel logLevel)
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, eventId, exception, message, args);

            Target.Received(1)
                .Log(logLevel, eventId, exception, message, args);
            Target.Received(1)
                .Log(logLevel, eventId, exception, message);

            Target.DidNotReceive()
                .Log(logLevel, eventId, message);
            Target.DidNotReceive()
                .Log(logLevel, exception, message);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_eventId_exception_args(LogLevel logLevel)
        {
            var eventId = new EventId(404, "not found");
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, eventId, exception, message, args);

            Target.Received(1)
                .Log(logLevel, eventId, exception, message, args);

            Target.DidNotReceive()
                .Log(logLevel, eventId, exception, message);
            Target.DidNotReceive()
                .Log(logLevel, eventId, message, args);
            Target.DidNotReceive()
                .Log(logLevel, eventId, message);
            Target.DidNotReceive()
                .Log(logLevel, exception, message, args);
            Target.DidNotReceive()
                .Log(logLevel, exception, message);
            Target.DidNotReceive()
                .Log(logLevel, message, args);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_eventId_no_args(LogLevel logLevel)
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, eventId, message, args);

            Target.Received(1)
                .Log(logLevel, eventId, message, args);
            Target.Received(1)
                .Log(logLevel, eventId, message);

            Target.DidNotReceive()
                .Log(logLevel, message, args);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_eventId_args(LogLevel logLevel)
        {
            var eventId = new EventId(404, "not found");
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, eventId, message, args);

            Target.Received(1)
                .Log(logLevel, eventId, message, args);

            Target.DidNotReceive()
                .Log(logLevel, eventId, message);
            Target.DidNotReceive()
                .Log(logLevel, message, args);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_exception_no_args(LogLevel logLevel)
        {
            var exception = new KeyNotFoundException();
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, exception, message, args);

            Target.Received(1)
                .Log(logLevel, exception, message, args);
            Target.Received(1)
                .Log(logLevel, exception, message);

            Target.DidNotReceive()
                .Log(logLevel, message, args);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_exception_args(LogLevel logLevel)
        {
            var exception = new KeyNotFoundException();
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, exception, message, args);

            Target.Received(1)
                .Log(logLevel, exception, message, args);

            Target.DidNotReceive()
                .Log(logLevel, exception, message);
            Target.DidNotReceive()
                .Log(logLevel, message, args);
            Target.DidNotReceive()
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_no_args(LogLevel logLevel)
        {
            var message = "This is a log message";
            var args = new object[0];
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, message, args);

            Target.Received(1)
                .Log(logLevel, message, args);
            Target.Received(1)
                .Log(logLevel, message);
        }

        [Theory]
        [MemberData(nameof(AllLogLevels))]
        public void Log_with_args(LogLevel logLevel)
        {
            var message = "This is a {log} message";
            var args = new object[] { "log" };
            Microsoft.Extensions.Logging.LoggerExtensions.Log(Target, logLevel, message, args);

            Target.Received(1)
                .Log(logLevel, message, args);

            Target.DidNotReceive()
                .Log(logLevel, message);
        }
    }
}
