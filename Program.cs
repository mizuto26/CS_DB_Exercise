using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();
        var departmentAccessor = new DepartmentAccessor(context);

        Console.WriteLine("部署Idを入力してください->");
        int id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-14 指定された部署Idの部署と所属社員を取得する");

        var result = departmentAccessor.FindByIdJoinEmployee(id: id);

        if (result == null)
        {
            Console.WriteLine($"部署Id:{id}の部署は存在しませんでした");
        }
        else
        {
            Console.WriteLine(result.ToString());
            foreach (var employee in result.Employees!)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
