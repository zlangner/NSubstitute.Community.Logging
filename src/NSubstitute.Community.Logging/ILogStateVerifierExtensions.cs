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
    }
}
