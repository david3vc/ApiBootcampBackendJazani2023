namespace Jazani.Application.Generals.Dtos.MeasureUnits
{
    public class MeasureUnitSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public string? FormulaConversion { get; set; }
    }
}
