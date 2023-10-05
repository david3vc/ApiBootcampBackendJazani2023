using Jazani.Application.Admins.Dtos.Employees;

namespace Jazani.Application.Admins.Services
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<EmployeeDto>> FindAllAsync();
        Task<EmployeeDto?> FindByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(EmployeeSaveDto employeeSaveDto);
        Task<EmployeeDto> EditAsync(int id, EmployeeSaveDto employeeSaveDto);
        Task<EmployeeDto> DisabledAsync(int id);
    }
}
