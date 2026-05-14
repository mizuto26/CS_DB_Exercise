using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Domains.Repositories;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Repositories;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    private readonly AppDbContext _context = context;

    public void Create(Employee employee)
    {
        _context.Add(ToEntity(employee));
        _context.SaveChanges();
    }

    public bool DeleteById(int id)
    {
        // 削除対象を取得する
        var entity = _context.Employees
           .SingleOrDefault(i => i.Id == id);
        if (entity == null)
        {
            // 削除対象が存在しない場合はfalseを返す
            return false;
        }
        // 削除する
        _context.Employees.Remove(entity);
        _context.SaveChanges();
        // 削除が成功したらtrueを返す
        return true;
    }

    public List<Employee> FindAll()
    {
        return _context.Employees
            .AsNoTracking()
            .ToList()
            .Select(ToDomain)
            .ToList();
    }

    public Employee? FindById(int id)
    {
        var entity = _context.Employees.Find(id);
        return entity is null ? null : ToDomain(entity);
    }

    public Employee? FindByNameContainsWithDepartment(string name)
    {
        var entity = _context.Employees
            .Include(employeeEntity => employeeEntity.Department)
            .AsNoTracking()
            .FirstOrDefault(employeeEntity => employeeEntity.Name!.Contains(name));

        return entity is null ? null : ToDomain(entity);
    }

    public bool UpdateById(Employee employee)
    {
        // 部署Idで変更対象社員を取得する
        var entity = _context.Employees
            .SingleOrDefault(i => i.Id == employee.Id);
        if (entity == null)
        {
            // 変更対象社員が見つからない場合はfalseを返す
            return false;
        }
        // 社員名を変更してデータベースに反映させる
        entity!.Name = employee.Name!;
        _context.Employees.Update(entity);
        _context.SaveChanges();
        // 変更が成功したらtrueを返す
        return true;
    }

    private static Employee ToDomain(EmployeeEntity source)
    {
        var department = source.Department is null
            ? null
            : new Department(source.Department.Id, source.Department.Name, null);

        return new Employee(source.Id, source.Name, department);
    }

    private static EmployeeEntity ToEntity(Employee employee)
    {
        return new EmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            DeptId = employee.Department?.Id
                ?? throw new InvalidOperationException("社員の所属部署が設定されていません。")
        };
    }
}
