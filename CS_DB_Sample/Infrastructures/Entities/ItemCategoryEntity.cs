using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Sample.Infrastructures.Entities;

[Table("item_category")]
public class ItemCategoryEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public ICollection<ItemEntity> Items { get; set; } = [];
}
