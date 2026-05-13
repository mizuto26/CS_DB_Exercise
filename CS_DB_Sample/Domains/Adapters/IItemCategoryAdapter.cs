using CS_DB_Exercise.CS_DB_Sample.Domains.Models;
namespace CS_DB_Exercise.CS_DB_Sample.Domains.Adapters;

public interface IItemCategoryAdapter<T>
{
    ItemCategory ToDomain(T source);
    List<ItemCategory> ToDomainList(List<T> sources);
    T FromDomain(ItemCategory itemCategory);
    List<T> FromDomainList(List<ItemCategory> itemCategoryies);
}