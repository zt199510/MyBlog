using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using Meowv.Blog.ToolKits.Extensions;
using System;
using System.Threading.Tasks;
using static Acme.BookStore.Domain.Shared.AcmeBlogConsts;

namespace Acme.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string KEY_QueryPosts = "Blog:Post:QueryPosts-{0}-{1}";
        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        /// 
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory)
        {
            
            return await Cache.GetOrAddAsync(KEY_QueryPosts.FormatWith(input.Page, input.Limit), factory, CacheStrategy.ONE_DAY);
        }
       
    }
}
