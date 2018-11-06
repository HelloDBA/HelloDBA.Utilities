using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelloDBA.Utilities.MobileUtility
{
    public class Mobile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobilePhone(string PhoneNum)
        {
            Regex regex = new Regex("^1\\d{10}$");
            return regex.IsMatch(PhoneNum);

        }
    }
}
