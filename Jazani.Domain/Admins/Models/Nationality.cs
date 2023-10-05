namespace Jazani.Domain.Admins.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
