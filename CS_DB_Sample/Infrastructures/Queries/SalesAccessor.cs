using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class SalesAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public SalesEntity Create(SalesEntity saleEntity)
    {
        var result = _context.Sales.Add(saleEntity);
        _context.SaveChanges();
        return result.Entity;
    }
}