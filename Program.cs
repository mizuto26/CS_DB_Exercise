using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new DepartmentAccessor(new AppDbContext());

        var departments = accessor.FindAll();
        Console.WriteLine("すべての部署を取得する");
        foreach (var d in departments)
        {
            Console.WriteLine(d);
        }

        var department = accessor.FindById(1);
        Console.WriteLine($"存在する部署Id:{department!.ToString()}");

        department = accessor.FindById(101);
        if (department == null)
        {
            Console.WriteLine($"部署Id:101の部署は存在しません。");
        }
    }
}
