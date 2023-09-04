namespace NSubstitute.Logging
{
    /// <summary>
    /// Provides information about a log call that is being evaluated for execution
    /// </summary>
    public interface ILogStateVerifier
    {
        /// <summary>
        /// The message template that was used for logging.
        /// </summary>
        string OriginalFormat { get; }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        /// When this method returns, the value associated with the specified key, if the
        /// key is found; otherwise, the default value for the type of the value parameter.
        /// This parameter is passed uninitialized
        /// </param>
        /// <returns>
        /// true if the object that implements System.Collections.Generic.IDictionary`2 contains
        /// an element with the specified key; otherwise, false.
        /// </returns>
        bool TryGetValue<T>(string key, out T value);
    }
}
