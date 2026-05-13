using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class DepartmentAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<DepartmentEntity> FindAll()
    {
        return [.. _context.Departments];
    }

    public DepartmentEntity? FindById(int id)
    {
        return _context.Departments.Find(id);
    }

    public DepartmentEntity? FindByIdJoinEmployee(int id)
    {
        var department = _context.Departments
            .Where(departmentEntity => departmentEntity.Id == id)
            .Include(departmentEntity => departmentEntity.Employees)
            .FirstOrDefault();
        return department;
    }
}
