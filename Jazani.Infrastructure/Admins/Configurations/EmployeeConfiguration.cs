using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Admins.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee", "adm");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Lastname).HasColumnName("lastname");
            builder.Property(t => t.Maidenname).HasColumnName("maidenname");
            builder.Property(t => t.PersonalMail).HasColumnName("personalmail");
            builder.Property(t => t.CorporatEmail).HasColumnName("corporatemail");
            builder.Property(t => t.Landline).HasColumnName("landline");
            builder.Property(t => t.Mobile).HasColumnName("mobile");
            builder.Property(t => t.DocumentNumber).HasColumnName("documentnumber");
            builder.Property(t => t.MiningunitId).HasColumnName("miningunitid");
            builder.Property(t => t.NationalityId).HasColumnName("nationalityid");
            builder.Property(t => t.IdentificationDocumentId).HasColumnName("identificationdocumentid");
            builder.Property(t => t.CivilStatusId).HasColumnName("civilstatusid");
            builder.Property(t => t.IsSincronized).HasColumnName("issincronized");
            builder.Property(t => t.StartDate).HasColumnName("startdate");
            builder.Property(t => t.BirthDate).HasColumnName("birthdate");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.IdentificationDocument).WithMany(many => many.Employees).HasForeignKey(fk => fk.IdentificationDocumentId);
            builder.HasOne(one => one.Nationality).WithMany(many => many.Employees).HasForeignKey(fk => fk.NationalityId);
        }
    }
}
