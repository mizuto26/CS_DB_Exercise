using CS_DB_Exercise.Domains.Adapters;
using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Domains.Repositories;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
namespace CS_DB_Exercise.Infrastructures.Repositories;

public class DepartmentRepository(
    AppDbContext context, IDepartmentAdapter<DepartmentEntity> adapter) : IDepartmentRepository
{
    private readonly AppDbContext _context = context;
    private readonly IDepartmentAdapter<DepartmentEntity> _adapter = adapter;

    public void Create(Department department)
    {
        // DepartmentからDepartmentEntityへ変換する
        var entity = _adapter.FromDomain(department);
        // 部署を追加して永続化する
        _context.Add(entity);
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
        // すべての部署を取得する
        var entities = _context.Departments
            .AsNoTracking()
            .ToList();
        // DepartmentEntityのリストをDepartmentのリストに変換して返す
        var departments = _adapter.ToDomainList(entities);
        return departments;
    }

    public Department? FindById(int id)
    {
        // 部署Idで部署を取得する
        var entity = _context.Departments
           .Find(id);
        // 取得できない場合はnullを返す
        if (entity == null)
        {
            return null;
        }
        // DepartmentEntityをDepartmentに変換して返す
        var department = _adapter.ToDomain(entity!);
        return department;
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
}