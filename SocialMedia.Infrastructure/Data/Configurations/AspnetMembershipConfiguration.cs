using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetMembershipConfiguration : IEntityTypeConfiguration<AspnetMembership>
    {
        public void Configure(EntityTypeBuilder<AspnetMembership> entity)
        {

            entity.HasKey(e => e.UserId)
                   .HasName("PK__aspnet_M__1788CC4DB7B53DB6")
                   .IsClustered(false);

            entity.ToTable("aspnet_Membership");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail })
                .HasName("aspnet_Membership_index")
                .IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.Property(e => e.Comment).HasColumnType("ntext");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.Property(e => e.Email).HasMaxLength(256);

            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");

            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");

            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");

            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");

            entity.Property(e => e.LoweredEmail).HasMaxLength(256);

            entity.Property(e => e.MobilePin)
                .HasColumnName("MobilePIN")
                .HasMaxLength(16);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(128);

            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);

            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);

            entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.Application)
                .WithMany(p => p.AspnetMembership)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__60A75C0F");

            entity.HasOne(d => d.User)
                .WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__619B8048");

        }
    }
}
