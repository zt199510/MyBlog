
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.BookStore.Application.Blog.Impl
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync();

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetCategoryAsync(string name);
    }
}