using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Dls.Models;

namespace Jazani.Domain.Dls.Repositories
{
    public interface IDocumentRepository : ICrudRepository<Document, int>
    {
    }
}
