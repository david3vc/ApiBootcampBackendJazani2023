using Jazani.Application.Admins.Dtos.CivilStatuses;

namespace Jazani.Application.Admins.Services
{
    public interface ICivilStatusService
    {
        Task<IReadOnlyList<CivilStatusDto>> FindAllAsync();
        Task<CivilStatusDto?> FindByIdAsync(int id);
        Task<CivilStatusDto> CreateAsync(CivilStatusSaveDto civilStatusSaveDto);
        Task<CivilStatusDto> EditAsync(int id, CivilStatusSaveDto civilStatusSaveDto);
        Task<CivilStatusDto> DisabledAsync(int id);
    }
}
