namespace CS_DB_Exercise.CS_DB_Sample;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        var registerSales = new RegiterSales(context);

        var sale = new SalesEntity { SalesDate = DateTime.UtcNow, Total = 240, AccountId = 1 };

        var salesDetails = new List<SalesDetailEntity>
        {
            new SalesDetailEntity { Quantity = 1, Subtotal = 120, ItemId = 1 },
            new SalesDetailEntity { Quantity = 1, Subtotal = 120, ItemId = 2 }
        };

        registerSales.Register(sale, salesDetails);
    }
}