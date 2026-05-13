using CS_DB_Exercise.Domains.Models;
namespace CS_DB_Exercise.Domains.Repositories;

public interface IDepartmentRepository
{
    List<Department> FindAll();
    Department? FindById(int id);
    void Create(Department department);
    bool UpdateById(Department department);
    bool DeleteById(int id);
}