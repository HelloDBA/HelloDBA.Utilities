using System;
using System.Web;
using Newtonsoft.Json;

namespace HelloDBA.Utilities.CookieUtility
{
    public class Cookie
    {
        #region Cookie操作
        #region 写入Cookie
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(分钟数)</param>
        /// <param name="DESKey">DES加密key值</param>
        public static void WriteCookie(string strName, string strValue, int expires, string DESKey)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = DESKey == "" ? strValue : SecurityUtility.DESEncrypt.Encrypt(strValue, DESKey);
            if (expires != 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        public static void WriteCookie(string strName, string strValue)
        {
            WriteCookie(strName, strValue, 0, "");
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            WriteCookie(strName, strValue, expires, "");
        }

        public static void WriteObjectCookie(string strName, object objectValue, int expires, string DESKey)
        {
            var strValue = objectValue == null ? "" : JsonConvert.SerializeObject(objectValue);
            WriteCookie(strName, strValue, expires, DESKey);
        }
        public static void WriteObjectCookie(string strName, object objectValue, string DESKey)
        {
            WriteObjectCookie(strName, objectValue, 0, DESKey);
        }
        public static void WriteObjectCookie(string strName, object objectValue, int expires)
        {
            WriteObjectCookie(strName, objectValue, expires, "");
        }
        public static void WriteObjectCookie(string strName, object objectValue)
        {
            WriteObjectCookie(strName, objectValue, 0, "");
        }
        #endregion

        #region 读取Cookie
        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="DESKey">DES解密Key值</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string DESKey)
        {
            string rt = "";
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                rt = HttpContext.Current.Request.Cookies[strName].Value;
                if (DESKey != "")
                {
                    rt = SecurityUtility.DESEncrypt.Decrypt(rt, DESKey);
                }
            }
            return rt;
        }
        public static string GetCookie(string strName)
        {
            return GetCookie(strName, "");
        }
        public static T GetObjectCookie<T>(string strName, string DESKey)
        {
            var o = default(T);
            var strValue = GetCookie(strName, DESKey);
            if (strValue != "")
            {
                o = JsonConvert.DeserializeObject<T>(strValue);
            }
            return o;
        }
        public static T GetObjectCookie<T>(string strName)
        {
            return GetObjectCookie<T>(strName, "");
        }
        #endregion

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        public static void RemoveCookie(string CookiesName)
        {
            HttpCookie objCookie = new HttpCookie(CookiesName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }
        #endregion
    }
}
