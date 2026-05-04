namespace SerializationSecurity
{
    /// <summary>
    /// A class to group the simulation of the serialization cases discussed in this exercise.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> instance to handle messages.</param>
    internal class Simulator(ILogger logger, ISerializer serializer)
    {
        private readonly ILogger _logger = logger;
        private readonly ISerializer _serializer = serializer;

        /// <summary>
        /// Runs the cases we are simulating to observe the different results.
        /// </summary>
        internal void Run()
        {
            this._logger.Log("---------------------------------------Show simple user---------------------------------------");
            User user1 = UserFactory.Create("João Silva", "joao@example.com", "SupeRp@559854");
            this.LogUser(user1);
            this._logger.AddEmpty();

            // Compare valid and invalid users.
            this._logger.Log("-------------------------------Compare valid and invalid users--------------------------------");
            User user2 = UserFactory.Create("Alice", "alice@example.com", "SecureP@ss123");
            this.LogUser(user2);
            this.ShowInvalidUser();
            this._logger.AddEmpty();

            // Compare trusted and untrusted sources results.
            this._logger.Log("----------------------------Compare trusted and untrusted sources-----------------------------");
            this.SimulateUntrustedSource(user1);
            this.SimulateTrustedSource(user2);

            // View hashes
            this._logger.Log("--------------------------------------Show object hashes--------------------------------------");
            this.LogHash("User 1:", user1);
            this.LogHash("User 2:", user2);
            
            this._logger.Log("----------------------------------------------END---------------------------------------------");
        }

        /// <summary>
        /// Logs the user data for visualization.
        /// </summary>
        /// <param name="user">The user to extract data.</param>
        private void LogUser(User user)
        {
            this._logger.Log("Serializing valid user...");
            this._logger.Log("Serialized Data:");
            this._logger.Log(this._serializer.Serialize(user));
        }

        /// <summary>
        /// Creates an invalid user and logs its data for visualization.
        /// </summary>
        private void ShowInvalidUser()
        {
            this._logger.Log("Serializing invalid user...");
            User invalidUser = new("", "some@example.com", "");
            this._logger.Log(this._serializer.Serialize(invalidUser));
        }

        /// <summary>
        /// Simulates attempting to serialize user data from an untrusted source.
        /// </summary>
        /// <param name="user">The user to attempt serializing.</param>
        private void SimulateUntrustedSource(User user)
        {
            this._logger.Log("Simulating untrusted source:");
            string untrustedSourceData = this._serializer.Serialize(user); // Assumes this is from a untrusted source.
            var suspectUser = this._serializer.Deserialize(untrustedSourceData, false);

            if (suspectUser is null)
            {
                this._logger.Log("Deserialization failed for untrusted source.");
            }

            this._logger.AddEmpty();
        }

        /// <summary>
        /// Simulates attempting to serialize user data from a trusted source.
        /// </summary>
        /// <param name="user">The user to attempt serializing.</param>
        private void SimulateTrustedSource(User user)
        {
            this._logger.Log("Simulating trusted source:");
            string trustedSourceData = this._serializer.Serialize(user); // Assumes this is from a trusted source.
            var trustedUser = this._serializer.Deserialize(trustedSourceData, true);

            if (trustedUser is not null)
            {
                this._logger.Log("Deserialization successful for trusted source.");
            }

            this._logger.AddEmpty();
        }

        /// <summary>
        /// Logs the user hash for visualization.
        /// </summary>
        /// <param name="title">A title to include in the log for better visualization of the user information.</param>
        /// <param name="user">The user to extract the hash.</param>
        private void LogHash(string title, User user)
        {
            this._logger.Log(title);
            this._logger.Log(this._serializer.Serialize(user));
            this._logger.Log($"User hash: {user.GenerateHash()}");
            this._logger.AddEmpty();
        }
    }
}
