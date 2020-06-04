using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Domain.Shared
{
    public class AcmeBlogConsts
    {
        public const string DbTablePrefix = "meowv_";
    }
    public static class Grouping
    {
        /// <summary>
        /// 博客前台接口组
        /// </summary>
        public const string GroupName_v1 = "v1";

        /// <summary>
        /// 博客后台接口组
        /// </summary>
        public const string GroupName_v2 = "v2";

        /// <summary>
        /// 其他通用接口组
        /// </summary>
        public const string GroupName_v3 = "v3";

        /// <summary>
        /// JWT授权接口组
        /// </summary>
        public const string GroupName_v4 = "v4";
    }
}
