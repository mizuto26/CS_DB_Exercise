using CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Adapters;

public sealed class ItemEntityAdapter : IItemAdapter<ItemEntity>
{
    public Item ToDomain(ItemEntity source)
    {
        ArgumentNullException.ThrowIfNull(source);

        ItemCategory? category = null;

        if (source.Category != null)
        {
            category = new ItemCategory(
                source.Category.Id,
                source.Category.Name ?? string.Empty
            );
        }

        return new Item(
            source.Id,
            source.Name ?? string.Empty,
            source.Price,
            category
        );
    }


    public List<Item> ToDomainList(List<ItemEntity> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);

        return sources
            .Select(ToDomain)
            .ToList();
    }


    public ItemEntity FromDomain(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (item.Category == null) { throw new InvalidOperationException("商品カテゴリが設定されていません。"); }

        return new ItemEntity
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CategoryId = item.Category.Id
        };
    }


    public List<ItemEntity> FromDomainList(List<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return items
            .Select(FromDomain)
            .ToList();
    }
}
