using NSubstitute.Community.Logging.Internals;

namespace NSubstitute.Community.Logging
{
    /// <summary>
    /// Provides additional functionity for ILogStateVerifier
    /// </summary>
    public static class ILogStateVerifierExtensions
    {
        /// <summary>
        /// Returns true when the value stored at key exists and is equal to the provided expectedValue. 
        /// False in all other cases.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="verifier"></param>
        /// <param name="key"></param>
        /// <param name="expectedValue"></param>
        /// <returns></returns>
        public static bool KeyEquals<T>(this ILogStateVerifier verifier, string key, T expectedValue)
        {
            var exists = verifier.TryGetValue<T>(key, out var actualValue);

            return exists
                && (
                    (actualValue == null && expectedValue == null)
                    || (actualValue != null && actualValue.Equals(expectedValue))
                );
        }

        internal static bool MessageMatches(this LogStateVerifier verifier, string message, params object[] args)
        {
            if (verifier.OriginalFormat != message)
            {
                return false;
            }

            if (args.Length != verifier.State.Count - 1) /* minus 1 to skip the "{OriginalFormat}" entry */
            {
                return false;
            }

            for (var i = 0; i < args.Length; i++)
            {
                if (verifier.State[i].Value != args[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
