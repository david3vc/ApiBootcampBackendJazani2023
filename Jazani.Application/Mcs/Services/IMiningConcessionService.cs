using Jazani.Application.Cores.Services;
using Jazani.Application.Mcs.Dtos.MiningConcessions;

namespace Jazani.Application.Mcs.Services
{
    public interface IMiningConcessionService : ICrudService<MiningConcessionDto, MiningConcessionSaveDto, int>
    {
    }
}
