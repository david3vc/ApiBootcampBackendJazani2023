using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Generals.Repositories
{
    public interface IMineralTypeRepository : ICrudRepository<MineralType, int>
    {
        //Task<IReadOnlyList<MineralType>> FindAllAsync();
        //Task<MineralType?> FindByIdAsync(int id);
        //Task<MineralType> SaveAsync(MineralType mineralType);
    }
}
