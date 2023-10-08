using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.MineralTypes;

namespace Jazani.Application.Generals.Services
{
    public interface IMineralTypeService : IPaginatedService<MineralTypeDto>
    {
        Task<IReadOnlyList<MineralTypeDto>> FindAllAsync();
        Task<MineralTypeDto?> FindByIdAsync(int id);
        Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto officeSaveDto);
        Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto officeSaveDto);
        Task<MineralTypeDto> DisabledAsync(int id);
    }
}
