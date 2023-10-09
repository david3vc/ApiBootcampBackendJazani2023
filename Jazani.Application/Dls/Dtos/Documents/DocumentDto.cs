namespace Jazani.Application.Dls.Dtos.Documents
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsFile { get; set; }
        public int ExternalId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
