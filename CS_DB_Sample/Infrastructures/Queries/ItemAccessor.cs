using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class ItemAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public ItemEntity FindByIdJoinItemCategory(int id)
    {
        var item = _context.Items
            .Where(itemEntity => itemEntity.Id == id)
            .Include(itemEntity => itemEntity.Category)// カテゴリを結合して取得するテゴリを結合して取得する
            .Single();
        return item;
    }

    public List<ItemEntity> FindAllOrderByName()
    {
        var items = _context.Items
            .OrderBy(i => i.Name)
            .ToList();
        return items;
    }

    public List<ItemEntity> FindAllOrderByDecPrice()
    {
        var items = _context.Items
            .OrderByDescending(i => i.Price)
            .ToList();
        return items;
    }

    public bool ExistsItemWithStock(int stock)
    {
        var exists = _context.ItemStocks
            .Any(stockEntity => stockEntity.Stock >= stock);
        return exists;
    }

    public List<ItemEntity> FindItemsByNameAndStockContains(string keyword, int stock)
    {
        var stockItemIds = _context.ItemStocks
            .Where(stockEntity => stockEntity.Stock == stock)
            .Select(stockEntity => stockEntity.ItemId)
            .ToList();

        var items = _context.Items
            .Where(itemEntity =>
                itemEntity.Name!.Contains(keyword) && stockItemIds.Contains(itemEntity.Id)
            )
            .ToList();

        return items;
    }

    public int GetAveragePriceByCategoryId(int categoryId)
    {
        var average = _context.Items
            .Where(itemEntity => itemEntity.CategoryId == categoryId)
            .Select(itemEntity => itemEntity.Price)
            .Average();
        return (int)Math.Floor(average);
    }

    public int GetTotalPriceByCategoryId(int categoryId)
    {
        var sum = _context.Items
            .Where(itemEntity => itemEntity.CategoryId == categoryId)
            .Select(itemEntity => itemEntity.Price)
            .Sum();
        return sum;
    }
}