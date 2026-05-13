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

    public void Create(ItemEntity itemEntity)
    {
        _context.Items.Add(itemEntity);
        _context.SaveChanges();
    }

    public void CreateRange(List<ItemEntity> list_itemEntity)
    {
        _context.Items.AddRange(list_itemEntity);
        _context.SaveChanges();
    }

    public ItemEntity? UpdateById(ItemEntity itemEntity)
    {
        var result = _context.Items.Find(itemEntity.Id);
        if (result == null)
        {
            return null; // 商品が見つからない場合はnullを返す
        }
        result!.Name = itemEntity.Name;
        result.Price = itemEntity.Price;

        _context.SaveChanges();
        return result;
    }

    public void UpdateRange(List<ItemEntity> list_itemEntity)
    {
        _context.Items.UpdateRange(list_itemEntity);
        _context.SaveChanges();
    }

    public ItemEntity? DeleteById(ItemEntity item)
    {
        var result = _context.Items.Find(item.Id);
        if (result == null)
        {
            return null;// 商品が見つからない場合はnullを返す
        }

        var delResult = _context.Items.Remove(result);
        _context.SaveChanges();
        return delResult.Entity;
    }

    public void DeleteRange(List<ItemEntity> items)
    {
        _context.Items.RemoveRange(items);
        _context.SaveChanges();
    }

    public ItemEntity FindByIdJoinItemCategory(int id)
    {
        var item = _context.Items
            .Where(itemEntity => itemEntity.Id == id)
            .Include(itemEntity => itemEntity.Category)// カテゴリを結合して取得するテゴリを結合して取得する
            .Single();
        return item;
    }
}