using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

[Table("item")]
public class ItemEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; } // 商品Id（主キー）

    [Column("name")]
    public string? Name { get; set; } // 商品名

    [Column("price")]
    public int Price { get; set; } // 単価

    [Column("category_id")]
    public int CategoryId { get; set; } // カテゴリId

    public ItemCategoryEntity? Category { get; set; }
}
