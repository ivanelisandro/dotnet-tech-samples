namespace Serialization2
{
    /// <summary>
    /// Class to represent a simple person.
    /// </summary>
    /// <param name="name">The full name of the person.</param>
    /// <param name="age">The current age of the person.</param>
    public class Person(string name, int age)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person() :
            this("João Silva", 25)
        {
        }

        public string Name { get; set; } = name;
        public int Age { get; set; } = age;

        /// <summary>
        /// Defines a friendly representation for a person when using in <see cref="Console"/>.
        /// </summary>
        /// <returns>Formatted string including all the person information.</returns>
        public override string ToString()
        {
            return $"- {this.Name}, {this.Age} years old";
        }
    }
}
