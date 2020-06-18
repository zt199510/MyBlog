
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Acme.BookStore.Domain.Shared.AcmeBlogConsts;

namespace Acme.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService : CachingServiceBase, IBlogCacheService
    {
       
    }
}