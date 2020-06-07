using Acme.BookStore.Domain.Blog;
using Acme.BookStore.Domain.HotNews;
using Acme.BookStore.Domain.Wallpaper;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore
{
    [ConnectionStringName("Sqlite")]
    public class AcmeBlogDbContext : AbpDbContext<AcmeBlogDbContext>
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<FriendLink> FriendLinks { get; set; }
        public DbSet<Wallpaper> Wallpapers { get; set; }

        public DbSet<HotNews> HotNews { get; set; }

        public AcmeBlogDbContext(DbContextOptions<AcmeBlogDbContext> Options):base(Options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configure();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
