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

        private void Relationship(EntityTypeBuilder<Model> builder)
        {
            throw new NotImplementedException();
        }

        private void Properties(EntityTypeBuilder<Model> builder)
        {
            throw new NotImplementedException();
        }

        private void Ignores(EntityTypeBuilder<Model> builder)
        {
            throw new NotImplementedException();
        }
    }
}
