using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MeasureUnitRepository : CrudRepository<MeasureUnit, int>, IMeasureUnitRepository
    {
        public MeasureUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
