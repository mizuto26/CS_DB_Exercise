using CS_DB_Exercise.Domains.Models;
namespace CS_DB_Exercise.Domains.Adapters;

public interface IEmployeeAdapter<T>
{
    Employee ToDomain(T source);
    List<Employee> ToDomainList(List<T> sources);
    T FromDomain(Employee employee);
    List<T> FromDomainList(List<Employee> employees);
}