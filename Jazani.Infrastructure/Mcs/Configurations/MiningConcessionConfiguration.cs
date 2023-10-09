﻿using Jazani.Domain.Mcs.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Mcs.Configurations
{
    public class MiningConcessionConfiguration : IEntityTypeConfiguration<MiningConcession>
    {
        public void Configure(EntityTypeBuilder<MiningConcession> builder)
        {
            builder.ToTable("miningconcession", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Code).HasColumnName("code");
            builder.Property(t => t.MineralTypeId).HasColumnName("mineraltypeid");
            builder.Property(t => t.OriginId).HasColumnName("originid");
            builder.Property(t => t.TypeId).HasColumnName("typeid");
            builder.Property(t => t.SituationId).HasColumnName("situationid");
            builder.Property(t => t.MiningunitId).HasColumnName("miningunitid");
            builder.Property(t => t.ConditionId).HasColumnName("conditionid");
            builder.Property(t => t.StatemanagementId).HasColumnName("statemanagementid");
            builder.Property(t => t.IsSincronized).HasColumnName("issincronized");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.MineralType).WithMany(many => many.MiningConcessions).HasForeignKey(fk => fk.MineralTypeId);
        }
    }
}
