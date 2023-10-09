using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Socs.Models
{
    public class Holder : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; }
        public string MaidenName { get; set; }
    }
}
