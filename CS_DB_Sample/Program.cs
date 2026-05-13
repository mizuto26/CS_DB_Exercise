using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Repositories;

namespace CS_DB_Exercise.CS_DB_Sample;

internal static class Program
{
    private static void Main()
    {
        using var context = new AppDbContext();
        var adapter = new ItemEntityAdapter();
        var itemRepository = new ItemRepository(adapter, context);

        var item = itemRepository.FindById(2);
        Console.WriteLine(item);
        var result = itemRepository.Exists("防水スプレー");
        Console.WriteLine($"データの有無:{result}");
    }
}
