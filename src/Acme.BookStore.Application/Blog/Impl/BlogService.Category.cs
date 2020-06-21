
using Acme.BookStore.Application.Contracts.Blog;
using Acme.ToolKits.Base;
using Meowv.Blog.ToolKits.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Acme.BookStore.Domain.Shared.AcmeBlogConsts;

namespace Acme.BookStore.Application.Blog.Impl
{
    public partial class BlogService
    {
        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync()
        {
            return await _blogCacheService.QueryCategoriesAsync(async () =>
            {
                var result = new ServiceResult<IEnumerable<QueryCategoryDto>>();
                //var result = new ServiceResult<IEnumerable<QueryCategoryForAdminDto>>();

                //var posts = await _postRepository.GetListAsync();

                //var categories = _categoryRepository.GetListAsync().Result.Select(x => new QueryCategoryForAdminDto
                //{
                //    Id = x.Id,
                //    CategoryName = x.CategoryName,
                //    DisplayName = x.DisplayName,
                //    Count = posts.Count(p => p.CategoryId == x.Id)
                //});

                var list = from category in await _categoryRepository.GetListAsync()
                           join posts in await _postRepository.GetListAsync()
                           on category.Id equals posts.CategoryId
                           group category by new
                           {
                               category.CategoryName,
                               category.DisplayName
                           } into g
                           select new QueryCategoryDto
                           {
                               CategoryName = g.Key.CategoryName,
                               DisplayName = g.Key.DisplayName,
                               Count = g.Count()
                           };

                result.IsSuccess(list);
                return result;
            });
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCategoryAsync(string name)
        {
            return await _blogCacheService.GetCategoryAsync(name, async () =>
            {
                var result = new ServiceResult<string>();

                var category = await _categoryRepository.FindAsync(x => x.DisplayName.Equals(name));
                if (null == category)
                {
                    result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("分类", name));
                    return result;
                }

                result.IsSuccess(category.CategoryName);
                return result;
            });
        }
    }
}