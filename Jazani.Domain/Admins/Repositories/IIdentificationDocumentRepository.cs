using Jazani.Domain.Admins.Models;
using Jazani.Domain.Cores.Repositories;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IIdentificationDocumentRepository : ICrudRepository<IdentificationDocument, int>
    {
    }
}
