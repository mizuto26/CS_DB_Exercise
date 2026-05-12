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
            .Where(i => i.Price == price)
            .ToList();

        return items;
    }

    public ItemEntity FindByNameTypeA(string name)
    {
        var item = _context.Items
            .Where(i => i.Name == name)
            .Select(i => new ItemEntity
            {
                Name = i.Name,
                Price = i.Price
            })
            .Single();
        return item;
    }

    public ItemEntity FindByNameTypeB(string name)
    {
        var item = _context.Items
            .Select(i => new ItemEntity
            {
                Name = i.Name,
                Price = i.Price
            })
            .Single(i => i.Name == name);
        return item;
    }

    public List<ItemEntity> FindByNameContains(string keyword)
    {
        return [.. _context.Items.Where(i => i.Name!.Contains(keyword))];
    }

    public List<ItemEntity> FindByNameStartsWith(string prefix)
    {
        return [.. _context.Items.Where(i => i.Name!.StartsWith(prefix))];
    }

    public List<ItemEntity> FindByNameEndsWith(string suffix)
    {
        return [.. _context.Items.Where(i => i.Name!.EndsWith(suffix))];
    }

    public List<ItemEntity> FindByPriceNoTracking(int price)
    {
        var items = _context.Items
            .Where(i => i.Price == price)
            .AsNoTracking()
            .ToList();
        return items;
    }
}