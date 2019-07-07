using HtmlAgilityPack;
using NetDimension.Weibo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    public class Spider
    {
        /// <summary>
        /// 在一个线程中不断地获取最新的微博数据，默认每隔10分钟获取1次.
        /// 每天调用超过上限将会导致当天不能再调用
        /// </summary>
        /// <param name="everyMinutes">调用时间间隔</param>
        public static Thread GetHomeTimelineRepeat(string appKey, string appSecret, string accessToken,int everyMinutes = 10)
        {
            Thread t = new Thread(new ThreadStart(() => {
                while (true)
                {
                    try
                    {
                        int n = GetHomeTimeline(appKey,appSecret,accessToken);
                        Console.WriteLine("------------------------------------");
                        Shell.WriteLine("抓到{0}条微博", ConsoleColor.Blue, n);
                        Console.WriteLine("------------------------------------");
                        Thread.Sleep(1000 * 60 * everyMinutes);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("------------------------------------");
                        Shell.WriteLine(e.Message, ConsoleColor.Red);
                        Console.WriteLine("------------------------------------");
                        Thread.Sleep(1000 * 60 * 10);
                    }

                }
            }));
            t.IsBackground = true;
            t.Start();
            return t;
        }
        /// <summary>
        /// 获取当前登录用户及其所关注用户的最新微博，插入到数据库中
        /// </summary>
        /// <returns>记录的条数</returns>
        public static int GetHomeTimeline(string appKey,string appSecret,string accessToken)
        {
            int page = 1, count = 0;
            string jsonString = string.Empty;
            OAuth auth = new OAuth(appKey, appSecret, accessToken, null);
            Client client = new Client(auth);
            label: WeiboParameter p1 = new WeiboParameter("count", 100);
            WeiboParameter p2 = new WeiboParameter("page", page);
            try
            {
                jsonString = client.GetCommand("statuses/home_timeline", p1, p2); //这里可以使用字典或者匿名类的方式传递参数，参数名称、大小写、参数顺序和规范请参照官方api文档
            }
            catch (Exception ex)
            {
                Shell.WriteLine(ex.Message,ConsoleColor.Red);
                return 0;
            }
            
            dynamic dynamicJson = JsonConvert.DeserializeObject(jsonString);

            for (int i = 0; i < dynamicJson.statuses.Count; i++)
            {
                var item = dynamicJson.statuses[i];
                //获取微博信息
                DateTime createTime = NetDimension.Weibo.Utility.ParseUTCDate(item.created_at.ToString());
                string createAt = createTime.ToString("yyyy-MM-dd hh:mm:ss");
                string id = item.idstr.ToString();
                string text = item.text.ToString();
                string original_pic = item.original_pic == null ? string.Empty : item.original_pic.ToString();
                //忽略字数小于25的微博
                if (text.Length < 25)
                {
                    continue;
                }
                //获取该条微博的用户信息
                var user = item.user;
                string uid = user.idstr.ToString();
                string name = user.name.ToString();
                string gender = user.gender.ToString();
                string location = user.location.ToString();
                string description = user.description.ToString();
                //插入home_timeline表
                string sql = "insert or ignore into home_timeline(tid,created_at,text,uid,original_pic) values(@id,@created_at,@text,@userid,@original_pic)";
                SQLiteParameter[] pms = new SQLiteParameter[] {
                new SQLiteParameter("id", id),
                new SQLiteParameter("created_at", createAt),
                new SQLiteParameter("text", text),
                new SQLiteParameter("userid", uid),
                new SQLiteParameter("original_pic", original_pic),
            };
                SQLiteHelper.ExecuteNonQuery(sql, pms);
                //插入用户表
                string sql2 = "insert or ignore into user(uid,name,gender,location,description) values(@id,@name,@gender,@location,@description)";
                SQLiteParameter[] pms2 = new SQLiteParameter[] {
                new SQLiteParameter("id", uid),
                new SQLiteParameter("name", name),
                new SQLiteParameter("gender", gender),
                new SQLiteParameter("location", location),
                new SQLiteParameter("description", description)
            };
                SQLiteHelper.ExecuteNonQuery(sql2, pms2);
                Console.WriteLine(text);
            }
            if (dynamicJson.statuses.Count == 0)
            {
                return count;
            }
            count += dynamicJson.statuses.Count;
            if (count < Convert.ToInt32(dynamicJson.total_number))
            {
                page++;
                goto label;
            }

            return count;
        }

        /// <summary>
        /// 获取热搜榜
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHotTable()
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("title");
            dt.Columns.Add("count");

            try
            {
                HttpWebRequest request = WebRequest.CreateHttp("https://s.weibo.com/top/summary?cate=realtimehot");
                Stream stream = request.GetResponse().GetResponseStream();

                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(stream, Encoding.UTF8);
                var nodes = doc.DocumentNode.SelectNodes(@"//*[@id='pl_top_realtimehot']/table/tbody/tr");


                for (int i = 0; i <= 20 && i < nodes.Count; i++)
                {
                    var item = nodes[i];
                    try
                    {
                        var row = dt.NewRow();
                        var title = item.SelectSingleNode("td[2]/a").InnerText;
                        var count = Convert.ToInt32(item.SelectSingleNode("td[2]/span").InnerText);
                        row.SetField(0, title);
                        row.SetField(1, count);
                        dt.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        //第一个因为没有count必定抛异常，直接忽略
                        //throw;
                        Console.WriteLine(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                var row = dt.NewRow();
                row.SetField(0, "未获取到热搜数据");
                row.SetField(1, 0);
                dt.Rows.Add(row);
                //throw;
            }
            return dt;
        }

        /// <summary>
        /// 获取话题榜
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTopicList()
        {
            List<string> topList = new List<string>();

            try
            {
                HttpWebRequest request = WebRequest.CreateHttp("https://s.weibo.com/top/summary?cate=socialevent");
                Stream stream = request.GetResponse().GetResponseStream();

                HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(stream, Encoding.UTF8);
                var nodes = doc.DocumentNode.SelectNodes(@"//*[@id='pl_top_realtimehot']/table/tbody/tr");

                for (int i = 0; i < nodes.Count; i++)
                {
                    var item = nodes[i];
                    try
                    {
                        var title = item.SelectSingleNode("td[2]/a").InnerText;
                        topList.Add(title);
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                }
            }
            catch (Exception)
            {
                topList.Add("未获取到热门话题");
                //throw;
            }

            return topList;

        }
    }
}
