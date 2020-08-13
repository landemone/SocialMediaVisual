using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetUsersConfiguration : IEntityTypeConfiguration<AspnetUsers>
    {
        public void Configure(EntityTypeBuilder<AspnetUsers> entity)
        {

            entity.HasKey(e => e.UserId)
                     .HasName("PK__aspnet_U__1788CC4D9C1B7CCD")
                     .IsClustered(false);

            entity.ToTable("aspnet_Users");

            entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate })
                .HasName("aspnet_Users_Index2");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName })
                .HasName("aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

            entity.Property(e => e.LoweredUserName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.MobileAlias).HasMaxLength(16);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__5070F446");

        }
    }
}
