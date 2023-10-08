using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Jazani.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MineralTypeController : Controller
    {
        private readonly IMineralTypeService _mineralTypeService;

        public MineralTypeController(IMineralTypeService mineralTypeService)
        {
            _mineralTypeService = mineralTypeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<MineralTypeDto>> Get()
        {
            return await _mineralTypeService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MineralTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MineralTypeDto>>> Get(int id)
        {
            var response = await _mineralTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MineralTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MineralTypeDto>>> Post([FromBody] MineralTypeSaveDto mineralTypeSaveDto)
        {
            var response = await _mineralTypeService.CreateAsync(mineralTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<MineralTypeDto> Put(int id, [FromBody] MineralTypeSaveDto mineralTypeSaveDto)
        {
            return await _mineralTypeService.EditAsync(id, mineralTypeSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<MineralTypeDto> Delete(int id)
        {
            return await _mineralTypeService.DisabledAsync(id);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<MineralTypeDto>> PaginatedSearch([FromQuery] RequestPagination<MineralTypeDto> request)
        {
            return await _mineralTypeService.PaginationSearch(request);
        }
    }
}
