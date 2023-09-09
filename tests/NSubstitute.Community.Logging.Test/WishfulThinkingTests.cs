using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace NSubstitute.Community.Logging.Test
{
    /// <summary>
    /// It would be nice to use Arg with the .CallToLog and LoggerExtension methods but they don't work so confirm they keep not working
    /// </summary>
    public class WishfulThinkingTests
    {
        private readonly ILogger Target = Substitute.For<ILogger>();

        [Fact]
        public void CallToLog_Fails_when_Arg_used()
        {
            var ex = new InvalidOperationException($"Error Code {Guid.NewGuid()}: blah blah detail");
            Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Target, ex, "There was an error.");

            var thrownEx = Assert.Throws<NSubstitute.Exceptions.AmbiguousArgumentsException>(() =>
            {
                Target.Received(1)
                    .CallToLog(LogLevel.Warning, Arg.Is("There was an error."));
            });

            Assert.NotNull(thrownEx);
            Assert.Contains("Cannot determine argument specifications to use. Please use specifications for all arguments of the same type.", thrownEx.Message);
        }
    }
}
