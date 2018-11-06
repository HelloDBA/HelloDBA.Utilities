using System;

namespace HelloDBA.Utilities.DateUtility
{
    public class DateHelper
    {
        /// <summary>
        /// 根据传入的工作日天数，获得计算后的日期,可传负数
        /// </summary>
        /// <param name="day">天数</param>
        /// <param name="isContainToday">当天是否算工作日（默认：true）</param>
        /// <returns></returns>
        public static DateTime GetReckonDate(DateTime beginDate, int day, bool isContainToday = true)
        {
            DateTime currDate = beginDate;
            int addDay = day >= 0 ? 1 : -1;

            if (isContainToday)
                currDate = currDate.AddDays(-addDay);

            int sumDay = Math.Abs(day);
            int workDayNum = 0;
            while (workDayNum < sumDay)
            {
                currDate = currDate.AddDays(addDay);
                if ((int)currDate.DayOfWeek > 0 && (int)currDate.DayOfWeek < 6)
                    workDayNum++;
            }
            return currDate;
        }
    }
}
