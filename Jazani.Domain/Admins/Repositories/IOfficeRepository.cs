using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IOfficeRepository
    {
        Task<IReadOnlyList<Office>> FindAllAsync();
        Task<Office?> FindByIdAsync(int id);
        Task<Office> SaveAsync(Office office);
    }
}
