using Microsoft.EntityFrameworkCore;

using Volo.Abp.EntityFrameworkCore;

using Volo.Abp.Identity;


namespace Acme.BookStore.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See BookStoreDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class BookStoreMigrationsDbContext : AbpDbContext<BookStoreMigrationsDbContext>
    {
        public BookStoreMigrationsDbContext(DbContextOptions<BookStoreMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}