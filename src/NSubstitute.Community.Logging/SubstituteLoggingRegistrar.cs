using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NSubstitute.Community.Logging
{
    /// <summary>
    /// Allows you to easily add fake logging to a IServiceCollection
    /// </summary>
    public static class SubstituteLoggingRegistrar
    {
        /// <summary>
        /// Used to register NSubstitute.Substitute loggers to the provided IServiceCollection.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddSubstituteLoggers(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ILoggerFactory>(sp => sp.GetRequiredService<SubstituteLoggerFactory>())
                .AddSingleton<SubstituteLoggerFactory>()
                .AddTransient(typeof(ILogger), typeof(SubstituteLogger))
                .AddTransient(typeof(ILogger<>), typeof(Logger<>))
            ;
        }

        private class SubstituteLoggerFactory : ILoggerFactory
        {
            public void AddProvider(ILoggerProvider provider) { }

            /// <inheritdoc/>
            public ILogger CreateLogger(string serviceName)
            {
                return Substitute.For<ILogger>();
            }

            public void Dispose() { }
        }

        private class SubstituteLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return Substitute.For<IDisposable>();
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) { }
        }
    }
}
