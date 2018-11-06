namespace HelloDBA.Utilities.SecurityUtility
{
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {

            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = DESEncrypt.CalMD5(str).Substring(8, 16);
            }
            if (code == 32)
            {
                strEncrypt = DESEncrypt.CalMD5(str);
            }

            return strEncrypt;
        }
    }
}
