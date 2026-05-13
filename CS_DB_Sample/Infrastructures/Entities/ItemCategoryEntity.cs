namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

public class ItemCategoryEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<ItemEntity> Items { get; set; } = [];

    public override string? ToString()
    {
        return $"カテゴリId:{Id},カテゴリ名:{Name}";
    }
}
