using CS_DB_Exercise.CS_DB_Sample.Domains.Exceptions;

namespace CS_DB_Exercise.CS_DB_Sample.Domains.Models;

public sealed class Item : IEquatable<Item>
{
    public int Id { get; }
    public string Name { get; private set; } = string.Empty;
    public int Price { get; private set; }
    public ItemCategory? Category { get; private set; }

    public Item(int id, string name, int price, ItemCategory? category)
    {
        Id = id;
        ChangeName(name);
        ChangePrice(price);
        ChangeCategory(category);
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new DomainException("商品名は必須です。");
        Name = newName;
    }

    public void ChangePrice(int newPrice)
    {
        if (newPrice < 0)
            throw new DomainException("価格は0以上でなければなりません。");
        Price = newPrice;
    }

    public void ChangeCategory(ItemCategory? newCategory)
    {
        Category = newCategory;
    }

    public bool Equals(Item? other)
    {
        return other is not null && Id == other.Id;
    }

    public override string ToString() =>
        $"商品Id:{Id}, 商品名:{Name}, 単価:{Price}, 商品カテゴリ:{Category}";

    public override bool Equals(object? obj) =>
        obj is Item other && Equals(other);

    public override int GetHashCode() => Id.GetHashCode();
}
