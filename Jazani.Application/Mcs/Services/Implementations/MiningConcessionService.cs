using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.MiningConcessions;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningConcessionService> _logger;

        public MiningConcessionService(IMiningConcessionRepository miningConcessionRepository, IMapper mapper, ILogger<MiningConcessionService> logger)
        {
            _miningConcessionRepository = miningConcessionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto miningConcessionSaveDto)
        {
            MiningConcession miningConcession = _mapper.Map<MiningConcession>(miningConcessionSaveDto);
            miningConcession.RegistrationDate = DateTime.Now;
            miningConcession.State = true;

            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);

            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<MiningConcessionDto> DisabledAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (miningConcession is null)
            {
                _logger.LogWarning("Concesion minera no encontrado para el id: " + id);
                throw MiningConcessionNotFound(id);
            }

            miningConcession.State = false;

            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);

            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto miningConcessionSaveDto)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (miningConcession is null)
            {
                _logger.LogWarning("Concesion minera no encontrado para el id: " + id);
                throw MiningConcessionNotFound(id);
            }

            _mapper.Map(miningConcessionSaveDto, miningConcession);

            MiningConcession miningConcessionSaved = await _miningConcessionRepository.SaveAsync(miningConcession);

            return _mapper.Map<MiningConcessionDto>(miningConcessionSaved);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> miningConcessions = await _miningConcessionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(miningConcessions);
        }

        public async Task<MiningConcessionDto> FindByIdAsync(int id)
        {
            MiningConcession? miningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            if (miningConcession is null)
            {
                _logger.LogWarning("Concesion minera no encontrado para el id: " + id);
                throw MiningConcessionNotFound(id);
            }

            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        private NotFoundCoreException MiningConcessionNotFound(int id)
        {
            return new NotFoundCoreException("Concesion minera no encontrado para el id: " + id);
        }
    }
}
