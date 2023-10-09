namespace Jazani.Application.Mcs.Dtos.MiningConcessions
{
    public class MiningConcessionSaveDto
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; }
        public string? Description { get; set; }
        public int MineralTypeId { get; set; }
        public int OriginId { get; set; }
        public int TypeId { get; set; }
        public int SituationId { get; set; }
        public int MiningunitId { get; set; }
        public int ConditionId { get; set; }
        public int StatemanagementId { get; set; }
        public bool IsSincronized { get; set; }
    }
}
