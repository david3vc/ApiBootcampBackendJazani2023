using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Mcs.Models
{
    public class InvestmentType : CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
