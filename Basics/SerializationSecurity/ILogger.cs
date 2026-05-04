namespace SerializationSecurity
{
    /// <summary>
    /// Defines an interface for logging simple messages.
    /// </summary>
    internal interface ILogger
    {
        /// <summary>
        /// Adds an empty line to an output.
        /// </summary>
        void AddEmpty();

        /// <summary>
        /// Logs a given message to an output.
        /// </summary>
        /// <param name="message">The message to be added to a log context.</param>
        void Log(string message);
    }
}
