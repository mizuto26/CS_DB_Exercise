using CS_DB_Exercise.CS_DB_Sample.Infrastructures;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Exercise.CS_DB_Sample;

class Program
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();
        var itemAccessor = new ItemAccessor(context);
        var itemCategoryAccessor = new ItemCategoryAccessor(context);
        var salesDetailAccessor = new SalesDetailAccessor(context);

        var item = itemAccessor.FindByIdJoinItemCategory(id: 1);
        Console.WriteLine(item);
        Console.WriteLine(item.Category);

        var itemCategory = itemCategoryAccessor.FindByIdJoinItems(id: 1);
        Console.WriteLine(itemCategory);
        foreach (var item in itemCategory.Items!)
        {
            Console.WriteLine(item);
        }

        var salesDetails = salesDetailAccessor.FindBySalesIdJoinItemAndItemCategory(1);
        foreach (var salesDetail in salesDetails)
        {
            Console.WriteLine(salesDetail);
            Console.WriteLine(salesDetail.Item);
            Console.WriteLine(salesDetail.Item!.Category);

        }
    }
}