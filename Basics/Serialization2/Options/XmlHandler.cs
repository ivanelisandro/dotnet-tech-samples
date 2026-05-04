namespace Serialization2.Options
{
    using System.Xml.Serialization;
    using Serialization2.Factories;

    /// <summary>
    /// Provides example methods for reading and writing XML objects.
    /// </summary>
    internal class XmlHandler : IHandler
    {
        /// <summary>
        /// Stores the default file path to be used for serialization.
        /// </summary>
        private const string FilePath = "person.xml";

        /// <summary>
        /// Deserializes a <see cref="Person"/> object from a pre-existent XML file.
        /// </summary>
        public void Read()
        {
            XmlSerializer serializer = new(typeof(Person));
            Person? person = null;

            using (StreamReader reader = new(FilePath))
            {
                person = serializer.Deserialize(reader) as Person;
            }

            Console.WriteLine("XML deserialization complete.");
            Console.WriteLine(person);
        }

        /// <summary>
        /// Serializes a <see cref="Person"/> object as an XML file.
        /// </summary>
        public void Write()
        {
            Person newPerson = PersonFactory.Create();
            XmlSerializer serializer = new(typeof(Person));

            using (StreamWriter writer = new(FilePath))
            {
                serializer.Serialize(writer, newPerson);
            }

            Console.WriteLine("XML serialization complete.");
        }

    }
}
