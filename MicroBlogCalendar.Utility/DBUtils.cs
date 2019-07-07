using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 数据库操作
    /// </summary>
    public class DBUtils
    {
        /// <summary>
        /// 设置事件的时间
        /// </summary>
        public static int SetEventDate()
        {
            DateTime d;

            string sql = "select result.tid,created_at,time from home_timeline,result where home_timeline.tid = result.tid and  result.event_date is null";
            var table = SQLiteHelper.ExecuteDataTable(sql);

            string sql2 = "update result set event_date = @date where tid=@tid";

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var baseDate = Convert.ToDateTime(table.Rows[i][1]);
                bool isOk = DateUtils.TryParseDate(table.Rows[i][2].ToString(), baseDate, out d);

                SQLiteParameter[] pms = new SQLiteParameter[]
                {
                new SQLiteParameter("date",isOk?d.ToString("yyyy-MM-dd hh:mm:ss"):baseDate.ToString("yyyy-MM-dd hh:mm:ss")),
                new SQLiteParameter("tid",table.Rows[i][0]),
                };
                SQLiteHelper.ExecuteNonQuery(sql2, pms);
                Console.WriteLine("【时间提取】处理第 {0} / {1} 个,进度 {2:f2} %", i, table.Rows.Count, ((float)i / table.Rows.Count) * 100);
            }
            return table.Rows.Count;
        }

    }
}
