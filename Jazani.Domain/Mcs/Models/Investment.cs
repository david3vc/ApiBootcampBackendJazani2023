using Jazani.Domain.Cores.Models;
using Jazani.Domain.Dls.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Socs.Models;

namespace Jazani.Domain.Mcs.Models
{
    public class Investment : CoreModel<int>
    {
        public decimal AmountInvestd { get; set; }
        public string? Description { get; set; }
        public int MiningConcessionId { get; set; }
        public int DocumentId { get; set; }
        public int HolderId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public int MeasureUnitId { get; set; }
        public int InvestmentConceptId { get; set; }
        public int DeclaredTypeId { get; set; }
        public int CurrencyTypeId { get; set; }

        public virtual MiningConcession MiningConcession { get; set; }
        public virtual Document Document { get; set; }
        public virtual Holder Holder { get; set; }
        public virtual InvestmentType InvestmentType { get; set; }
        public virtual PeriodType PeriodType { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }
        public virtual InvestmentConcept InvestmentConcept { get; set; }
    }
}
