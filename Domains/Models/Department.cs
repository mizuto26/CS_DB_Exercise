using CS_DB_Exercise.Domains.Exceptions;
namespace CS_DB_Exercise.Domains.Models;

public class Department : IEquatable<Department>
{
    public int Id { get; private set; } = 0;
    public string? Name { get; private set; } = string.Empty;
    public List<Employee>? Employees { get; private set; }

    public Department(int id, string? name, List<Employee>? employees)
    {
        Id = id;
        ChangeName(name!);
        ChangeEmployees(employees);
    }

    public Department(string? name, List<Employee>? employees) : this(0, name, employees) { }
    public Department(string? name) : this(0, name, null) { }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("部署名は必須です。");
        if (name.Length > 20)
        {
            throw new DomainException("部署名は20文字以内です。");
        }
        Name = name;
    }

    public void ChangeEmployees(List<Employee>? employees)
    {
        Employees = employees;
    }

    public bool Equals(Department? other)
    {
        if (other is null) return false;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Department);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string? ToString()
    {
        return $"部署Id:{Id}, 部署名:{Name}, 部署に所属する社員:{Employees}";
    }
}
