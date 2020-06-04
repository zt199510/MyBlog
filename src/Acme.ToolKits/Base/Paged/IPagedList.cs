using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ToolKits.Base.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}
