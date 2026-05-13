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

    public List<EmployeeEntity> FindByContaintsName(string keyword)
    {
        return [.. _context.Employee
            .Where(employeeEntity => employeeEntity.Name!.Contains(keyword))];
    }

    public void Create(EmployeeEntity employeeEntity)
    {
        _context.Employee.Add(employeeEntity);
        _context.SaveChanges();
    }

    public EmployeeEntity? UpdateById(EmployeeEntity employeeEntity)
    {
        var result = _context.Employee.Find(employeeEntity.Id);
        if (result == null)
        {
            return null;
        }
        result!.Name = employeeEntity.Name;

        _context.SaveChanges();
        return result;
    }

    public EmployeeEntity? DeleteById(int id)
    {
        var result = _context.Employee.Find(id);
        if (result == null)
        {
            return null;// 商品が見つからない場合はnullを返す
        }
        var delResult = _context.Employee.Remove(result);
        _context.SaveChanges();
        return delResult.Entity;
    }
}
