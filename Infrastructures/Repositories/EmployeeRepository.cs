using CS_DB_Exercise.Domains.Adapters;
using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Domains.Repositories;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.Infrastructures.Repositories;

public class EmployeeRepository(
    AppDbContext context, IEmployeeAdapter<EmployeeEntity> adapter) : IEmployeeRepository
{
    private readonly AppDbContext _context = context;
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter = adapter;

    public void Create(Employee employee)
    {
        // EmployeeからEmployeeEntityへ変換する
        var entity = _adapter.FromDomain(employee);
        // 社員を追加して永続化する
        _context.Add(entity);
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
        // すべての社員を取得する
        var entities = _context.Employees
            .AsNoTracking()
            .ToList();
        // EmployeeEntityのリストをEmployeeのリストに変換して返す
        var employees = _adapter.ToDomainList(entities);
        return employees;
    }

    public Employee? FindById(int id)
    {
        // 社員Idで社員を取得する
        var entity = _context.Employees.Find(id);
        // 取得できない場合はnullを返す
        if (entity == null)
        {
            return null;
        }
        // EmployeeEntityをEmployeeに変換して返す
        var employee = _adapter.ToDomain(entity!);
        return employee;
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
}