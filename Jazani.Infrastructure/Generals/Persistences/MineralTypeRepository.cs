using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MineralTypeRepository : CrudRepository<MineralType, int>, IMineralTypeRepository
    {
        public MineralTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
