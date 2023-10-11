using Jazani.Application.Dls.Dtos.Documents;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Application.Mcs.Dtos.InvestmentConcepts;
using Jazani.Application.Mcs.Dtos.InvestmentTypes;
using Jazani.Application.Mcs.Dtos.MiningConcessions;
using Jazani.Application.Socs.Dtos.Holders;

namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public decimal AmountInvestd { get; set; }
        public string? Description { get; set; }
        public int? Year { get; set; }
        public string? AccreditationCode { get; set; }
        public string? AccountantCode { get; set; }
        public string? MetricTons { get; set; }
        public string? MonthName { get; set; }
        public int? MonthId { get; set; }
        public bool? Module { get; set; }
        public int? Frecuency { get; set; }
        public int? IsDac { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public MiningConcessionSimpleDto? MiningConcession { get; set; }
        public DocumentSimpleDto? Document { get; set; }
        public HolderSimpleDto? Holder { get; set; }
        public InvestmentTypeSimpleDto? InvestmentType { get; set; }
        public PeriodTypeSimpleDto? PeriodType { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public InvestmentConceptSimpleDto? InvestmentConcept { get; set; }
        public int DeclaredTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
