using Jazani.Domain.Cores.Models;
using Jazani.Domain.Mcs.Models;

namespace Jazani.Domain.Generals.Models
{
    public class MeasureUnit : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public string? Description { get; set; }
        public string? FormulaConversion { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
