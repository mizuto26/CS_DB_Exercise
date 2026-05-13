namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

public class SalesDetailEntity
{
    public int Id { get; set; }         // 売上明細Id（主キー）

    public int SalesId { get; set; }    // 売上Id (主キー)

    public int? Quantity { get; set; }  // 数量

    public int? Subtotal { get; set; }  // 小計

    public int? ItemId { get; set; }    // 商品Id

    public ItemEntity? Item { get; set; } // 商品

    public override string? ToString()
    {
        return $"売上明細Id:{Id},売上Id:{SalesId},数量:{Quantity},小計:{Subtotal}";
    }
}
