using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class PeriodType : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public int Time { get; set; }
        public string? Description { get; set; }
    }
}
