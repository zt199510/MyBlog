using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using System;
using Acme.BookStore.Domain;
using Microsoft.Extensions.DependencyInjection;
using Acme.BookStore.Domain.Configurations;

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
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;

            });
        }
    }
}
