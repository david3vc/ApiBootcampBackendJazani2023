using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class InvestmentConceptRepository : CrudRepository<InvestmentConcept, int>, IInvestmentConceptRepository
    {
        public InvestmentConceptRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
