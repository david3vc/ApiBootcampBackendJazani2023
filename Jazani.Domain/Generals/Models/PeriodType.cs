using Jazani.Domain.Cores.Models;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Domain.Generals.Models
{
    public class PeriodType : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public int Time { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
