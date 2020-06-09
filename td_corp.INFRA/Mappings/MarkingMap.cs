using System;
using td_corp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace td_corp.INFRA.Mappings
{
    public class MarkingMap : IEntityTypeConfiguration<Marking>
    {
        public void Configure(EntityTypeBuilder<Marking> builder)
        {
            Ignores(builder);
            Properties(builder);
            Relationship(builder);
            builder.ToTable(nameof(Marking));
        }


        private void Properties(EntityTypeBuilder<Marking> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
            .HasColumnName(nameof(Marking.Id))
            .IsRequired();

            builder.Property(entity => entity.IsActive)
            .HasColumnName(nameof(Marking.IsActive))
            .IsRequired()
            .HasDefaultValue(true);

            builder.Property(entity => entity.Name)
            .HasColumnName(nameof(Marking.Name))
            .IsRequired();

            builder.Property(entity => entity.ActivationDate)
            .HasColumnName(nameof(Marking.ActivationDate))
            .IsRequired(false)
            .HasDefaultValue(DateTime.UtcNow);

            builder.Property(entity => entity.Created)
            .HasColumnName(nameof(Marking.Created))
            .IsRequired()
            .HasDefaultValue(DateTime.UtcNow);
        }

        private void Ignores(EntityTypeBuilder<Marking> builder)
        {
            builder.Ignore(entity => entity.Valid);
        }
        private void Relationship(EntityTypeBuilder<Marking> builder)
        {
            builder.HasMany(entity => entity.Models)
            .WithOne(o => o.Marking)
            .HasForeignKey(entity => entity.MarkingId);
        }
    }
}
