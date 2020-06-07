using Acme.Application.Caching;
using Acme.BookStore.Application;
using Acme.BookStore.Domain.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Acme.BookStore
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpIdentityApplicationModule),
       typeof(MeowvBlogApplicationCachingModule)
        )]
   public class MeowvBlogApplicationModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MeowvBlogApplicationModule>(validate: true);
                options.AddProfile<MeowvBlogAutoMapperProfile>(validate: true);
            });
        }
    }
}
