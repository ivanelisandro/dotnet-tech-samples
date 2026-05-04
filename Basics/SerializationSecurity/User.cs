using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SerializationSecurity
{
    /// <summary>
    /// Class to represent a user.
    /// </summary>
    /// <param name="name">The full name of the user.</param>
    /// <param name="email">The email of the user.</param>
    /// <param name="password">The password for the user.</param>
    public class User(string name, string email, string password)
    {
        public string Name { get; set; } = name;

        public string Email { get; set; } = email;

        public string Password { get; set; } = password;

        /// <summary>
        /// Converts the object into a JSON string.
        /// </summary>
        /// <returns>Formatted JSON string.</returns>
        public override string ToString() => JsonSerializer.Serialize(this);

        /// <summary>
        /// Encrypts sensitive data to avoid storing as plain text.
        /// </summary>
        internal void Encrypt()
        {
            Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        }

        /// <summary>
        /// Generates the hash for the current object data.
        /// </summary>
        /// <returns>The hash for the current object data.</returns>
        internal string GenerateHash()
        {
            byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(ToString()));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
