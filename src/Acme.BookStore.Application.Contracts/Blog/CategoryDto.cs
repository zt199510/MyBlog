using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Application.Contracts.Blog
{
    public class CategoryDto
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 展示名称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
