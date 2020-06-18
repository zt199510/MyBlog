using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Application.Contracts.Blog
{
    public class FriendLinkDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
