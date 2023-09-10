using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NSubstitute.Community.Logging.Internals;

namespace NSubstitute.Community.Logging
{
    /// <summary>
    /// Used to verify logs were created by the provided NSubstitute ILogger
    /// </summary>
    public static class ILoggerExtensions
    {
        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Any<IReadOnlyList<KeyValuePair<string, object>>>(),
                    Arg.Any<Exception>(),
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="message">Format string of the log message.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => new LogStateVerifier(list).OriginalFormat == message),
                    Arg.Any<Exception>(),
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="message">Format string of the log message.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, EventId eventId, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    eventId,
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => new LogStateVerifier(list).OriginalFormat == message),
                    Arg.Any<Exception>(),
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="exception">The exception to log.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, Exception exception)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Any<IReadOnlyList<KeyValuePair<string, object>>>(),
                    exception,
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, Exception exception, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => new LogStateVerifier(list).OriginalFormat == message),
                    exception,
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Formats and writes a log message at the specified log level.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    eventId,
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => new LogStateVerifier(list).OriginalFormat == message),
                    exception,
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }



        /// <summary>
        /// Finds ILogger.Log() calls made with the logLevel and logStateVerifier provided.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, Func<ILogStateVerifier, bool> predicate)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => predicate(new LogStateVerifier(list))),
                    Arg.Any<Exception>(),
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Finds ILogger.Log() calls made with the logLevel and logStateVerifier provided.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, EventId eventId, Func<ILogStateVerifier, bool> predicate)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    eventId,
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => predicate(new LogStateVerifier(list))),
                    Arg.Any<Exception>(),
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Finds ILogger.Log() calls made with the logLevel and logStateVerifier provided.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, Exception exception, Func<ILogStateVerifier, bool> predicate)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    Arg.Any<EventId>(),
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => predicate(new LogStateVerifier(list))),
                    exception,
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Finds ILogger.Log() calls made with the logLevel and logStateVerifier provided.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">The event id associated with the log.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CallToLog(this ILogger logger, LogLevel logLevel, EventId eventId, Exception exception, Func<ILogStateVerifier, bool> predicate)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger
                .Log(
                    logLevel,
                    eventId,
                    Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(list => predicate(new LogStateVerifier(list))),
                    exception,
                    Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception, string>>()
                );
        }

        /// <summary>
        /// Finds ILogger.BeginScope() calls made with the logLevel and logStateVerifier provided.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to create the scope in.</param>
        /// <param name="predicate"></param>
        /// <returns>A disposable scope object. Can be null.</returns>
        public static IDisposable CallToBeginScope(this ILogger logger, Func<ILogStateVerifier, bool> predicate)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            return logger
                .BeginScope(
                    Arg.Is<IReadOnlyCollection<KeyValuePair<string, object>>>(list => predicate(new LogScopeVerifier(list)))
                );
        }
    }
}
