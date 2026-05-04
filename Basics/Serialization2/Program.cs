using Serialization2.Options;

List<IHandler> handlers = [new BinaryHandler(), new XmlHandler(), new JsonHandler()];

foreach (var handler in handlers)
{
    Console.WriteLine("-------------------------------------");
    handler.Write();
    handler.Read();
}
