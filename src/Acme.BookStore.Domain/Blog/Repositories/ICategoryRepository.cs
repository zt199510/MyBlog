using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Domain.Blog.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
