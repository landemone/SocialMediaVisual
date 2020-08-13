using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Data.Configurations;
using System.Reflection;

namespace SocialMedia.Infrastructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
        {
        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<AspnetApplications> AspnetApplication { get; set; }
        public virtual DbSet<AspnetMembership> AspnetMembership { get; set; }
        public virtual DbSet<AspnetPaths> AspnetPath { get; set; }
        public virtual DbSet<AspnetPersonalizationAllUsers> AspnetPersonalizationAllUser { get; set; }
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }
        public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRole { get; set; }
        public virtual DbSet<AspnetSchemaVersions> AspnetSchemaVersion { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUser { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRole { get; set; }
        public virtual DbSet<AspnetWebEventEvents> AspnetWebEventEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

       
    }
}
