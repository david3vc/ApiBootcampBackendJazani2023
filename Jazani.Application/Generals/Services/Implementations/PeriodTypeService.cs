using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PeriodTypeService> _logger;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper, ILogger<PeriodTypeService> logger)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto periodTypeSaveDto)
        {
            PeriodType periodType = _mapper.Map<PeriodType>(periodTypeSaveDto);
            periodType.RegistrationDate = DateTime.Now;
            periodType.State = true;

            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<PeriodTypeDto> DisabledAsync(int id)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null)
            {
                _logger.LogWarning("Tipo de periodo no encontrado para el id: " + id);
                throw PeriodTypeNotFound(id);
            }

            periodType.State = false;

            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto periodTypeSaveDto)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null)
            {
                _logger.LogWarning("Tipo de periodo no encontrado para el id: " + id);
                throw PeriodTypeNotFound(id);
            }

            _mapper.Map(periodTypeSaveDto, periodType);

            PeriodType periodTypeSaved = await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodTypeSaved);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> periodTypes = await _periodTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(periodTypes);
        }

        public async Task<PeriodTypeDto> FindByIdAsync(int id)
        {
            PeriodType? periodType = await _periodTypeRepository.FindByIdAsync(id);

            if (periodType is null)
            {
                _logger.LogWarning("Tipo de periodo no encontrado para el id: " + id);
                throw PeriodTypeNotFound(id);
            }

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        private NotFoundCoreException PeriodTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de periodo no encontrado para el id: " + id);
        }
    }
}
