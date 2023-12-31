﻿namespace Jazani.Application.Mcs.Dtos.Investments
{
    public class InvestmentSaveDto
    {
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
        public int MiningConcessionId { get; set; }
        public int DocumentId { get; set; }
        public int HolderId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public int MeasureUnitId { get; set; }
        public int InvestmentConceptId { get; set; }
        public int DeclaredTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
    }
}
