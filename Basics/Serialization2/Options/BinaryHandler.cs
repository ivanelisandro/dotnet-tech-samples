using Serialization2.Factories;

namespace Serialization2.Options
{
    /// <summary>
    /// Provides example methods for reading and writing binary objects.
    /// </summary>
    internal class BinaryHandler : IHandler
    {
        /// <summary>
        /// Stores the default file path to be used for serialization.
        /// </summary>
        private const string FilePath = "person.dat";

        /// <summary>
        /// Deserializes a <see cref="Person"/> object from a pre-existent binary file.
        /// </summary>
        public void Read()
        {
            Person person = new();

            using (FileStream stream = new(FilePath, FileMode.Open))
            {
                using BinaryReader reader = new(stream);
                person.Name = reader.ReadString();
                person.Age = reader.ReadInt32();
            }

            Console.WriteLine("Binary deserialization complete.");
            Console.WriteLine(person);
        }

        /// <summary>
        /// Serializes a <see cref="Person"/> object as a binary file.
        /// </summary>
        public void Write()
        {
            Person newPerson = PersonFactory.Create();
            using (FileStream stream = new(FilePath, FileMode.Create))
            {
                using BinaryWriter writer = new(stream);
                writer.Write(newPerson.Name);
                writer.Write(newPerson.Age);
            }

            Console.WriteLine("Binary serialization complete.");
        }
    }
}
