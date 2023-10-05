using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class IdentificationDocumentConfiguration : IEntityTypeConfiguration<IdentificationDocument>
    {
        public void Configure(EntityTypeBuilder<IdentificationDocument> builder)
        {
            builder.ToTable("identificationdocument", "adm");
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
