using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetProfileConfiguration : IEntityTypeConfiguration<AspnetProfile>
    {
        public void Configure(EntityTypeBuilder<AspnetProfile> entity)
        {

            entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_P__1788CC4C446E7D24");

            entity.ToTable("aspnet_Profile");

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.PropertyNames)
                .IsRequired()
                .HasColumnType("ntext");

            entity.Property(e => e.PropertyValuesBinary)
                .IsRequired()
                .HasColumnType("image");

            entity.Property(e => e.PropertyValuesString)
                .IsRequired()
                .HasColumnType("ntext");

            entity.HasOne(d => d.User)
                .WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__75A278F5");

        }
    }
}
