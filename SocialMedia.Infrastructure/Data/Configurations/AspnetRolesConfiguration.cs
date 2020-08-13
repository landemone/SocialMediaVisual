using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetRolesConfiguration : IEntityTypeConfiguration<AspnetRoles>
    {
        public void Configure(EntityTypeBuilder<AspnetRoles> entity)
        {

            entity.HasKey(e => e.RoleId)
                   .HasName("PK__aspnet_R__8AFACE1B859DA321")
                   .IsClustered(false);

            entity.ToTable("aspnet_Roles");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName })
                .HasName("aspnet_Roles_index1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Description).HasMaxLength(256);

            entity.Property(e => e.LoweredRoleName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__7F2BE32F");

        }
    }
}
