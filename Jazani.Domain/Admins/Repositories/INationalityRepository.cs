using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface INationalityRepository
    {
        Task<IReadOnlyList<Nationality>> FindAllAsync();
        Task<Nationality?> FindByIdAsync(int id);
        Task<Nationality> SaveAsync(Nationality nationality);
    }
}
