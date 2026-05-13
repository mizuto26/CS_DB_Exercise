using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("department")]
public class DepartmentEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    public List<EmployeeEntity>? Employees { get; set; }

    public override string ToString()
    {
        return $"id = {Id}, name = {Name}";
    }
}
