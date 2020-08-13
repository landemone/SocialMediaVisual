using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetPersonalizationAllUsersConfiguration : IEntityTypeConfiguration<AspnetPersonalizationAllUsers>
    {
        public void Configure(EntityTypeBuilder<AspnetPersonalizationAllUsers> entity)
        {

            entity.HasKey(e => e.PathId)
                   .HasName("PK__aspnet_P__CD67DC5905D3E16E");

            entity.ToTable("aspnet_PersonalizationAllUsers");

            entity.Property(e => e.PathId).ValueGeneratedNever();

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.PageSettings)
                .IsRequired()
                .HasColumnType("image");

            entity.HasOne(d => d.Path)
                .WithOne(p => p.AspnetPersonalizationAllUsers)
                .HasForeignKey<AspnetPersonalizationAllUsers>(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pe__PathI__17F790F9");

        }
    }
}
