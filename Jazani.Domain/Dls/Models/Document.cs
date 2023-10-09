using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Dls.Models
{
    public class Document : CoreModel<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsFile { get; set; }
        public int ExternalId { get; set; }
    }
}
