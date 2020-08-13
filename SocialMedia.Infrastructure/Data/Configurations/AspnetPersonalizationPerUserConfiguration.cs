using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetPersonalizationPerUserConfiguration : IEntityTypeConfiguration<AspnetPersonalizationPerUser>
    {
        public void Configure(EntityTypeBuilder<AspnetPersonalizationPerUser> entity)
        {

            entity.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC063925661E")
                    .IsClustered(false);

            entity.ToTable("aspnet_PersonalizationPerUser");

            entity.HasIndex(e => new { e.PathId, e.UserId })
                .HasName("aspnet_PersonalizationPerUser_index1")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.UserId, e.PathId })
                .HasName("aspnet_PersonalizationPerUser_ncindex2")
                .IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.PageSettings)
                .IsRequired()
                .HasColumnType("image");

            entity.HasOne(d => d.Path)
                .WithMany(p => p.AspnetPersonalizationPerUser)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__1BC821DD");

            entity.HasOne(d => d.User)
                .WithMany(p => p.AspnetPersonalizationPerUser)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__1CBC4616");

        }
    }
}
