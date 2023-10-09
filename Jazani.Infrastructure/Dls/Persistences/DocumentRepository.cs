using Jazani.Domain.Dls.Models;
using Jazani.Domain.Dls.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Repositories;

namespace Jazani.Infrastructure.Dls.Persistences
{
    public class DocumentRepository : CrudRepository<Document, int>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
