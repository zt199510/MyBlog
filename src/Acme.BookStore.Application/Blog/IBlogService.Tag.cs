
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.BookStore.Application.Blog.Impl
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync();

        //IBlogService.Tag.cs
        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync(string name);
    }
}