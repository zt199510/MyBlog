using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Application.Contracts.Blog
{
  public  class QueryPostForAdminDto: QueryPostDto
    {
        /// <summary>
     /// Posts
     /// </summary>
        public new IEnumerable<PostBriefForAdminDto> Posts { get; set; }
    }
}
