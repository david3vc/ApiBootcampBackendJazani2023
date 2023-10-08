using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmentConceptRepository : CrudRepository<InvestmentConcept, int>, IInvestmentConceptRepository
    {
        public InvestmentConceptRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
