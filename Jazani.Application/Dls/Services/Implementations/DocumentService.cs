using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Dls.Dtos.Documents;
using Jazani.Domain.Dls.Models;
using Jazani.Domain.Dls.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Dls.Services.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, IMapper mapper, ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DocumentDto> CreateAsync(DocumentSaveDto documentSaveDto)
        {
            Document document = _mapper.Map<Document>(documentSaveDto);
            document.RegistrationDate = DateTime.Now;
            document.State = true;

            Document documentSaved = await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(documentSaved);
        }

        public async Task<DocumentDto> DisabledAsync(int id)
        {
            Document document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                _logger.LogWarning("Documento no encontrado para el id: " + id);
                throw DocumentNotFound(id);
            }

            document.State = false;

            Document documentSaved = await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(documentSaved);
        }

        public async Task<DocumentDto> EditAsync(int id, DocumentSaveDto documentSaveDto)
        {
            Document document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                _logger.LogWarning("Documento no encontrado para el id: " + id);
                throw DocumentNotFound(id);
            }

            _mapper.Map(documentSaveDto, document);

            Document documentSaved = await _documentRepository.SaveAsync(document);

            return _mapper.Map<DocumentDto>(documentSaved);
        }

        public async Task<IReadOnlyList<DocumentDto>> FindAllAsync()
        {
            IReadOnlyList<Document> documents = await _documentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<DocumentDto>>(documents);
        }

        public async Task<DocumentDto> FindByIdAsync(int id)
        {
            Document? document = await _documentRepository.FindByIdAsync(id);

            if (document is null)
            {
                _logger.LogWarning("Documento no encontrado para el id: " + id);
                throw DocumentNotFound(id);
            }

            return _mapper.Map<DocumentDto>(document);
        }

        private NotFoundCoreException DocumentNotFound(int id)
        {
            return new NotFoundCoreException("Documento no encontrado para el id: " + id);
        }
    }
}