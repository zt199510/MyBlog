using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Acme.BookStore
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
         typeof(MeowvBlogApplicationModule)
        )]
  public  class AcmeHttpApiModule:AbpModule
    {
    }
}
