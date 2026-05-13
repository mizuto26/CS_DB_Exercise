using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
namespace CS_DB_Exercise.CS_DB_Sample.Domains.Repositories;

public interface IItemRepository
{
    List<Item> FindAll();
    Item? FindById(int id);
    void Create(Item item);
    bool UpdateById(Item item);
    bool DeleteById(int id);
    bool Exists(string name);
}