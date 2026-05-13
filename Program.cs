using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures.Queries;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        var context = new AppDbContext();
        var employeeAccessor = new EmployeeAccessor(context);

        Console.WriteLine("社員Idを入力してください->");
        int employee_id = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-11 指定された社員Idの社員を削除する");

        var result = employeeAccessor.DeleteById(id: employee_id);

        if (result == null)
        {
            Console.WriteLine($"社員Id:{employee_id}の社員は存在しないため削除できませんでした");
        }
        else
        {
            Console.WriteLine($"社員Id:{employee_id}の社員を削除しました");
        }
    }
}
