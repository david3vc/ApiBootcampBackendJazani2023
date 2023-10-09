using Jazani.Domain.Cores.Models;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Domain.Socs.Models
{
    public class Holder : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; }
        public string MaidenName { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
