namespace Jazani.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeSaveDto
    {
        public string Name { get; set; } = default!;
        public int Time { get; set; }
        public string? Description { get; set; }
    }
}
