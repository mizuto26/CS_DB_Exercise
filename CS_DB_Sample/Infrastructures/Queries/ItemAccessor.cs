using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class ItemAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<ItemEntity> FindByPrice(int price)
    {
        var items = _context.Items
            .Where(itemEntity =>
                (itemEntity.Price == price))
            .ToList();//条件一致するすべてのレコード

        return items;
    }

    public ItemEntity FindByNameTypeA(string name)
    {
        var item = _context.Items
            .Where(itemEntity =>
                (itemEntity.Name == name))
            .Select(itemEntity =>
                new ItemEntity
                {
                    Name = itemEntity.Name,
                    Price = itemEntity.Price
                })
            .Single();//レコードが1件だけか
        return item;
    }

    public ItemEntity FindByNameTypeB(string name)
    {
        var item = _context.Items
            .Select(itemEntity =>
                new ItemEntity
                {
                    Name = itemEntity.Name,
                    Price = itemEntity.Price
                })
            .Single(itemEntity =>
                (itemEntity.Name == name));
        return item;
    }

    public List<ItemEntity> FindByNameContains(string keyword)
    {
        return [.. _context.Items
            .Where(itemEntity => itemEntity.Name!.Contains(keyword))];
    }

    public List<ItemEntity> FindByNameStartsWith(string prefix)
    {
        return [.. _context.Items
            .Where(itemEntity => itemEntity.Name!.StartsWith(prefix))];
    }

    public List<ItemEntity> FindByNameEndsWith(string suffix)
    {
        return [.. _context.Items
            .Where(itemEntity => itemEntity.Name!.EndsWith(suffix))];
    }

    public List<ItemEntity> FindByPriceNoTracking(int price)
    {
        var items = _context.Items
            .Where(itemEntity => (itemEntity.Price == price))
            .AsNoTracking()
            .ToList();
        return items;
    }
}