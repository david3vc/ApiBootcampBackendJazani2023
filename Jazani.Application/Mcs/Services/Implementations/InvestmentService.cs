﻿using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Mcs.Dtos.Investments;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Mcs.Services.Implementations
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _logger;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper, ILogger<InvestmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = _mapper.Map<Investment>(investmentSaveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null)
            {
                _logger.LogWarning("Inversión no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            investment.State = false;

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null)
            {
                _logger.LogWarning("Inversión no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            _mapper.Map(investmentSaveDto, investment);

            Investment investmentSaved = await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investmentSaved);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> investments = await _investmentRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investments);
        }

        public async Task<InvestmentDto> FindByIdAsync(int id)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null)
            {
                _logger.LogWarning("Inversión no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            return _mapper.Map<InvestmentDto>(investment);
        }

        private NotFoundCoreException InvestmentNotFound(int id)
        {
            return new NotFoundCoreException("Inversión no encontrado para el id: " + id);
        }
    }
}
