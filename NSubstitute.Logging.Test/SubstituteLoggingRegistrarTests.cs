using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace NSubstitute.Logging.Test
{
    public class SubstituteLoggingRegistrarTests
    {
        private readonly IServiceProvider _serviceProvider = new ServiceCollection().AddSubstituteLoggers().BuildServiceProvider();
        private const string Empty = "";

        [Theory]
        [InlineData(null)]
        [InlineData(Empty)]
        [InlineData("serviceName")]
        public void CanGetILoggerFactory_Then_CreateLogger(string serviceName)
        {
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            Assert.NotNull(loggerFactory);

            var logger = loggerFactory.CreateLogger(serviceName);
            Assert.NotNull(logger);
        }

        [Fact]
        public void CanGetILoggerFactory_Then_CreateLoggerOfT()
        {
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            Assert.NotNull(loggerFactory);

            var logger = loggerFactory.CreateLogger<SubstituteLoggingRegistrarTests>();
            Assert.NotNull(logger);
        }

        [Fact]
        public void CanGetILoggerFactory_Then_CreateTracerOfPrivate()
        {
            var loggerFactory = _serviceProvider.GetService<ILoggerFactory>();
            Assert.NotNull(loggerFactory);

            var tracer = TestLoggingClass.MakeForPrivateClass(loggerFactory);
            Assert.NotNull(tracer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(Empty)]
        [InlineData("operationName")]
        public void CanGetILogger_ThenStartScope(string operationName)
        {
            var logger = _serviceProvider.GetService<ILogger>();
            Assert.NotNull(logger);

            var scope = logger.BeginScope(operationName);
            Assert.NotNull(scope);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(Empty)]
        [InlineData("operationName")]
        public void CanGetILoggerOfT_ThenStartScope(string operationName)
        {
            var logger = _serviceProvider.GetService<ILogger<SubstituteLoggingRegistrarTests>>();
            Assert.NotNull(logger);

            var scope = logger.BeginScope(operationName);
            Assert.NotNull(scope);
        }
    }

    public class TestLoggingClass
    {
        public static ILogger MakeForPrivateClass(ILoggerFactory loggerFactory)
        {
            return loggerFactory.CreateLogger<_TestLoggingClass>();

        }

        private class _TestLoggingClass
        {

        }
    }
}
