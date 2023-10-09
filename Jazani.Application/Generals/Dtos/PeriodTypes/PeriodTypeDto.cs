namespace Jazani.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Time { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
