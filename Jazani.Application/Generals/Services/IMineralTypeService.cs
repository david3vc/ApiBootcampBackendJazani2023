using Jazani.Application.Generals.Dtos.MineralTypes;

namespace Jazani.Application.Generals.Services
{
    public interface IMineralTypeService
    {
        Task<IReadOnlyList<MineralTypeDto>> FindAllAsync();
        Task<MineralTypeDto?> FindByIdAsync(int id);
        Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto officeSaveDto);
        Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto officeSaveDto);
        Task<MineralTypeDto> DisabledAsync(int id);
    }
}
