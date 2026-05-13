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
        var accessor = new EmployeeAccessor(context);

        Console.WriteLine("社員名を入力してください->");
        string name = Console.ReadLine()!;

        var employee = accessor.FindByNameContainsJoinDepartment(name: name);

        if (employee == null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            Console.WriteLine($"{employee!.Name}さんは、{employee.Department!.Name}に所属する社員です。");
        }
    }
}
