using CS_DB_Exercise.Domains.Models;
using CS_DB_Exercise.Domains.Repositories;

namespace CS_DB_Exercise.Application;

public sealed class FindEmployeeDepartmentUseCase(IEmployeeRepository employeeRepository)
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public Employee? Execute(string name) =>
        _employeeRepository.FindByNameContainsWithDepartment(name);
}
