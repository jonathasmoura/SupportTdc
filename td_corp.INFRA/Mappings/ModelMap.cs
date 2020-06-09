using System;
using td_corp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace td_corp.INFRA.Mappings
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            Ignores(builder);
            Properties(builder);
            Relationship(builder);
            builder.ToTable(nameof(Model));
        }


        private void Properties(EntityTypeBuilder<Model> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
            .HasColumnName(nameof(Model.Id))
            .IsRequired();

            builder.Property(entity => entity.Name)
            .HasColumnName(nameof(Model.Name))
            .IsRequired();

            builder.Property(entity => entity.Description)
            .HasColumnName(nameof(Model.Description))
            .IsRequired();

            builder.Property(entity => entity.IsActive)
            .HasColumnName(nameof(Model.IsActive))
            .IsRequired()
            .HasDefaultValue(true);

            builder.Property(entity => entity.ActivationDate)
            .HasColumnName(nameof(Model.ActivationDate))
            .IsRequired(false)
            .HasDefaultValue(DateTime.UtcNow);

            builder.Property(entity => entity.InactivationDate)
            .HasColumnName(nameof(Model.InactivationDate))
            .IsRequired(false)
            .HasDefaultValue(DateTime.UtcNow);

            builder.Property(entity => entity.Created)
            .HasColumnName(nameof(Model.Created))
            .IsRequired()
            .HasDefaultValue(DateTime.UtcNow);

            builder.Property(entity => entity.MarkingId)
            .HasColumnName(nameof(Model.MarkingId))
            .IsRequired();
        }

        private void Ignores(EntityTypeBuilder<Model> builder)
        {
            builder.Ignore(entity => entity.Valid);
        }
        private void Relationship(EntityTypeBuilder<Model> builder)
        {
            builder.HasOne(entity => entity.Marking)
            .WithMany(many => many.Models)
            .HasForeignKey(entity => entity.MarkingId);
        }
    }
}
