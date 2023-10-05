using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class NationalityRepository : CrudRepository<Nationality, int>, INationalityRepository
    {
        public NationalityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
