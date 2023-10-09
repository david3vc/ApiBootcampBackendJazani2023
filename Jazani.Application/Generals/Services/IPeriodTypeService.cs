using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.PeriodTypes;

namespace Jazani.Application.Generals.Services
{
    public interface IPeriodTypeService : ICrudService<PeriodTypeDto, PeriodTypeSaveDto, int>
    {
    }
}
