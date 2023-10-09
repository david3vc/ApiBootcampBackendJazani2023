using Jazani.Domain.Mcs.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Mcs.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AmountInvestd)
                .HasColumnName("amountinvestd")
                .HasColumnType("decimal(10,4)");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(t => t.DocumentId).HasColumnName("documentid");
            builder.Property(t => t.HolderId).HasColumnName("holderid");
            builder.Property(t => t.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(t => t.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(t => t.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(t => t.InvestmentConceptId).HasColumnName("investmentconceptid");
            builder.Property(t => t.DeclaredTypeId).HasColumnName("declaredtypeid");
            builder.Property(t => t.CurrencyTypeId).HasColumnName("currencytypeid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments).HasForeignKey(fk => fk.MiningConcessionId);
            builder.HasOne(one => one.Document).WithMany(many => many.Investments).HasForeignKey(fk => fk.DocumentId);
            builder.HasOne(one => one.Holder).WithMany(many => many.Investments).HasForeignKey(fk => fk.HolderId);
            builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments).HasForeignKey(fk => fk.InvestmentTypeId);
            builder.HasOne(one => one.PeriodType).WithMany(many => many.Investments).HasForeignKey(fk => fk.PeriodTypeId);
            builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments).HasForeignKey(fk => fk.MeasureUnitId);
            builder.HasOne(one => one.InvestmentConcept).WithMany(many => many.Investments).HasForeignKey(fk => fk.InvestmentConceptId);
        }
    }
}
