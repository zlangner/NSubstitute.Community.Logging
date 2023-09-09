using System;
using System.Collections.Generic;

namespace NSubstitute.Community.Logging.Internals
{
    internal struct LogStateVerifier : ILogStateVerifier
    {
        private readonly IReadOnlyList<KeyValuePair<string, object>> _state;

        public LogStateVerifier(IReadOnlyList<KeyValuePair<string, object>> state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        /// <inheritdoc/>
        public string OriginalFormat
        {
            get
            {
                if (TryGetValue("{OriginalFormat}", out string message))
                {
                    return message;
                }

                return default;
            }
        }

        /// <inheritdoc/>
        public IReadOnlyList<KeyValuePair<string, object>> State => _state;

        /// <inheritdoc/>
        public bool TryGetValue<T>(string key, out T value)
        {
            foreach (var kvp in _state)
            {
                if (string.Compare(kvp.Key, key, StringComparison.Ordinal) == 0)
                {
                    value = (T)kvp.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
