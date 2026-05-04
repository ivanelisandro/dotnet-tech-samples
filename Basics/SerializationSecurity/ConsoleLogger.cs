namespace SerializationSecurity
{
    /// <summary>
    /// Class to log messages to the console output.
    /// </summary>
    internal class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Adds an empty line to the <see cref="Console"/> output.
        /// </summary>
        public void AddEmpty()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Logs <paramref name="message"/> to the <see cref="Console"/> output.
        /// </summary>
        /// <param name="message">The message to be added to the console.</param>
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
