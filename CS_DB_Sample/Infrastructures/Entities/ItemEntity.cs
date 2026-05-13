namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

public class ItemEntity
{
    public int Id { get; set; } // 商品Id（主キー）

    public string? Name { get; set; } // 商品名

    public int Price { get; set; } // 単価

    public int CategoryId { get; set; } // カテゴリId

    public ItemCategoryEntity? Category { get; set; }

    public override string? ToString()
    {
        return $"商品Id:{Id},商品名:{Name},単価{Price},カテゴリId:{CategoryId}";
    }
}
