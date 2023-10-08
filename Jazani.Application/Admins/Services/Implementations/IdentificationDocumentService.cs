using AutoMapper;
using Jazani.Application.Admins.Dtos.IdentificationDocuments;
using Jazani.Application.Mcs.Services.Implementations;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class IdentificationDocumentService : IIdentificationDocumentService
    {
        private readonly IIdentificationDocumentRepository _identificationDocumentRepository;
        private readonly IMapper _mapper;

        public IdentificationDocumentService(IIdentificationDocumentRepository identificationDocumentRepository, IMapper mapper)
        {
            _identificationDocumentRepository = identificationDocumentRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<IdentificationDocumentDto>> FindAllAsync()
        {
            IReadOnlyList<IdentificationDocument> identificationDocuments = await _identificationDocumentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<IdentificationDocumentDto>>(identificationDocuments);
        }

        public async Task<IdentificationDocumentDto?> FindByIdAsync(int id)
        {
            IdentificationDocument? identificationDocument = await _identificationDocumentRepository.FindByIdAsync(id);

            return _mapper.Map<IdentificationDocumentDto>(identificationDocument);
        }

        public async Task<IdentificationDocumentDto> CreateAsync(IdentificationDocumentSaveDto identificationDocumentSaveDto)
        {
            IdentificationDocument identificationDocument = _mapper.Map<IdentificationDocument>(identificationDocumentSaveDto);
            identificationDocument.RegistrationDate = DateTime.Now;
            identificationDocument.State = true;

            IdentificationDocument identificationDocumentSaved = await _identificationDocumentRepository.SaveAsync(identificationDocument);

            return _mapper.Map<IdentificationDocumentDto>(identificationDocumentSaved);
        }

        public async Task<IdentificationDocumentDto> EditAsync(int id, IdentificationDocumentSaveDto identificationDocumentSaveDto)
        {
            IdentificationDocument identificationDocument = await _identificationDocumentRepository.FindByIdAsync(id);

            _mapper.Map<IdentificationDocumentSaveDto, IdentificationDocument>(identificationDocumentSaveDto, identificationDocument);

            IdentificationDocument identificationDocumentSaved = await _identificationDocumentRepository.SaveAsync(identificationDocument);

            return _mapper.Map<IdentificationDocumentDto>(identificationDocumentSaved);
        }

        public async Task<IdentificationDocumentDto> DisabledAsync(int id)
        {
            IdentificationDocument identificationDocument = await _identificationDocumentRepository.FindByIdAsync(id);
            identificationDocument.State = false;

            IdentificationDocument identificationDocumentSaved = await _identificationDocumentRepository.SaveAsync(identificationDocument);

            return _mapper.Map<IdentificationDocumentDto>(identificationDocumentSaved);
        }
    }
}
