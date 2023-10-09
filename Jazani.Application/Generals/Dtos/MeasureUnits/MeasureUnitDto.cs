namespace Jazani.Application.Generals.Dtos.MeasureUnits
{
    public class MeasureUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public string? FormulaConversion { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
