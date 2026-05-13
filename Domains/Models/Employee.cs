using CS_DB_Exercise.Domains.Exceptions;
namespace CS_DB_Exercise.Domains.Models;

public class Employee : IEquatable<Employee>
{
    public int Id { get; private set; } = 0;
    public string? Name { get; private set; } = string.Empty;
    public Department? Department { get; private set; }

    public Employee(int id, string? name, Department? department)
    {
        Id = id;
        ChangeName(name);
        ChangeDepartment(department);
    }

    public Employee(string? name, Department? department) : this(0, name, department) { }
    public Employee(string? name) : this(0, name, null) { }

    public void ChangeName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("社員名は必須です。");
        if (name.Length > 20)
        {
            throw new DomainException("社員名は20文字以内です。");
        }
        Name = name;
    }

    public void ChangeDepartment(Department? department)
    {
        Department = department;
    }

    public bool Equals(Employee? other)
    {
        if (other is null) return false;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Employee);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string? ToString()
    {
        return $"社員Id:{Id}, 社員名:{Name}, 所属部署:{Department}";
    }
}
