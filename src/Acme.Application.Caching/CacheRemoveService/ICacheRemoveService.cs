using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Application.Caching
{
    public interface ICacheRemoveService
    {
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        Task RemoveAsync(string key, int cursor = 0);
    }
}
