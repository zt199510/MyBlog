
using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Application.Caching.Blog
{
    public partial interface IBlogCacheService
    {
        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory);
    }
}