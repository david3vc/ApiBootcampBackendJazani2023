using Jazani.Application.Cores.Services;
using Jazani.Application.Mcs.Dtos.InvestmentTypes;

namespace Jazani.Application.Mcs.Services
{
    public interface IInvestmentTypeService : ICrudService<InvestmentTypeDto, InvestmentTypeSaveDto, int>
    {
    }
}
