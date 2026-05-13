using CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Adapters;

public sealed class ItemEntityAdapter : IItemAdapter<ItemEntity>
{
    public Item ToDomain(ItemEntity source)
    {
        ArgumentNullException.ThrowIfNull(source);

        var itemCategory = source.Category is null
            ? null
            : new ItemCategory(source.Category.Id, source.Category.Name!);

        return new Item(source.Id, source.Name!, source.Price, itemCategory);
    }

    public List<Item> ToDomainList(List<ItemEntity> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);
        return sources.Select(ToDomain).ToList();
    }

    public ItemEntity FromDomain(Item item)
    {
        ArgumentNullException.ThrowIfNull(item);

        return new ItemEntity
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CategoryId = item.Category?.Id
                ?? throw new InvalidOperationException("商品カテゴリが設定されていません。")
        };
    }

    public List<ItemEntity> FromDomainList(List<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        return items.Select(FromDomain).ToList();
    }
}
