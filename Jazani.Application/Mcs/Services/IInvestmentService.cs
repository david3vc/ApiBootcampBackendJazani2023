using Jazani.Application.Cores.Services;
using Jazani.Application.Mcs.Dtos.Investments;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvestmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>, IPaginatedService<InvestmentDto, InvestmentFilterDto>
    {
    }
}
