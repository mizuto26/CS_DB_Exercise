using System.Linq;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Queries;

public class EmployeeAccessor(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public EmployeeEntity? FindByDeptId(int dept_id)
    {
        return _context.Employees.Find(dept_id);
    }

    public List<EmployeeEntity> FindByContaintsName(string keyword)
    {
        return [.. _context.Employees
            .Where(employeeEntity => employeeEntity.Name!.Contains(keyword))];
    }

    public void Create(EmployeeEntity employeeEntity)
    {
        _context.Employees.Add(employeeEntity);
        _context.SaveChanges();
    }

    public EmployeeEntity? UpdateById(EmployeeEntity employeeEntity)
    {
        var result = _context.Employees.Find(employeeEntity.Id);
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
        var result = _context.Employees.Find(id);
        if (result == null)
        {
            return null;// 商品が見つからない場合はnullを返す
        }
        var delResult = _context.Employees.Remove(result);
        _context.SaveChanges();
        return delResult.Entity;
    }

    public EmployeeEntity? FindByNameJoinDepartment(string name)
    {
        var employee = _context.Employees
            .Where(employeeEntity => employeeEntity.Name == name)
            .Include(employeeEntity => employeeEntity.Department)
            .FirstOrDefault();
        return employee;
    }

    public EmployeeEntity? FindByNameContainsJoinDepartment(string name)
    {
        var employee = _context.Employees
            .Where(employeeEntity => employeeEntity.Name!.Contains(name))
            .Include(employeeEntity => employeeEntity.Department)
            .FirstOrDefault();
        return employee;
    }
}
