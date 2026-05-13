using CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Adapters;

public sealed class ItemCategoryEntityAdapter : IItemCategoryAdapter<ItemCategoryEntity>
{
    public ItemCategory ToDomain(ItemCategoryEntity source)
    {
        ArgumentNullException.ThrowIfNull(source);
        var itemCategory = new ItemCategory(source.Id, source.Name!);

        if (source.Items.Count > 0)
        {
            var items = source.Items
                .Select(item => new Item(
                    item.Id,
                    item.Name!,
                    item.Price,
                    itemCategory))
                .ToList();

            itemCategory.ChangeItems(items);
        }

        return itemCategory;
    }

    public List<ItemCategory> ToDomainList(List<ItemCategoryEntity> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);
        return sources.Select(ToDomain).ToList();
    }

    public ItemCategoryEntity FromDomain(ItemCategory itemCategory)
    {
        ArgumentNullException.ThrowIfNull(itemCategory);

        return new ItemCategoryEntity
        {
            Id = itemCategory.Id,
            Name = itemCategory.Name
        };
    }

    public List<ItemCategoryEntity> FromDomainList(List<ItemCategory> itemCategories)
    {
        ArgumentNullException.ThrowIfNull(itemCategories);
        return itemCategories.Select(FromDomain).ToList();
    }
}
