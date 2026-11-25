using Exercise5.Decorators;
using Exercise5.Services;

IDataService productService =
    new CacheDecorator(new ProductService());

IDataService userService =
    new CacheDecorator(new UserService());

Console.WriteLine("PRODUCT:");
Console.WriteLine(productService.GetData(1));
Console.WriteLine(productService.GetData(1));

Console.WriteLine();

Console.WriteLine("USER:");
Console.WriteLine(userService.GetData(2));
Console.WriteLine(userService.GetData(2));