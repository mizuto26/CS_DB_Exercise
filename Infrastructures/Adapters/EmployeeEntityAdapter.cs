using CS_DB_Exercise.Domains.Adapters;
using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Infrastructures.Entities;
namespace CS_DB_Exercise.Infrastructures.Adapters;

public class EmployeeEntityAdapter : IEmployeeAdapter<EmployeeEntity>
{
    public Employee ToDomain(EmployeeEntity source)
    {
        ArgumentNullException.ThrowIfNull(source);
        Department? department = null;
        // 部署がnulでない
        if (source.Department != null)
        {
            // 所属部署を生成する
            department = new Department(source.Department.Id, source.Department.Name, null);
        }
        // 社員を生成して返す
        var employee = new Employee(source.Id, source.Name, department);
        return employee;
    }

    public List<Employee> ToDomainList(List<EmployeeEntity> sources)
    {
        ArgumentNullException.ThrowIfNull(sources);
        // Employeeのリストを生成する
        var employees = new List<Employee>();
        // EmployeeEntirtyのリストからEmployeeのリストへ変換する
        foreach (var source in sources)
        {
            employees.Add(ToDomain(source));
        }
        return employees;
    }

    public EmployeeEntity FromDomain(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        // EmployeeEntityを生成する
        var entity = new EmployeeEntity
        {
            Id = employee.Id,
            Name = employee.Name,
            DeptId = employee.Department!.Id
        };
        return entity;
    }

    public List<EmployeeEntity> FromDomainList(List<Employee> employees)
    {
        ArgumentNullException.ThrowIfNull(employees);
        // EmployeeEntityのリストを生成する
        var entities = new List<EmployeeEntity>();
        // EmployeeのリストからEmployeeEntityのリストへ変換する
        foreach (var employee in employees)
        {
            entities.Add(FromDomain(employee));
        }
        return entities;
    }
}