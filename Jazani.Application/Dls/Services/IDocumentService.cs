using Jazani.Application.Cores.Services;
using Jazani.Application.Dls.Dtos.Documents;

namespace Jazani.Application.Dls.Services
{
    public interface IDocumentService : ICrudService<DocumentDto, DocumentSaveDto, int>
    {
    }
}
