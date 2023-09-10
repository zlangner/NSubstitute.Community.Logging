using Microsoft.Extensions.Logging;
using System;

// not using NSubstitute.Community.Logging namespace so this will not use the NSubstitute.Community.Logging.LoggerExtensions
namespace Example.Test.Internals
{
    public class DoScopedLogging
    {
        private readonly ILogger<DoScopedLogging> _logger;

        public DoScopedLogging(ILogger<DoScopedLogging> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int Add(int a, int b)
        {
            using var scope = _logger.BeginScope("Enter {MethodName} {param1} {param2} {param3}", nameof(Add), 1, 2, 3);
            var answer = a + b;

            _logger.LogTrace("{a} + {b} = {c}", a, b, answer);

            return answer;
        }

        public void Throw()
        {
            using var scope = _logger.BeginScope("Enter {MethodName} {param1} {param2} {param3}", nameof(Throw), 1, 2, 3);

            try
            {
                throw new NotSupportedException("Don't do that");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error encountered in {MethodName} and rethrown.", nameof(Throw));
                throw;
            }
        }
    }
}
