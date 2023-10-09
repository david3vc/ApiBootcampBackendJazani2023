using Jazani.Api.Exceptions;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mcs
{
    [Route("api/[controller]")]
    public class InvestmentController : Controller
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<InvestmentDto>>> Get(int id)
        {
            var response = await _investmentService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto investmentSaveDto)
        {
            var response = await _investmentService.CreateAsync(investmentSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto investmentSaveDto)
        {
            return await _investmentService.EditAsync(id, investmentSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _investmentService.DisabledAsync(id);
        }
    }
}
