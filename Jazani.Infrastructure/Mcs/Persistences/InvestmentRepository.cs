using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.MiningConcession)
                .Include(t => t.Document)
                .Include(t => t.Holder)
                .Include(t => t.InvestmentType)
                .Include(t => t.PeriodType)
                .Include(t => t.MeasureUnit)
                .Include(t => t.InvestmentConcept)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.MiningConcession)
                .Include(t => t.Document)
                .Include(t => t.Holder)
                .Include(t => t.InvestmentType)
                .Include(t => t.PeriodType)
                .Include(t => t.MeasureUnit)
                .Include(t => t.InvestmentConcept)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
