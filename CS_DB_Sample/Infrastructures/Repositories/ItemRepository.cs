using Microsoft.EntityFrameworkCore;
using CS_DB_Exercise.CS_DB_Sample.Domains.Repositories;
using CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;
using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Repositories;

public sealed class ItemRepository(
    IItemAdapter<ItemEntity> adapter, AppDbContext appDbContext) : IItemRepository
{
    private readonly IItemAdapter<ItemEntity> _adapter = adapter;
    private readonly AppDbContext _appDbContext = appDbContext;

    public List<Item> FindAll()
    {
        var itemEntities = _appDbContext.Items
            .AsNoTracking()
            .ToList();
        return _adapter.ToDomainList(itemEntities);
    }

    public Item? FindById(int id)
    {
        var entity = _appDbContext.Items
            .Include(i => i.Category)
            .AsNoTracking()
            .SingleOrDefault(i => i.Id == id);

        return entity is null ? null : _adapter.ToDomain(entity);
    }

    public bool Exists(string name)
    {
        return _appDbContext.Items
            .Any(i => i.Name == name);
    }

    public void Create(Item item)
    {
        var entity = _adapter.FromDomain(item);
        _appDbContext.Items.Add(entity);
        _appDbContext.SaveChanges();
    }

    public bool UpdateById(Item item)
    {
        var entity = _appDbContext.Items
            .SingleOrDefault(i => i.Id == item.Id);

        if (entity is null)
        {
            return false;
        }

        entity.Name = item.Name;
        entity.Price = item.Price;
        _appDbContext.Items.Update(entity);
        _appDbContext.SaveChanges();
        return true;
    }

    public bool DeleteById(int id)
    {
        var entity = _appDbContext.Items
            .SingleOrDefault(i => i.Id == id);
        if (entity == null)
        {
            return false;
        }
        _appDbContext.Items.Remove(entity);
        _appDbContext.SaveChanges();
        return true;
    }
}
