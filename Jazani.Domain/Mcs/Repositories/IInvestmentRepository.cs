﻿using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Domain.Mcs.Repositories
{
    public interface IInvestmentRepository : ICrudRepository<Investment, int>, IPaginatedRepository<Investment> { }
}
