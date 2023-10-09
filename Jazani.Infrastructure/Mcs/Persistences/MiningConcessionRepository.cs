using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class MiningConcessionRepository : CrudRepository<MiningConcession, int>, IMiningConcessionRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public MiningConcessionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<MiningConcession>> FindAllAsync()
        {
            return await _dbContext.Set<MiningConcession>()
                .Include(t => t.MineralType)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<MiningConcession?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<MiningConcession>()
                .Include(t => t.MineralType)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
