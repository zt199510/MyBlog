
using Acme.BookStore.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AcmeBlogDomainSharedModule)
        )]
    public class AcmeBlogDomainModule : AbpModule
    {

    }
}
