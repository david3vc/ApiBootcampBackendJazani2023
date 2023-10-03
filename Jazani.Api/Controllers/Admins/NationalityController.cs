using Jazani.Application.Admins.Dtos.Nationalities;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class NationalityController : Controller
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<NationalityDto>> Get()
        {
            return await _nationalityService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<NationalityDto> Get(int id)
        {
            return await _nationalityService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<NationalityDto> Post([FromBody] NationalitySaveDto nationalitySaveDto)
        {
            return await _nationalityService.CreateAsync(nationalitySaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<NationalityDto> Put(int id, [FromBody] NationalitySaveDto nationalitySaveDto)
        {
            return await _nationalityService.EditAsync(id, nationalitySaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<NationalityDto> Delete(int id)
        {
            return await _nationalityService.DisabledAsync(id);
        }
    }
}
