using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class EmployeeAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public EmployeeEntity? FindByDeptId(int dept_id)
    {
        return _context.Employee.Find(dept_id);
    }
}
