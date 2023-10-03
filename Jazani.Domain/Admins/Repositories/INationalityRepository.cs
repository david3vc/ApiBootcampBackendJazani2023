using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface INationalityRepository
    {
        Task<IReadOnlyList<Nationality>> FindAllAsync();
        Task<Nationality?> FindByIdAsync(int id);
        Task<Nationality> SaveAsync(Nationality nationality);
    }
}
