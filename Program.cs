using CS_DB_Exercise.Application;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        var regiterDepartment = new RegiterDepartment(context);
        var departmentAccessor = new DepartmentAccessor(context);

        Console.WriteLine("新しい部署名を入力してください->");
        string name = Console.ReadLine()!;

        var departmentEntity = new DepartmentEntity { Name = name };
        regiterDepartment.Register(departmentEntity);

        var departments = departmentAccessor.FindAll();
        foreach (var department in departments)
        {
            Console.WriteLine($"{department.ToString()}");
        }
    }
}
