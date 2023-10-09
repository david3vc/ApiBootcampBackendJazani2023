using Jazani.Api.Exceptions;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Application.Socs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Socs
{
    [Route("api/[controller]")]
    public class HolderController : Controller
    {
        private readonly IHolderService _holderService;

        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HolderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<HolderDto>>> Get(int id)
        {
            var response = await _holderService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
