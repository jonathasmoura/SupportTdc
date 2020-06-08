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

        private void Relationship(EntityTypeBuilder<Marking> builder)
        {
            throw new NotImplementedException();
        }

        private void Properties(EntityTypeBuilder<Marking> builder)
        {
            throw new NotImplementedException();
        }

        private void Ignores(EntityTypeBuilder<Marking> builder)
        {
            throw new NotImplementedException();
        }
    }
}
