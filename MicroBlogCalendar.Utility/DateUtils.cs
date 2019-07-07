using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 日期工具类
    /// </summary>
    public class DateUtils
    {
        /// <summary>
        /// 解析文本中的日期
        /// </summary>
        /// <param name="text">待解析的文本,这是一个时间短语，而非一个句子</param>
        /// <param name="baseDate">基准日期,通常为微博发布的日期</param>
        /// <param name="result">解析结果</param>
        /// <returns>指示是否解析成功</returns>
        public static bool TryParseDate(string text, DateTime baseDate, out DateTime result)
        {
            result = baseDate;
            var isOK = DateTime.TryParse(text, new System.Globalization.CultureInfo("zh-CN", true), System.Globalization.DateTimeStyles.None, out result);
            if (isOK)
            {
                //假如原微博2019年5月1日发布，抽取到的命名实体为"2日"，
                //那么上面这句因为程序只认识"2日"，年份会变为当前年份，月份变为1，即时间变成了2019年1月2日
                //所以这里还要修正,但是由于需要考虑到的情况比较多,暂时就先这样了
                return true;
            }
            if (Regex.IsMatch(text, "今天|今日"))
            {
                return true;
            }
            if (Regex.IsMatch(text, "明天|明日"))
            {
                result = baseDate.AddDays(1);
                return true;
            }
            if (Regex.IsMatch(text, "昨天|昨日"))
            {
                result = baseDate.AddDays(-1);
                return true;
            }
            if (Regex.IsMatch(text, "后天"))
            {
                result = baseDate.AddDays(2);
                return true;
            }
            if (Regex.IsMatch(text, "前天"))
            {
                result = baseDate.AddDays(-2);
                return true;
            }
            if (Regex.IsMatch(text, "去年"))
            {
                result = baseDate.AddYears(-1);
                return true;
            }
            /*
            var collection = Regex.Matches(text, "(本|上|下)*(周|星期)(一|二|三|四|五|六|七)");
            if (collection.Count>0)
            {
                Console.WriteLine(collection[0]);
            }*/
            return false;
        }

        /// <summary>
        /// 返回所给日期是星期几
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DayOfWeek(DateTime date)
        {
            string[] weeks = { "日", "一", "二", "三", "四", "五", "六" };
            return string.Format("星期{0}", weeks[(int)date.DayOfWeek]);
        }
    }
}
