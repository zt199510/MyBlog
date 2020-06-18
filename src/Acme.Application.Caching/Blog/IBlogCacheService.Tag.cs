
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Application.Caching.Blog
{
    public partial interface    IBlogCacheService
    {
        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync(Func<Task<ServiceResult<IEnumerable<QueryTagDto>>>> factory);

        //IBlogCacheService.Tag.cs
        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync(string name, Func<Task<ServiceResult<string>>> factory);
    }
}