using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;

namespace CS_DB_Exercise.CS_DB_Sample.Application;

public sealed class RegisterSales
{
    private readonly AppDbContext _context;
    private readonly SalesAccessor _salesAccessor;
    private readonly SalesDetailAccessor _salesDetailAccessor;

    public RegisterSales(AppDbContext context)
    {
        _context = context;
        _salesAccessor = new SalesAccessor(_context);
        _salesDetailAccessor = new SalesDetailAccessor(_context);
    }

    public void Register(SalesEntity salesEntity, IReadOnlyList<SalesDetailEntity> salesDetails)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var salesResult = _salesAccessor.Create(salesEntity);
            Console.WriteLine("売上の登録に成功しました。");
            Console.WriteLine(salesResult);

            foreach (var salesDetail in salesDetails)
            {
                salesDetail.SalesId = salesResult.Id;
                var salesDetailResult = _salesDetailAccessor.Create(salesDetail);
                Console.WriteLine("売上明細の登録に成功しました。");
                Console.WriteLine(salesDetailResult);
            }

            transaction.Commit();
            Console.WriteLine("コミット:売上、売上明細の登録に成功しました。");
        }
        catch (Exception exception)
        {
            transaction.Rollback();
            Console.WriteLine("ロールバック:売上、売上明細の登録に失敗しました。");
            Console.WriteLine(exception.Message);
        }
    }
}
