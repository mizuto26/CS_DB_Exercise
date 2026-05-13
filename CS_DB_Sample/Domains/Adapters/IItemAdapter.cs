using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
namespace CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;

public interface IItemAdapter<T>
{
    Item ToDomain(T source);
    List<Item> ToDomainList(List<T> sources);
    T FromDomain(Item item);
    List<T> FromDomainList(List<Item> items);
}