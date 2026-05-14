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

        var items = _adapter.ToDomainList(itemEntities);

        return items;
    }


    public Item? FindById(int id)
    {
        var itemEntity = _appDbContext.Items
            .Include(item => item.Category)
            .AsNoTracking()
            .SingleOrDefault(item => item.Id == id);

        if (itemEntity == null)
        {
            return null;
        }

        var item = _adapter.ToDomain(itemEntity);

        return item;
    }


    public bool Exists(string name)
    {
        var exists = _appDbContext.Items
            .Any(item => item.Name == name);

        return exists;
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

        if (entity == null)
        {
            return false;
        }

        entity.Name = item.Name;
        entity.Price = item.Price;

        _appDbContext.SaveChanges();

        return true;
    }


    public bool DeleteById(int id)
    {
        var entity = _appDbContext.Items
            .SingleOrDefault(item => item.Id == id);

        if (entity == null)
        {
            return false;
        }

        _appDbContext.Items.Remove(entity);
        _appDbContext.SaveChanges();

        return true;
    }
}
