namespace Ligg.Abp.Domain.Shared
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class Consts
    {
        /// <summary>
        /// 分组
        /// </summary>
        public static class Grouping
        {
            public const string GroupName_com = "com";
            public const string GroupName_com1 = "com1";

            public const string GroupName_adm = "adm";

            public const string GroupName_cfg = "cfg";

            public const string GroupName_erp_cfg = "erp-cfg";
            public const string GroupName_erp_biz_pd = "erp-biz-pd";
            public const string GroupName_erp_biz_pm = "erp-biz-pm";
            public const string GroupName_erp_biz_wm = "erp-biz-wm";
            public const string GroupName_erp_biz_pp = "erp-biz-pp";

            public const string GroupName_cms = "cms";

            public const string GroupName_oa_cfg = "oa-cfg";
            public const string GroupName_oa_biz = "oa-biz";
        }


        public const string GreetWord = "欢迎登录：{0}，{1}";




        /// <summary>
        /// 缓存过期时间策略
        /// </summary>
        public static class CacheStrategy
        {
            /// <summary>
            /// 一天过期24小时
            /// </summary>

            public const int ONE_DAY = 1440;

            /// <summary>
            /// 12小时过期
            /// </summary>

            public const int HALF_DAY = 720;

            /// <summary>
            /// 8小时过期
            /// </summary>

            public const int EIGHT_HOURS = 480;

            /// <summary>
            /// 5小时过期
            /// </summary>

            public const int FIVE_HOURS = 300;

            /// <summary>
            /// 3小时过期
            /// </summary>

            public const int THREE_HOURS = 180;

            /// <summary>
            /// 2小时过期
            /// </summary>

            public const int TWO_HOURS = 120;

            /// <summary>
            /// 1小时过期
            /// </summary>

            public const int ONE_HOURS = 60;

            /// <summary>
            /// 半小时过期
            /// </summary>

            public const int HALF_HOURS = 30;

            /// <summary>
            /// 5分钟过期
            /// </summary>
            public const int FIVE_MINUTES = 5;

            /// <summary>
            /// 1分钟过期
            /// </summary>
            public const int ONE_MINUTE = 1;

            /// <summary>
            /// 永不过期
            /// </summary>

            public const int NEVER = -1;
        }

        /// <summary>
        /// 响应文本
        /// </summary>
        public static class ResponseText
        {
            /// <summary>
            /// 新增成功
            /// </summary>
            public const string INSERT_SUCCESS = "新增成功";

            /// <summary>
            /// 更新成功
            /// </summary>
            public const string UPDATE_SUCCESS = "更新成功";

            /// <summary>
            /// 删除成功
            /// </summary>
            public const string DELETE_SUCCESS = "删除成功";

            /// <summary>
            /// 什么不存在
            /// </summary>
            public const string WHAT_NOT_EXIST = "{0}:{1} 不存在";

            /// <summary>
            /// 数据为空
            /// </summary>
            public const string DATA_IS_NONE = "数据为空";

            /// <summary>
            /// IP地址格式错误
            /// </summary>
            public const string IP_IS_WRONG = "IP地址格式错误";

            /// <summary>
            /// 图片错误
            /// </summary>
            public const string IMG_IS_WRONG = "图片错误";

            /// <summary>
            /// 密码错误
            /// </summary>
            public const string PASSWORD_WRONG = "密码错误";

            /// <summary>
            /// 参数错误
            /// </summary>
            public const string PARAMETER_ERROR = "参数错误";
        }

    }


    public static class StringMaxLength
    {
        public const int Code = 16;
        public const int Name = 32;
        public const int Description = 64;
        public const int Remark = 128;
        public const int Body = 32384;
    }
}