namespace Serialization2.Options
{
    /// <summary>
    /// Provides a standard implementation for different types of object serialization.
    /// </summary>
    internal interface IHandler
    {
        void Read();

        void Write();
    }
}
