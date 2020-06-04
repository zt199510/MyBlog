using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Acme.BookStore.EntityFrameworkCore
{
    [DependsOn(
       typeof(AcmeBlogFrameworkCoreModule)
       )]
    public class BookStoreEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookStoreMigrationsDbContext>();
        }
    }
}
