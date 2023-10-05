using Jazani.Application.Admins.Dtos.Employees;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            return await _employeeService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<EmployeeDto> Get(int id)
        {
            return await _employeeService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<EmployeeDto> Post([FromBody] EmployeeSaveDto employeeSaveDto)
        {
            return await _employeeService.CreateAsync(employeeSaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<EmployeeDto> Put(int id, [FromBody] EmployeeSaveDto employeeSaveDto)
        {
            return await _employeeService.EditAsync(id, employeeSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<EmployeeDto> Delete(int id)
        {
            return await _employeeService.DisabledAsync(id);
        }
    }
}
