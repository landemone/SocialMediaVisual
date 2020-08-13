using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetUsersInRolesConfiguration : IEntityTypeConfiguration<AspnetUsersInRoles>
    {
        public void Configure(EntityTypeBuilder<AspnetUsersInRoles> entity)
        {

            entity.HasKey(e => new { e.UserId, e.RoleId })
                     .HasName("PK__aspnet_U__AF2760AD94585748");

            entity.ToTable("aspnet_UsersInRoles");

            entity.HasIndex(e => e.RoleId)
                .HasName("aspnet_UsersInRoles_index");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.AspnetUsersInRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__RoleI__03F0984C");

            entity.HasOne(d => d.User)
                .WithMany(p => p.AspnetUsersInRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__UserI__02FC7413");

        }
    }
}
