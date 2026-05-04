using Newtonsoft.Json;

namespace Serialization
{
    /// <summary>
    /// Provides example methods for reading and writing JSON objects.
    /// </summary>
    internal static class JsonHandler
    {
        /// <summary>
        /// Deserializes a <see cref="Person"/> object from a static JSON string.
        /// </summary>
        internal static void Read()
        {
            string personJson = "{\"Name\": \"João Silva\", \"Age\": 25}";
            var person = JsonConvert.DeserializeObject<Person>(personJson);

            if (person is not null)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Person"/> object as a JSON string.
        /// </summary>
        internal static void Write()
        {
            Person person = new("Maria Santos", 35);
            string personJson = JsonConvert.SerializeObject(person);
            Console.WriteLine($"Serialized JSON: {personJson}");
        }

    }
}
