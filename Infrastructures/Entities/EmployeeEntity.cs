using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("employee")]
public class EmployeeEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("dept_id")]
    public int DeptId { get; set; }

    public DepartmentEntity? Department { get; set; }

    public override string ToString()
    {
        return $"社員id={Id} , 社員名={Name} , 部署Id={DeptId}";
    }
}
