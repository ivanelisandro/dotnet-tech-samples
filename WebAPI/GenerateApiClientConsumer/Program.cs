using GenerateApiClientConsumer;

var httpClient = new HttpClient();
var client = new UsersApiClient("http://localhost:5063", httpClient);

UsersValidation validator = new(client);

await validator.ReadAll();

await validator.ReadSingle(2);
await validator.ReadSingle(6);

await validator.Add("João Oliveira");
await validator.ReadAll();

await validator.Update(8, "Beatriz Oliveira");
await validator.ReadAll();

await validator.Remove(11);
await validator.ReadAll();

Console.ReadLine();