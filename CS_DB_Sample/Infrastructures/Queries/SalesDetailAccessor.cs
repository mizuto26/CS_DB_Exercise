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

    public SalesDetailEntity Create(SalesDetailEntity salesDetail)
    {
        var result = _context.SalesDetails.Add(salesDetail);
        _context.SaveChanges();
        return result.Entity;
    }

    public List<ItemSalesSummary> FindAllGroupByItemId()
    {
        var groupedDetails = _context.SalesDetails
            .GroupBy(salesDetails => salesDetails.ItemId)
            .Select(iGrouping => new ItemSalesSummary
            {
                ItemId = iGrouping.Key,
                TotalQuantity = iGrouping.Sum(salesDetails => salesDetails.Quantity ?? 0),
                TotalSubtotal = iGrouping.Sum(salesDetails => salesDetails.Subtotal ?? 0)
            })
            .ToList();
        return groupedDetails;
    }
}
