using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Domain.Socs.Models;
using Jazani.Domain.Socs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Socs.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HolderService> _logger;

        public HolderService(IHolderRepository holderRepository, IMapper mapper, ILogger<HolderService> logger)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);
        }

        public async Task<HolderDto> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null)
            {
                _logger.LogWarning("Holder no encontrado para el id: " + id);
                throw HolderNotFound(id);
            }

            return _mapper.Map<HolderDto>(holder);
        }

        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Holder no encontrado para el id: " + id);
        }
    }
}
