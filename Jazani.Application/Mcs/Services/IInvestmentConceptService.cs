using Jazani.Application.Cores.Services;
using Jazani.Application.Mcs.Dtos.InvestmentConcepts;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvestmentConceptService : ICrudService<InvestmentConceptDto, InvestmentConceptSaveDto, int>
    {
    }
}
