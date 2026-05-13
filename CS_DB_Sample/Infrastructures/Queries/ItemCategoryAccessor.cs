using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class ItemCategoryAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public ItemCategoryEntity FindByIdJoinItems(int id)
    {
        var itemCategory = _context.ItemCategories
            .Where(itemCategory => itemCategory.Id == id)
            .Include(itemCategory => itemCategory.Items) // 商品を結合して取得する
            .Single();
        return itemCategory;
    }
}