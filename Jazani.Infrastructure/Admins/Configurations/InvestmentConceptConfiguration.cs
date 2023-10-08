using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class InvestmentConceptConfiguration : IEntityTypeConfiguration<InvestmentConcept>
    {
        public void Configure(EntityTypeBuilder<InvestmentConcept> builder)
        {
            builder.ToTable("investmentconcept", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
