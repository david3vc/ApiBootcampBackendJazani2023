using Jazani.Application.Admins.Dtos.CivilStatuses;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class CivilStatusController : Controller
    {
        private readonly ICivilStatusService _civilStatusService;

        public CivilStatusController(ICivilStatusService civilStatusService)
        {
            _civilStatusService = civilStatusService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CivilStatusDto>> Get()
        {
            return await _civilStatusService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<CivilStatusDto> Get(int id)
        {
            return await _civilStatusService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<CivilStatusDto> Post([FromBody] CivilStatusSaveDto civilStatusSaveDto)
        {
            return await _civilStatusService.CreateAsync(civilStatusSaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<CivilStatusDto> Put(int id, [FromBody] CivilStatusSaveDto civilStatusSaveDto)
        {
            return await _civilStatusService.EditAsync(id, civilStatusSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<CivilStatusDto> Delete(int id)
        {
            return await _civilStatusService.DisabledAsync(id);
        }
    }
}
