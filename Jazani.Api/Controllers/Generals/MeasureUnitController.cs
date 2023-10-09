using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class MeasureUnitController : Controller
    {
        private readonly IMeasureUnitService _measureUnitService;

        public MeasureUnitController(IMeasureUnitService measureUnitService)
        {
            _measureUnitService = measureUnitService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            return await _measureUnitService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<MeasureUnitDto>>> Get(int id)
        {
            var response = await _measureUnitService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureUnitDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureUnitDto>>> Post([FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            var response = await _measureUnitService.CreateAsync(measureUnitSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<MeasureUnitDto> Put(int id, [FromBody] MeasureUnitSaveDto measureUnitSaveDto)
        {
            return await _measureUnitService.EditAsync(id, measureUnitSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<MeasureUnitDto> Delete(int id)
        {
            return await _measureUnitService.DisabledAsync(id);
        }
    }
}
