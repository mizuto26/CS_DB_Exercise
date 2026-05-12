using CS_DB_Exercise.CS_DB_Sample.Infrastructures;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Exercise.CS_DB_Sample;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new ItemAccessor(new AppDbContext());

        var items1 = accessor.FindByPrice(120);
        Console.WriteLine("単価120の商品を取得する");
        foreach (var item in items1)
        {
            Console.WriteLine($"商品名：{item.Name} 単価：{item.Price}");
        }

        var result = accessor.FindByNameTypeA("水性ボールペン(青)");
        Console.WriteLine(result);
        result = accessor.FindByNameTypeB("水性ボールペン(赤)");
        Console.WriteLine(result);

        var items2 = accessor.FindByNameContains("ペン");
        Console.WriteLine("商品名に指定語句を「含む」商品を検索（中間一致）");
        foreach (var item in items2)
        {
            Console.WriteLine(item);
        }
        items2 = accessor.FindByNameStartsWith("水性");
        Console.WriteLine("商品名が指定語句で「始まる」商品を検索（前方一致）");
        foreach (var item in items2)
        {
            Console.WriteLine(item);
        }
        items2 = accessor.FindByNameEndsWith("キーボード");
        Console.WriteLine("商品名が指定語句で「終わる」商品を検索（後方一致）");
        foreach (var item in items2)
        {
            Console.WriteLine(item);
        }
    }
}