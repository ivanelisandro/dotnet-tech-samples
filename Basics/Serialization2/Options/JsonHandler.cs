namespace Serialization2.Options
{
    using System.Text.Json;
    using Serialization2.Factories;

    /// <summary>
    /// Provides example methods for reading and writing JSON objects.
    /// </summary>
    internal class JsonHandler : IHandler
    {
        /// <summary>
        /// Stores the default file path to be used for serialization.
        /// </summary>
        private const string FilePath = "person.json";

        /// <summary>
        /// Deserializes a <see cref="Person"/> object from a pre-existent JSON file.
        /// </summary>
        public void Read()
        {
            string personJson = File.ReadAllText(FilePath);
            Person? person = JsonSerializer.Deserialize<Person>(personJson);
            
            Console.WriteLine("JSON deserialization complete.");
            Console.WriteLine(person);
        }

        /// <summary>
        /// Serializes a <see cref="Person"/> object as a JSON file.
        /// </summary>
        public void Write()
        {
            Person person = PersonFactory.Create();
            string personJson = JsonSerializer.Serialize(person);
            File.WriteAllText(FilePath, personJson);
            
            Console.WriteLine("JSON serialization complete.");
            Console.WriteLine($"Serialized JSON: {personJson}");
        }
    }
}
