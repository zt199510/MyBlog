
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
        /// 查询友链列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync(Func<Task<ServiceResult<IEnumerable<FriendLinkDto>>>> factory);
    }
}