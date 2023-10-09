namespace Jazani.Application.Dls.Dtos.Documents
{
    public class DocumentSaveDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsFile { get; set; }
        public int ExternalId { get; set; }
    }
}
