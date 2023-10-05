using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class EmployeeRepository : CrudRepository<Employee, int>, IEmployeeRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Employee>> FindAllAsync()
        {
            return await _dbContext.Set<Employee>()
                .Include(t => t.IdentificationDocument)
                .Include(t => t.Nationality)
                .Include(t => t.CivilStatus)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Employee?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Employee>()
                .Include(t => t.IdentificationDocument)
                .Include(t => t.Nationality)
                .Include(t => t.CivilStatus)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
