namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

public class SalesEntity
{
    public int Id { get; set; }

    public DateTime SalesDate { get; set; }

    public int Total { get; set; }

    public int AccountId { get; set; }

    public override string? ToString()
    {
        return $"売上Id:{Id},売上日:{SalesDate},売上合計:{Total},アカウントId:{AccountId}";
    }
}
