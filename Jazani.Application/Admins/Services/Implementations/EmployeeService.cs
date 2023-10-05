using AutoMapper;
using Jazani.Application.Admins.Dtos.Employees;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeDto>> FindAllAsync()
        {
            IReadOnlyList<Employee> employees = await _employeeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> FindByIdAsync(int id)
        {
            Employee? employee = await _employeeRepository.FindByIdAsync(id);

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeSaveDto employeeSaveDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeSaveDto);
            employee.RegistrationDate = DateTime.Now;
            employee.State = true;
            employee.IsSincronized = true;

            Employee employeeSaved = await _employeeRepository.SaveAsync(employee);

            return _mapper.Map<EmployeeDto>(employeeSaved);
        }

        public async Task<EmployeeDto> EditAsync(int id, EmployeeSaveDto employeeSaveDto)
        {
            Employee employee = await _employeeRepository.FindByIdAsync(id);

            _mapper.Map<EmployeeSaveDto, Employee>(employeeSaveDto, employee);

            Employee employeeSaved = await _employeeRepository.SaveAsync(employee);

            return _mapper.Map<EmployeeDto>(employeeSaved);
        }

        public async Task<EmployeeDto> DisabledAsync(int id)
        {
            Employee employee = await _employeeRepository.FindByIdAsync(id);
            employee.State = false;

            Employee employeeSaved = await _employeeRepository.SaveAsync(employee);

            return _mapper.Map<EmployeeDto>(employeeSaved);
        }
    }
}
