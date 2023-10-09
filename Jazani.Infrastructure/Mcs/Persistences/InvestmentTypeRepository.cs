using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmentTypeRepository : CrudRepository<InvestmentType, int>, IInvestmentTypeRepository
    {
        public InvestmentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
