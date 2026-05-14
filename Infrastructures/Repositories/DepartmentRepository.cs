using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Domains.Repositories;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS_DB_Exercise.Infrastructures.Repositories;

public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    private readonly AppDbContext _context = context;

    public void Create(Department department)
    {
        _context.Add(ToEntity(department));
        _context.SaveChanges();
    }

    public bool DeleteById(int id)
    {
        // 削除対象を取得する
        var entity = _context.Departments
           .SingleOrDefault(i => i.Id == id);
        if (entity == null)
        {
            // 削除対象が存在しない場合はfalseを返す
            return false;
        }
        // 削除する
        _context.Departments.Remove(entity);
        _context.SaveChanges();
        // 削除が成功したらtrueを返す
        return true;
    }

    public List<Department> FindAll()
    {
        return _context.Departments
            .AsNoTracking()
            .ToList()
            .Select(ToDomain)
            .ToList();
    }

    public Department? FindById(int id)
    {
        var entity = _context.Departments
           .Find(id);

        return entity is null ? null : ToDomain(entity);
    }

    public bool UpdateById(Department department)
    {
        // 部署Idで変更対象部署を取得する
        var entity = _context.Departments
            .SingleOrDefault(i => i.Id == department.Id);
        if (entity == null)
        {
            // 変更対象部署が見つからない場合はfalseを返す
            return false;
        }
        // 部署名を変更してデータベースに反映させる
        entity!.Name = department.Name!;
        _context.Departments.Update(entity);
        _context.SaveChanges();
        // 変更が成功したらtrueを返す
        return true;
    }

    private static Department ToDomain(DepartmentEntity source)
    {
        var employees = source.Employees?
            .Select(employee => new Employee(employee.Id, employee.Name, null))
            .ToList();

        return new Department(source.Id, source.Name, employees);
    }

    private static DepartmentEntity ToEntity(Department department)
    {
        return new DepartmentEntity
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}
