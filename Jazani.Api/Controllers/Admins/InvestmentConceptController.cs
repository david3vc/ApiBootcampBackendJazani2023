using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.InvestmentConcepts;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class InvestmentConceptController : Controller
    {
        private readonly IInvestmentConceptService _investmentConceptService;

        public InvestmentConceptController(IInvestmentConceptService investmentConceptService)
        {
            _investmentConceptService = investmentConceptService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<InvestmentConceptDto>> Get()
        {
            return await _investmentConceptService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentConceptDto>>> Get(int id)
        {
            var response = await _investmentConceptService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentConceptDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentConceptDto>>> Post([FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            var response = await _investmentConceptService.CreateAsync(investmentConceptSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<InvestmentConceptDto> Put(int id, [FromBody] InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            return await _investmentConceptService.EditAsync(id, investmentConceptSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<InvestmentConceptDto> Delete(int id)
        {
            return await _investmentConceptService.DisabledAsync(id);
        }
    }
}
