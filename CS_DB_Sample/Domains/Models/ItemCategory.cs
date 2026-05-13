using CS_DB_Exercise.CS_DB_Sample.Domains.Exceptions;

namespace CS_DB_Exercise.CS_DB_Sample.Domains.Models;

public sealed class ItemCategory : IEquatable<ItemCategory>
{
    public int Id { get; }
    public string Name { get; private set; } = string.Empty;
    public IReadOnlyList<Item> Items { get; private set; } = [];

    public ItemCategory(int id, string name)
    {
        Id = id;
        ChangeName(name);
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("カテゴリ名は必須です。");
        Name = name;
    }

    public void ChangeItems(IEnumerable<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);
        Items = items.ToList();
    }

    public bool Equals(ItemCategory? other)
    {
        return other is not null && Id == other.Id;
    }

    public override string ToString() =>
        $"カテゴリId:{Id}, カテゴリ名:{Name}, カテゴリに属する商品数:{Items.Count}";

    public override bool Equals(object? obj) =>
        obj is ItemCategory other && Equals(other);

    public override int GetHashCode() => Id.GetHashCode();
}
