using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;

namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

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
}
