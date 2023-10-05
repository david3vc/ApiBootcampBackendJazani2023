﻿using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories
{
    public interface IMineralTypeRepository : ICrudRepository<MineralType, int>
    {
        //Task<IReadOnlyList<MineralType>> FindAllAsync();
        //Task<MineralType?> FindByIdAsync(int id);
        //Task<MineralType> SaveAsync(MineralType mineralType);
    }
}
