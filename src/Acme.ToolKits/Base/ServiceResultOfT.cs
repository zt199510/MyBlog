using Acme.ToolKits.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.ToolKits.Base
{
   public class ServiceResult<T>:ServiceResult where T:class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void IsSuccess(T result = null, string message = "")
        {
            
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }
    }
}
