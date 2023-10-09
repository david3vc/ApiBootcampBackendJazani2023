using Jazani.Domain.Mcs.Models;

namespace Jazani.Domain.Generals.Models
{
    public class MineralType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Mineral> Minerals { get; set; }
        public virtual ICollection<MiningConcession> MiningConcessions { get; set; }
    }
}
