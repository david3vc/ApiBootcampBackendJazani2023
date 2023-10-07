using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Minerals;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MineralService : IMineralService
    {
        private readonly IMineralRepository _mineralRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MineralService> _logger;

        public MineralService(IMapper mapper, IMineralRepository mineralRepository, ILogger<MineralService> logger)
        {
            _mapper = mapper;
            _mineralRepository = mineralRepository;
            _logger = logger;
        }

        public async Task<IReadOnlyList<MineralDto>> FindAllAsync()
        {
            IReadOnlyList<Mineral> minerals = await _mineralRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MineralDto>>(minerals);
        }

        public async Task<MineralDto?> FindByIdAsync(int id)
        {
            Mineral? mineral = await _mineralRepository.FindByIdAsync(id);

            if (mineral is null)
            {
                _logger.LogWarning("Tipo de mineral no encontrado para el id: " + id);
                throw MineralTypeNotFound(id);
            }

            return _mapper.Map<MineralDto>(mineral);
        }

        public async Task<MineralDto> CreateAsync(MineralSaveDto mineralSaveDto)
        {
            Mineral mineral = _mapper.Map<Mineral>(mineralSaveDto);
            mineral.RegistrationDate = DateTime.Now;
            mineral.State = true;

            Mineral mineralSaved = await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineralSaved);
        }

        public async Task<MineralDto> EditAsync(int id, MineralSaveDto mineralSaveDto)
        {
            Mineral mineral = await _mineralRepository.FindByIdAsync(id);

            if (mineral is null) throw MineralTypeNotFound(id);

            _mapper.Map<MineralSaveDto, Mineral>(mineralSaveDto, mineral);

            Mineral mineralSaved = await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineralSaved);
        }

        public async Task<MineralDto> DisabledAsync(int id)
        {
            Mineral mineral = await _mineralRepository.FindByIdAsync(id);

            if (mineral is null) throw MineralTypeNotFound(id);

            mineral.State = false;

            Mineral mineralSaved = await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineralSaved);
        }

        private NotFoundCoreException MineralTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de mineral no encontrado para el id: " + id);
        }
    }
}
