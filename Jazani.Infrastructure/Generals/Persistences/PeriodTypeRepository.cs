using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class PeriodTypeRepository : CrudRepository<PeriodType, int>, IPeriodTypeRepository
    {
        public PeriodTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
