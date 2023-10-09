using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Socs.Dtos.Holders;
using Jazani.Domain.Socs.Models;
using Jazani.Domain.Socs.Repositories;

namespace Jazani.Application.Socs.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;

        public HolderService(IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holders = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holders);
        }

        public async Task<HolderDto> FindByIdAsync(int id)
        {
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            if (holder is null) throw HolderNotFound(id);

            return _mapper.Map<HolderDto>(holder);
        }

        private NotFoundCoreException HolderNotFound(int id)
        {
            return new NotFoundCoreException("Holder no encontrado para el id: " + id);
        }
    }
}
