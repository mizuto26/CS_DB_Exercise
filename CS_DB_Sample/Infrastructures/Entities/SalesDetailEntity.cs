using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

[Table("sales_detail")]
public class SalesDetailEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }         // 売上明細Id（主キー）

    [Column("sales_id")]
    public int SalesId { get; set; }    // 売上Id (主キー)

    [Column("quantity")]
    public int? Quantity { get; set; }  // 数量

    [Column("subtotal")]
    public int? Subtotal { get; set; }  // 小計

    [Column("item_id")]
    public int? ItemId { get; set; }    // 商品Id

    public ItemEntity? Item { get; set; } // 商品
}
