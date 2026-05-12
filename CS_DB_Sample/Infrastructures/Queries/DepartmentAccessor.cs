using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Queries;

public class DepartementAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public List<DepartmentEntity> FindAll()
    {
        var departments = _context.Departments.ToList();
        return departments;
    }

    public DepartmentEntity? FindById(int departmentId)
    {
        var department = _context.Departments.Find(departmentId);
        return department;
    }
}