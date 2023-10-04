using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Application.Generals.Dtos.MineralTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
