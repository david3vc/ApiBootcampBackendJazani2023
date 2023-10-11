using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
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
        private readonly IPaginator<Investment> _paginator;

        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Investment>().AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.MetricTons) || x.MetricTons.ToUpper().Contains(filter.MetricTons.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.AccreditationCode) || x.AccreditationCode.ToUpper().Contains(filter.AccreditationCode.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.AccountantCode) || x.AccountantCode.ToUpper().Contains(filter.AccountantCode.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                        && (filter.Year == null || x.Year == filter.Year)
                    );
            }

            query = query.Include(t => t.Document)
                    .Include(t => t.Holder)
                    .Include(t => t.InvestmentType)
                    .Include(t => t.PeriodType)
                    .Include(t => t.MeasureUnit)
                    .Include(t => t.InvestmentConcept);

            return await _paginator.Paginate(query, request);
        }
    }
}
