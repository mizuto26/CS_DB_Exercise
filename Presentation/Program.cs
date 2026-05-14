using CS_DB_Exercise.Application;
using CS_DB_Exercise.Infrastructures.Contexts;
using CS_DB_Exercise.Infrastructures.Repositories;

namespace CS_DB_Exercise;

internal static class Program
{
    private static void Main()
    {
        using var context = new AppDbContext();
        var employeeRepository = new EmployeeRepository(context);
        var findEmployeeDepartmentUseCase = new FindEmployeeDepartmentUseCase(employeeRepository);

        Console.WriteLine("社員名を入力してください->");
        var name = Console.ReadLine() ?? string.Empty;

        var result = findEmployeeDepartmentUseCase.Execute(name);

        if (result?.Department is null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            Console.WriteLine($"{result.Name}さんは、{result.Department.Name}に所属する社員です。");
        }
    }
}
