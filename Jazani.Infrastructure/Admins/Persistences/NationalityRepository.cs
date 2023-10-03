using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NationalityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Nationality>> FindAllAsync()
        {
            return await _dbContext.Nationalities.ToListAsync();
        }

        public async Task<Nationality?> FindByIdAsync(int id)
        {
            return await _dbContext.Nationalities
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Nationality> SaveAsync(Nationality nationality)
        {
            EntityState state = _dbContext.Entry(nationality).State;

            _ = state switch
            {
                EntityState.Detached => _dbContext.Nationalities.Add(nationality),
                EntityState.Modified => _dbContext.Nationalities.Update(nationality)
            };


            await _dbContext.SaveChangesAsync();

            return nationality;
        }
    }
}
