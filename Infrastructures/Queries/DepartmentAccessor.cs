using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class DepartmentAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<DepartmentEntity> FindAll()
    {
        return _context.Departments.ToList();
    }

    public DepartmentEntity? FindById(int id)
    {
        return _context.Departments.Find(id);
    }
}
