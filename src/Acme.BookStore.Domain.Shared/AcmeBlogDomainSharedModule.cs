using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainSharedModule))]
    public class AcmeBlogDomainSharedModule: AbpModule
    {

    }
}
