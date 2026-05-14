using CS_DB_Exercise.Domains.Models;
namespace CS_DB_Exercise.Domains.Repositories;

public interface IEmployeeRepository
{
    List<Employee> FindAll();
    Employee? FindById(int id);
    Employee? FindByNameContainsWithDepartment(string name);
    void Create(Employee employee);
    bool UpdateById(Employee employee);
    bool DeleteById(int id);
}
