using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CoffeeRenoContext : DbContext
    {
        public CoffeeRenoContext(DbContextOptions<CoffeeRenoContext> options)
            : base(options)
        { }

        public DbSet<UserLoginHistory> UserLoginHistorys { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<AdsType> AdsTypes { get; set; }
        public DbSet<AdsForm> AdsForms { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        //public DbSet<ApplicationLanguage> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Init Data
            //modelBuilder.Entity<Role>().HasData(
            //    new Role { Name = "Administrator", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false },
            //    new Role { Name = "Poster", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false },
            //    new Role { Name = "Normal User", CreatedDate = DateTime.Now, CreatedBy = 1, IsDeleted = false });

            //modelBuilder.Entity<ApplicationLanguage>().HasData(
            //        LanguageCreator.GetInitialLanguages()
            //    );
            modelBuilder.Entity<UserLoginHistory>().ToTable("VNADS_UserLoginHistory");
            modelBuilder.Entity<UserProfile>().ToTable("VNADS_UserProfile");
            modelBuilder.Entity<UserRole>().ToTable("VNADS_UserRole");
            modelBuilder.Entity<Role>().ToTable("VNADS_Role");

            modelBuilder.Entity<AdsType>().ToTable("VNADS_AdsType");
            modelBuilder.Entity<AdsForm>().ToTable("VNADS_AdsForm");
            modelBuilder.Entity<Image>().ToTable("VNADS_Image");
            modelBuilder.Entity<PostType>().ToTable("VNADS_PostType");
            modelBuilder.Entity<Post>().ToTable("VNADS_Post");
            modelBuilder.Entity<PostImage>().ToTable("VNADS_PostImage");
        }
    }
}
