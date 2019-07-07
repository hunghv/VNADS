using System;
using Data.Entities;
using Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CoffeeRenoContext : DbContext
    {
        public CoffeeRenoContext(DbContextOptions<CoffeeRenoContext> options)
            : base(options)
        {
        }

        public DbSet<UserLoginHistory> UserLoginHistorys { get; set; }
       
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<AdsType> AdsTypes { get; set; }
        public DbSet<AdsForm> AdsForms { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<ApplicationLanguage> ApplicationLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p => new {p.UserId, p.RoleId});

            ////Init Data
            modelBuilder.Entity<Role>().HasData(
                new Role {Id = 1, Name = "Administrator", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false},
                new Role {Id = 2, Name = "Poster", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false},
                new Role {Id = 3, Name = "Normal User", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false});

            modelBuilder.Entity<ApplicationLanguage>().HasData(
                LanguageCreator.GetInitialLanguages()
            );
        }
    }

    public class IdentityDbContext : IdentityDbContext<UserProfile>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
