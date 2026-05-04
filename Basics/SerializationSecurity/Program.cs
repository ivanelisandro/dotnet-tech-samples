using SerializationSecurity;

ILogger logger = new ConsoleLogger();
ISerializer serializer = new UserJsonSerializer(logger);
Simulator simulator = new(logger, serializer);
simulator.Run();
