using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using System;
using Acme.BookStore.Domain;

namespace Acme.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
         typeof(AcmeBlogDomainModule)
        )]
    public class MeowvBlogApplicationCachingModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
