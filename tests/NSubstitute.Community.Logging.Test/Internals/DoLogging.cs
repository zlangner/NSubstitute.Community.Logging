using Microsoft.Extensions.Logging;
using System;

// not using NSubstitute.Community.Logging namespace so this will not use the NSubstitute.Community.Logging.LoggerExtensions
namespace Example.Test.Internals
{
    public class DoLogging
    {
        private readonly ILogger<DoLogging> _logger;

        public DoLogging(ILogger<DoLogging> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int Add(int a, int b)
        {
            var answer = a + b;

            _logger.LogTrace("{a} + {b} = {c}", a, b, answer);

            return answer;
        }

        public void Throw()
        {
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
