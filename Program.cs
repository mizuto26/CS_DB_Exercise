using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var accessor = new EmployeeAccessor(new AppDbContext());

        Console.WriteLine("部署Idを入力してください->");
        int dept_id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-07 employeeテーブルから部署Idで該当社員を取得する");

        var employee = accessor.FindByDeptId(dept_id);
        if (employee == null)
        {
            Console.WriteLine($"部署Id:{dept_id}の部署に所属する社員は存在しません");
        }
        else
        {
            Console.WriteLine($"{employee!.ToString()}");
        }
    }
}
