using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class PersonTypeRepository : CrudRepository<PersonType, int>, IPersonTypeRepository
    {
        public PersonTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
