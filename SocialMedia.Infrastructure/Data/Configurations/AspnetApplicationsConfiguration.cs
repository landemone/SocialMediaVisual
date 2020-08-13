using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetApplicationsConfiguration : IEntityTypeConfiguration<AspnetApplications>
    {
        public void Configure(EntityTypeBuilder<AspnetApplications> entity)
        {

            entity.HasKey(e => e.ApplicationId)
                   .HasName("PK__aspnet_A__C93A4C98792B14CA")
                   .IsClustered(false);

            entity.ToTable("aspnet_Applications");

            entity.HasIndex(e => e.ApplicationName)
                .HasName("UQ__aspnet_A__30910331AC3C23F1")
                .IsUnique();

            entity.HasIndex(e => e.LoweredApplicationName)
                .HasName("aspnet_Applications_Index")
                .IsClustered();

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.ApplicationName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.Description).HasMaxLength(256);

            entity.Property(e => e.LoweredApplicationName)
                .IsRequired()
                .HasMaxLength(256);
          
        }
    }
}
