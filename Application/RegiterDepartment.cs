using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Queries;
using CS_DB_Exercise.Infrastructures.Entities;
namespace CS_DB_Exercise.Application;

public class RegiterDepartment
{
    private readonly AppDbContext _context;
    private readonly DepartmentAccessor _departmentAccessor;

    public RegiterDepartment(AppDbContext context)
    {
        _context = context;
        _departmentAccessor = new DepartmentAccessor(_context);
    }

    public void Register(DepartmentEntity departmentEntity)
    {
        using var transaction = _context.Database.BeginTransaction();
        Console.WriteLine("トランザクションを開始しました。");
        try
        {
            var result = _departmentAccessor.Create(departmentEntity);
            Console.WriteLine("売上の登録に成功しました。");
            Console.WriteLine(result);

            transaction.Commit();
            Console.WriteLine("トランザクションをコミットしました。");
        }
        catch (Exception exception)
        {
            transaction.Rollback();
            Console.WriteLine("トランザクションをロールバックしました。");
            Console.WriteLine(exception.Message);
        }
    }
}