using CS_DB_Exercise.Domains.Models;
namespace CS_DB_Exercise.Domains.Adapters;

public interface IDepartmentAdapter<T>
{
    Department ToDomain(T source);
    List<Department> ToDomainList(List<T> sources);
    T FromDomain(Department department);
    List<T> FromDomainList(List<Department> departments);
}