using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.PersonTypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    public class PersonTypeController : Controller
    {
        private readonly IPersonTypeService _personTypeService;

        public PersonTypeController(IPersonTypeService personTypeService)
        {
            _personTypeService = personTypeService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<PersonTypeDto>> Get()
        {
            return await _personTypeService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<PersonTypeDto>>> Get(int id)
        {
            var response = await _personTypeService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
