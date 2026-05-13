using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

[Table("item_stock")]
public class ItemStockEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }
}
