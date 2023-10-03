using Jazani.Application.Admins.Dtos.Offices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Admins.Services
{
    public interface IOfficeService
    {
        Task<IReadOnlyList<OfficeDto>> FindAllAsync();
        Task<OfficeDto?> FindByIdAsync(int id);
        Task<OfficeDto> CreateAsync(OfficeSaveDto officeSaveDto);
        Task<OfficeDto> EditAsync(int id, OfficeSaveDto officeSaveDto);
        Task<OfficeDto> DisabledAsync(int id);
    }
}
