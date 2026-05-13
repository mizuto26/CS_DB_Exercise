using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

[Table("sales")]
public class SalesEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("sales_date")]
    public DateTime SalesDate { get; set; }

    [Column("total")]
    public int Total { get; set; }

    [Column("account_id")]
    public int AccountId { get; set; }
}
