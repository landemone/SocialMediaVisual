using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetPathsConfiguration : IEntityTypeConfiguration<AspnetPaths>
    {
        public void Configure(EntityTypeBuilder<AspnetPaths> entity)
        {

            entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC5850B573DF")
                    .IsClustered(false);

            entity.ToTable("aspnet_Paths");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath })
                .HasName("aspnet_Paths_index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.LoweredPath)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.Path)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__123EB7A3");

        }
    }
}
