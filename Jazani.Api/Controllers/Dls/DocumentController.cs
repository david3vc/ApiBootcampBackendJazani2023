using Jazani.Api.Exceptions;
using Jazani.Application.Dls.Dtos.Documents;
using Jazani.Application.Dls.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Dls
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<DocumentDto>> Get()
        {
            return await _documentService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<DocumentDto>>> Get(int id)
        {
            var response = await _documentService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DocumentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<DocumentDto>>> Post([FromBody] DocumentSaveDto documentSaveDto)
        {
            var response = await _documentService.CreateAsync(documentSaveDto);
            return TypedResults.CreatedAtRoute(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<DocumentDto> Put(int id, [FromBody] DocumentSaveDto documentSaveDto)
        {
            return await _documentService.EditAsync(id, documentSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<DocumentDto> Delete(int id)
        {
            return await _documentService.DisabledAsync(id);
        }
    }
}
