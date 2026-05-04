namespace Serialization2.Factories
{
    /// <summary>
    /// Provides a way to create person objects.
    /// </summary>
    internal static class PersonFactory
    {
        /// <summary>
        /// Holds names to use when creating <see cref="Person"/> objects.
        /// </summary>
        private static readonly string[] Names = ["João Silva", "Julio Santos", "Mateus Silva", "Alice Santos", "Maria Oliveira"];

        /// <summary>
        /// Holds ages to use when creating <see cref="Person"/> objects.
        /// </summary>
        private static readonly int[] Ages = [25, 30, 36, 22, 40];

        /// <summary>
        /// Holds the index of the current values to be used to create an object.
        /// </summary>
        private static int CurrentIndex = 0;

        /// <summary>
        /// Creates a <see cref="Person"/> object from the values available.
        /// </summary>
        /// <returns>A new instance of a person.</returns>
        internal static Person Create()
        {
            if (CurrentIndex >= Names.Length)
            {
                CurrentIndex = 0;
            }

            return new(Names[CurrentIndex], Ages[CurrentIndex++]);
        }
    }
}
