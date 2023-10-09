using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class PeriodTypeConfiguration : IEntityTypeConfiguration<PeriodType>
    {
        public void Configure(EntityTypeBuilder<PeriodType> builder)
        {
            builder.ToTable("periodtype", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Time).HasColumnName("time");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
