using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Data.Configurations
{
    public class AspnetWebEventEventsConfiguration : IEntityTypeConfiguration<AspnetWebEventEvents>
    {
        public void Configure(EntityTypeBuilder<AspnetWebEventEvents> entity)
        {

            entity.HasKey(e => e.EventId)
                   .HasName("PK__aspnet_W__7944C810750EA52E");

            entity.ToTable("aspnet_WebEvent_Events");

            entity.Property(e => e.EventId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.ApplicationPath).HasMaxLength(256);

            entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);

            entity.Property(e => e.Details).HasColumnType("ntext");

            entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");

            entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");

            entity.Property(e => e.EventTime).HasColumnType("datetime");

            entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");

            entity.Property(e => e.EventType)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.ExceptionType).HasMaxLength(256);

            entity.Property(e => e.MachineName)
                .IsRequired()
                .HasMaxLength(256);

            entity.Property(e => e.Message).HasMaxLength(1024);

            entity.Property(e => e.RequestUrl).HasMaxLength(1024);

        }
    }
}
