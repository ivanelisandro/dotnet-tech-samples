using CRUDWithMySQL;

TestingDatabase tester = new();

// Testing Create
int productId = tester.Create("Gaming Laptop X18", 8599.99m);

// Testing Read all items
tester.ReadAll("All Products:");

// Testing Read
tester.Read(productId);

// Testing Update
tester.Update(productId, 7999.99m);
tester.Read(productId);

// Testing Delete
tester.Delete(productId);
tester.ReadAll("All Products after delete:");

Console.ReadLine();
