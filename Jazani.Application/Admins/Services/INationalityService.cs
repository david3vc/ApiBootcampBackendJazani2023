using Jazani.Application.Admins.Dtos.Nationalities;

namespace Jazani.Application.Admins.Services
{
    public interface INationalityService
    {
        Task<IReadOnlyList<NationalityDto>> FindAllAsync();
        Task<NationalityDto?> FindByIdAsync(int id);
        Task<NationalityDto> CreateAsync(NationalitySaveDto nationalitySaveDto);
        Task<NationalityDto> EditAsync(int id, NationalitySaveDto nationalitySaveDto);
        Task<NationalityDto> DisabledAsync(int id);
    }
}
