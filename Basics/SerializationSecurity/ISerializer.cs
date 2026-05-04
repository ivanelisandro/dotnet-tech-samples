namespace SerializationSecurity
{
    /// <summary>
    /// Interface to handle serialization of an user.
    /// </summary>
    internal interface ISerializer
    {
        /// <summary>
        /// Serializes an instance of <see cref="User"/> to some data format.
        /// </summary>
        /// <param name="user">The user data to be serialized.</param>
        /// <returns>A string with serialized data if the user data is valid, empty string otherwise.</returns>
        string Serialize(User user);

        /// <summary>
        /// Deserializes a string containing user data as an <see cref="User"/> object if possible.
        /// </summary>
        /// <param name="userData">The string contaning user data.</param>
        /// <param name="isTrustedSource">A value indicating whether the data is coming from a trusted source.</param>
        /// <returns>A valid <see cref="User"/> instance if the data comes from a trusted source, false otherwise.</returns>
        User? Deserialize(string userData, bool isTrustedSource);
    }
}
