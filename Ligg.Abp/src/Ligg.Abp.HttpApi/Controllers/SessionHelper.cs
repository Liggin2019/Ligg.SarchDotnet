using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Ligg.Abp.HttpApi.Controllers
{
    public class SessionHelper
    {
        private IHttpContextAccessor _accessor;

        private ISession _session;
        private IRequestCookieCollection _requestCookie;
        private IResponseCookies _responseCookie;
        public SessionHelper(HttpContext context)
        {
            _session = context.Session;
            _requestCookie = context.Request.Cookies;
            _responseCookie = context.Response.Cookies;
        }
        /// <summary>
        /// 设置session值
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetSession(string key, string value)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(value);
            _session.Set(key, bytes);
        }
        /// <summary>
        /// 获取Session值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSession(string key)
        {
            Byte[] bytes;
            _session.TryGetValue(key, out bytes);
            var value = System.Text.Encoding.UTF8.GetString(bytes);

            if (string.IsNullOrEmpty(value))
            {
                value = string.Empty;
            }
            return value;
        }
        ///// <summary>
        ///// 设置本地cookie
        ///// </summary>
        ///// <param name="key">键</param>
        ///// <param name="value">值</param>
        ///// <param name="minutes">过期时间</param>
        //public void SetCookies(string key,string value,int day = 1)
        //{
        //    _responseCookie.Append(key, value, new CookieOptions
        //    {
        //        Expires = DateTime.Now.AddDays(day)
        //    }) ;
        //}
        //public void  DeleteCookies(string key)
        //{
        //    _responseCookie.Delete(key);
        //}
        //public string GetCookiesValue(string key)
        //{
        //    _requestCookie.TryGetValue(key, out string value);
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        value = string.Empty;
        //    }
        //    return value;
        //}

    }
}
