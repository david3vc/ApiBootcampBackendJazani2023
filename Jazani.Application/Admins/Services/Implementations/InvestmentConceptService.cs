using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Application.Mcs.Dtos.InvestmentConcepts;
using Jazani.Application.Mcs.Services;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MineralTypeService> _logger;

        public InvestmentConceptService(IInvestmentConceptRepository investmentConceptRepository, IMapper mapper, ILogger<MineralTypeService> logger)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(investmentConceptSaveDto);
            investmentConcept.RegistrationDate = DateTime.Now;
            investmentConcept.State = true;

            InvestmentConcept investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<InvestmentConceptDto> DisabledAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id: " + id);
                throw InvestmentConceptNotFound(id);
            }

            investmentConcept.State = false;

            InvestmentConcept investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto investmentConceptSaveDto)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id: " + id);
                throw InvestmentConceptNotFound(id);
            }

            _mapper.Map<InvestmentConceptSaveDto, InvestmentConcept>(investmentConceptSaveDto, investmentConcept);

            InvestmentConcept investmentConceptSaved = await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConceptSaved);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcepts = await _investmentConceptRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>>(investmentConcepts);
        }

        public async Task<InvestmentConceptDto> FindByIdAsync(int id)
        {
            InvestmentConcept? investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            if (investmentConcept is null)
            {
                _logger.LogWarning("Concepto de inversión no encontrado para el id: " + id);
                throw InvestmentConceptNotFound(id);
            }

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        private NotFoundCoreException InvestmentConceptNotFound(int id)
        {
            return new NotFoundCoreException("Concepto de inversión no encontrado para el id: " + id);
        }
    }
}
