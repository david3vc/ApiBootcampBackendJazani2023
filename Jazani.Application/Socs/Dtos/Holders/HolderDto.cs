namespace Jazani.Application.Socs.Dtos.Holders
{
    public class HolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
