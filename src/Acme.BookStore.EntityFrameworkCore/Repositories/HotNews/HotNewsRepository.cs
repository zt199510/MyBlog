using Acme.BookStore.Domain.HotNews.Repostiories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore.Repositories.HotNews
{
    /// <summary>
    /// HotNewsRepository
    /// </summary>
    public class HotNewsRepository : EfCoreRepository<AcmeBlogDbContext, Domain.HotNews.HotNews, Guid>, IHotNewsRepository
    {
        public HotNewsRepository(IDbContextProvider<AcmeBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="hotNews"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Domain.HotNews.HotNews> hotNews)
        {
            await DbContext.Set<Domain.HotNews.HotNews>().AddRangeAsync(hotNews);
            await DbContext.SaveChangesAsync();
        }
    }
}
