using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class SalesDetailAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<SalesDetailEntity> FindBySalesIdJoinItemAndItemCategory(int salesId)
    {
        var salesDetails = _context.SalesDetails
            .Where(salesDetailsEntity => salesDetailsEntity.SalesId == salesId)
            .Include(salesDetailsEntity => salesDetailsEntity.Item)
            .ThenInclude(itemEntity => itemEntity!.Category)
            .ToList();
        return salesDetails;
    }
}