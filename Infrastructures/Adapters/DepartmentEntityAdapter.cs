using CS_DB_Exercise.Domains.Adapters;
using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Infrastructures.Entities;
namespace CS_DB_Exercise.Infrastructures.Adapters;

public class DepartmentEntityAdapter(IEmployeeAdapter<EmployeeEntity> adapter) : IDepartmentAdapter<DepartmentEntity>
{
    private readonly IEmployeeAdapter<EmployeeEntity> _adapter = adapter;

    public Department ToDomain(DepartmentEntity source)
    {
        ArgumentNullException.ThrowIfNull(source);
        List<Employee>? employees = null;
        // 所属社員が存在する
        if (source.Employees != null)
        {
            // EmployeeEntityのリストからEmployeeのリストへ変換する
            employees = new List<Employee>();
            foreach (var employee in source.Employees)
            {
                employees.Add(_adapter.ToDomain(employee));
            }
        }
        // 部署を生成して返す
        var department = new Department(source.Id, source.Name, employees);
        return department;
    }

    public List<Department> ToDomainList(List<DepartmentEntity> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);
        var departments = new List<Department>();
        foreach (var department in sources)
        {
            departments.Add(ToDomain(department));
        }
        return departments;
    }

    public DepartmentEntity FromDomain(Department department)
    {
        ArgumentNullException.ThrowIfNull(department);
        // DepartmentEntityを生成する
        var entity = new DepartmentEntity
        {
            Id = department.Id,
            Name = department.Name,
        };
        return entity;
    }

    public List<DepartmentEntity> FromDomainList(List<Department> departments)
    {
        ArgumentNullException.ThrowIfNull(departments);
        // DepartmentEntityのリストを生成する
        var entities = new List<DepartmentEntity>();
        // DepertmentのリストからDepartmentEntityのリストへ変換する
        foreach (var department in departments)
        {
            entities.Add(FromDomain(department));
        }
        return entities;
    }
}