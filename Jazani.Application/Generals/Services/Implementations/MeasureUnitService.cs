using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MeasureUnitService> _logger;

        public MeasureUnitService(IMeasureUnitRepository measureUnitRepository, IMapper mapper, ILogger<MeasureUnitService> logger)
        {
            _measureUnitRepository = measureUnitRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(measureUnitSaveDto);
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id: " + id);
                throw MeasureUnitNotFound(id);
            }

            measureUnit.State = false;

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto measureUnitSaveDto)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id: " + id);
                throw MeasureUnitNotFound(id);
            }

            _mapper.Map(measureUnitSaveDto, measureUnit);

            MeasureUnit measureUnitSaved = await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnitSaved);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto> FindByIdAsync(int id)
        {
            MeasureUnit? measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            if (measureUnit is null)
            {
                _logger.LogWarning("Unidad de medida no encontrado para el id: " + id);
                throw MeasureUnitNotFound(id);
            }

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        private NotFoundCoreException MeasureUnitNotFound(int id)
        {
            return new NotFoundCoreException("Unidad de medida no encontrado para el id: " + id);
        }
    }
}
