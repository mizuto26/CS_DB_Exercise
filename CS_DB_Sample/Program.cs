namespace CS_DB_Exercise.CS_DB_Sample;

internal static class Program
{
    private static void Main()
    {
        var provider = ServiceProviderBuilder.Build();
        var repository = provider!.GetService<IItemRepository>();

        var items = repository!.FindAll();
        foreach (var item in items)
        {
            Console.WriteLine($"商品Id:{item.Id}, 商品名:{item.Name}, 価格:{item.Price}");
        }
    }
}
