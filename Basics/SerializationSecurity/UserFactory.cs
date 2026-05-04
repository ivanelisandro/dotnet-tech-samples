namespace SerializationSecurity
{
    /// <summary>
    /// Provides a way to create user objects.
    /// </summary>
    internal class UserFactory
    {
        /// <summary>
        /// Creates a <see cref="User"/> object from the parameters.
        /// </summary>
        /// <param name="name">The name for the user.</param>
        /// <param name="email">The email for the user.</param>
        /// <param name="password">The password for the user.</param>
        /// <returns>A new instance of user.</returns>
        internal static User Create(string name, string email, string password)
        {
            User user = new(name, email, password);
            user.Encrypt();
            return user;
        }
    }
}
