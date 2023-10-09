using Jazani.Api.Exceptions;
using Jazani.Application.Mcs.Dtos.InvestmentTypes;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    public class InvestmentTypeController : Controller
    {
        private readonly IInvestmentTypeService _investmentTypeService;

        public InvestmentTypeController(IInvestmentTypeService investmentTypeService)
        {
            _investmentTypeService = investmentTypeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<InvestmentTypeDto>> Get()
        {
            return await _investmentTypeService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentTypeDto>>> Get(int id)
        {
            var response = await _investmentTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentTypeDto>>> Post([FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            var response = await _investmentTypeService.CreateAsync(investmentTypeSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<InvestmentTypeDto> Put(int id, [FromBody] InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            return await _investmentTypeService.EditAsync(id, investmentTypeSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<InvestmentTypeDto> Delete(int id)
        {
            return await _investmentTypeService.DisabledAsync(id);
        }
    }
}
