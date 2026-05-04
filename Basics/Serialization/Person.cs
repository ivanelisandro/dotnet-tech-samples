namespace Serialization
{
    /// <summary>
    /// Class to represent a simple person.
    /// </summary>
    /// <param name="name">The full name of the person.</param>
    /// <param name="age">The current age of the person.</param>
    public class Person(string name, int age)
    {
        public string Name { get; private set; } = name;
        public int Age { get; private set; } = age;
    }
}
