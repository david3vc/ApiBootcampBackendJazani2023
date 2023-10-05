using Jazani.Application.Generals.Dtos.Minerals;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MineralController : Controller
    {
        private readonly IMineralService _mineralService;

        public MineralController(IMineralService mineralService)
        {
            _mineralService = mineralService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<MineralDto>> Get()
        {
            return await _mineralService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<MineralDto> Get(int id)
        {
            return await _mineralService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<MineralDto> Post([FromBody] MineralSaveDto mineralSaveDto)
        {
            return await _mineralService.CreateAsync(mineralSaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<MineralDto> Put(int id, [FromBody] MineralSaveDto mineralSaveDto)
        {
            return await _mineralService.EditAsync(id, mineralSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<MineralDto> Delete(int id)
        {
            return await _mineralService.DisabledAsync(id);
        }
    }
}
