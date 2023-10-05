using Jazani.Application.Generals.Dtos.Minerals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IMineralService
    {
        Task<IReadOnlyList<MineralDto>> FindAllAsync();
        Task<MineralDto?> FindByIdAsync(int id);
        Task<MineralDto> CreateAsync(MineralSaveDto mineralSaveDto);
        Task<MineralDto> EditAsync(int id, MineralSaveDto mineralSaveDto);
        Task<MineralDto> DisabledAsync(int id);
    }
}
