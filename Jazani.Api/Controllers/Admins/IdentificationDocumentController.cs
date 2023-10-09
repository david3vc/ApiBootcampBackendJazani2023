using Jazani.Application.Admins.Dtos.IdentificationDocuments;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class IdentificationDocumentController : Controller
    {
        private readonly IIdentificationDocumentService _identificationDocumentService;

        public IdentificationDocumentController(IIdentificationDocumentService identificationDocumentService)
        {
            _identificationDocumentService = identificationDocumentService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<IdentificationDocumentDto>> Get()
        {
            return await _identificationDocumentService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IdentificationDocumentDto> Get(int id)
        {
            return await _identificationDocumentService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IdentificationDocumentDto> Post([FromBody] IdentificationDocumentSaveDto identificationDocumentSaveDto)
        {
            return await _identificationDocumentService.CreateAsync(identificationDocumentSaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IdentificationDocumentDto> Put(int id, [FromBody] IdentificationDocumentSaveDto identificationDocumentSaveDto)
        {
            return await _identificationDocumentService.EditAsync(id, identificationDocumentSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IdentificationDocumentDto> Delete(int id)
        {
            return await _identificationDocumentService.DisabledAsync(id);
        }
    }
}
