using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.InvestmentTypes;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class InvestmentTypeService : IInvestmentTypeService
    {
        private readonly IInvestmentTypeRepository _investmentTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentTypeService> _logger;

        public InvestmentTypeService(IInvestmentTypeRepository investmentTypeRepository, IMapper mapper, ILogger<InvestmentTypeService> logger)
        {
            _investmentTypeRepository = investmentTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentTypeDto> CreateAsync(InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            InvestmentType investmentType = _mapper.Map<InvestmentType>(investmentTypeSaveDto);
            investmentType.RegistrationDate = DateTime.Now;
            investmentType.State = true;

            InvestmentType investmentTypeSaved = await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentTypeSaved);
        }

        public async Task<InvestmentTypeDto> DisabledAsync(int id)
        {
            InvestmentType investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null)
            {
                _logger.LogWarning("Tipo de inversión no encontrado para el id: " + id);
                throw InvestmentTypeNotFound(id);
            }

            investmentType.State = false;

            InvestmentType investmentTypeSaved = await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentTypeSaved);
        }

        public async Task<InvestmentTypeDto> EditAsync(int id, InvestmentTypeSaveDto investmentTypeSaveDto)
        {
            InvestmentType investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null)
            {
                _logger.LogWarning("Tipo de inversión no encontrado para el id: " + id);
                throw InvestmentTypeNotFound(id);
            }

            _mapper.Map(investmentTypeSaveDto, investmentType);

            InvestmentType investmentTypeSaved = await _investmentTypeRepository.SaveAsync(investmentType);

            return _mapper.Map<InvestmentTypeDto>(investmentTypeSaved);
        }

        public async Task<IReadOnlyList<InvestmentTypeDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentType> investmentTypes = await _investmentTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentTypeDto>>(investmentTypes);
        }

        public async Task<InvestmentTypeDto> FindByIdAsync(int id)
        {
            InvestmentType? investmentType = await _investmentTypeRepository.FindByIdAsync(id);

            if (investmentType is null)
            {
                _logger.LogWarning("Tipo de inversión no encontrado para el id: " + id);
                throw InvestmentTypeNotFound(id);
            }

            return _mapper.Map<InvestmentTypeDto>(investmentType);
        }

        private NotFoundCoreException InvestmentTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de inversión no encontrado para el id: " + id);
        }
    }
}
