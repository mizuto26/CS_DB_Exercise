using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructures.Entities;

[Table("employee")]
public class EmployeeEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("dept_id")]
    public int DeptId { get; set; }

    public override string ToString()
    {
        return $"id = {Id}, name = {Name}, dept_id = {DeptId}";
    }
}
