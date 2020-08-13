using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetSchemaVersionsConfiguration : IEntityTypeConfiguration<AspnetSchemaVersions>
    {
        public void Configure(EntityTypeBuilder<AspnetSchemaVersions> entity)
        {

            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion })
                     .HasName("PK__aspnet_S__5A1E6BC152DE9CCA");

            entity.ToTable("aspnet_SchemaVersions");

            entity.Property(e => e.Feature).HasMaxLength(128);

            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);

        }
    }
}
