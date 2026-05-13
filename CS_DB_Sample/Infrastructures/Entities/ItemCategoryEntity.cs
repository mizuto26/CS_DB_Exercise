using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

[Table("item_category")]
public class ItemCategoryEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public List<ItemEntity> Items { get; set; } = [];

    public override string? ToString()
    {
        return $"カテゴリId:{Id},カテゴリ名:{Name}";
    }
}
