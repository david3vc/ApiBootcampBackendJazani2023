using Jazani.Application.Cores.Services;
using Jazani.Application.Socs.Dtos.Holders;

namespace Jazani.Application.Socs.Services
{
    public interface IHolderService : IQueryService<HolderDto, int>
    {
    }
}
