using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ToolKits.Base.Paged
{
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }
    }
}
