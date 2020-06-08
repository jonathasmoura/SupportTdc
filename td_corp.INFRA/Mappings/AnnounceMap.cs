using System;
using td_corp.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace td_corp.INFRA.Mappings
{
    public class AnnounceMap : IEntityTypeConfiguration<Announce>
    {
        public void Configure(EntityTypeBuilder<Announce> builder)
        {
            Ignores(builder);
            Properties(builder);
            Relationship(builder);
            builder.ToTable(nameof(Announce));
        }

        private void Relationship(EntityTypeBuilder<Announce> builder)
        {
            throw new NotImplementedException();
        }

        private void Properties(EntityTypeBuilder<Announce> builder)
        {
            throw new NotImplementedException();
        }

        private void Ignores(EntityTypeBuilder<Announce> builder)
        {
            throw new NotImplementedException();
        }
    }
}
