using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class PeriodTypeController : Controller
    {
        private readonly IPeriodTypeService _periodTypeService;

        public PeriodTypeController(IPeriodTypeService periodTypeService)
        {
            _periodTypeService = periodTypeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PeriodTypeDto>> Get()
        {
            return await _periodTypeService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PeriodTypeDto>>> Get(int id)
        {
            var response = await _periodTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<PeriodTypeDto>>> Post([FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            var response = await _periodTypeService.CreateAsync(periodTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<PeriodTypeDto> Put(int id, [FromBody] PeriodTypeSaveDto periodTypeSaveDto)
        {
            return await _periodTypeService.EditAsync(id, periodTypeSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<PeriodTypeDto> Delete(int id)
        {
            return await _periodTypeService.DisabledAsync(id);
        }
    }
}
