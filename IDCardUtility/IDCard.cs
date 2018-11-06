using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDBA.Utilities.IDCardUtility
{
    public class IDCard
    {
        /// <summary>
        /// 检查身份证号是否符合规则
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool CheckIDCard18(string Id)
        {
            if (string.IsNullOrEmpty(Id) || Id.Length != 18) return false;
            long i = 0L;
            if (long.TryParse(Id.Remove(17), out i) && !((double)i < Math.Pow(10.0, 16.0)) && long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out i))
            {
                string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
                if (address.IndexOf(Id.Remove(2)) == -1)
                {
                    return false;
                }
                string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                DateTime time = default(DateTime);
                if (!DateTime.TryParse(birth, out time))
                {
                    return false;
                }
                string[] arrVarifyCode = "1,0,x,9,8,7,6,5,4,3,2".Split(',');
                string[] Wi = "7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2".Split(',');
                char[] Ai = Id.Remove(17).ToCharArray();
                int sum = 0;
                for (int j = 0; j < 17; j++)
                {
                    sum += int.Parse(Wi[j]) * int.Parse(Ai[j].ToString());
                }
                int y = -1;
                Math.DivRem(sum, 11, out y);
                if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
