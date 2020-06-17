
using Acme.BookStore.Application.Contracts;
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.BookStore.Application.Blog.Impl
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input);
    }
}