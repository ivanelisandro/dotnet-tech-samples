using System.Text.Json;

namespace SerializationSecurity
{
    /// <summary>
    /// Class to handle JSON serialization of an user.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> instance to handle messages.</param>
    internal class UserJsonSerializer(ILogger logger) : ISerializer
    {
        private readonly ILogger _logger = logger;

        /// <summary>
        /// Serializes an instance of <see cref="User"/> to a JSON string.
        /// </summary>
        /// <param name="user">The user data to be serialized.</param>
        /// <returns>A JSON string if the user data is valid, empty string otherwise.</returns>
        public string Serialize(User user)
        {
            if (!CanSerialize(user))
            {
                this._logger.Log("Invalid data. Serialization aborted.");
                return string.Empty;
            }

            return JsonSerializer.Serialize(user);
        }

        /// <summary>
        /// Deserializes a JSON string as an <see cref="User"/> object if possible.
        /// </summary>
        /// <param name="userData">The JSON string contaning user data.</param>
        /// <param name="isTrustedSource">A value indicating whether the data is coming from a trusted source.</param>
        /// <returns>A valid <see cref="User"/> instance if the data comes from a trusted source, false otherwise.</returns>
        public User? Deserialize(string userData, bool isTrustedSource)
        {
            if (!isTrustedSource)
            {
                this._logger.Log("Cannot deserialize from untrusted source.");
                return null;
            }

            return JsonSerializer.Deserialize<User>(userData);
        }

        /// <summary>
        /// Verifies if a user has not been created with invalid values for serialization.
        /// </summary>
        /// <param name="user">The user to be verified.</param>
        /// <returns>Returns true if the serialization can proceed, false otherwise.</returns>
        private static bool CanSerialize(User user)
        {
            bool isInvalid = string.IsNullOrWhiteSpace(user.Name) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Password);

            return !isInvalid;
        }
    }
}
