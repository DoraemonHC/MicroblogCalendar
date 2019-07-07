using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 网络操作
    /// </summary>
    public class NetUtils
    {
        /// <summary>
        /// 获取本机广域网IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetWanIP()
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 2);
            var result = client.GetStringAsync("http://pv.sohu.com/cityjson?ie=utf-8");
            string pattern = string.Format(@"""cip"": ""(.*)"", ""cid"":");
            var match = Regex.Match(result.Result, pattern);
            if (match.Groups.Count >= 2)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "114.114.114.114";
            }
        }
        /// <summary>
        /// 根据IP地址获取位置
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetLocationByIP(string ip)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 2);
            var requestUri = string.Format("http://ip.taobao.com/service/getIpInfo.php?ip={0}", ip);
            var result = client.GetStringAsync(requestUri);
            dynamic obj = JsonConvert.DeserializeObject(result.Result);
            if (obj.code == 0)
            {
                return obj.data.city;
            }
            else
            {
                return "北京";
            }
        }
        /// <summary>
        /// 获取天气（这个接口预报不准）
        /// </summary>
        /// <returns></returns>
        public static string GetWeather2()
        {
            var ip = GetWanIP();
            var loc = GetLocationByIP(ip);
            string sql = string.Format("select cno from city where cname = '{0}'", loc);
            var cno = SQLiteHelper.ExecuteScalar(sql);

            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 2);
            var requestUri = string.Format("http://www.weather.com.cn/data/cityinfo/101{0}01.html", cno);
            var result = client.GetStringAsync(requestUri);

            return result.Result;
        }
        /// <summary>
        /// 根据城市编号获取天气
        /// </summary>
        /// <returns></returns>
        public static string GetWeatherByCno(string cno)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 2);
            var requestUri = string.Format("http://t.weather.sojson.com/api/weather/city/{0}", cno);
            var result = client.GetStringAsync(requestUri).Result;
            return result;
        }

        public static string GetCnoByLoc(string cname)
        {
            var sr = File.OpenText("Resource/_city.json");
            var city = sr.ReadToEnd();
            sr.Close();
            dynamic json = JsonConvert.DeserializeObject(city);

            for (int i = 0; i < json.Count; i++)
            {
                if (cname.Equals(json[i].city_name.ToString()))
                {
                    return json[i].city_code.ToString();
                }
            }
            return "101010100";
        }
        /// <summary>
        /// 根据IP自动获取本地天气
        /// </summary>
        /// <returns></returns>
        public static string GetWeather()
        {
            var ip = GetWanIP();
            var loc = GetLocationByIP(ip);
            var cno = GetCnoByLoc(loc);
            var weather = GetWeatherByCno(cno);
            return weather;
        }
        /// <summary>
        /// 创建天气预报城市列表，需要先把数据库表建好
        /// </summary>
        private static void InsertCityToDB()
        {
            //一级省份
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 2);
            var requestUri = string.Format("http://www.weather.com.cn/data/list3/city.xml?level=1");

            var result = client.GetStringAsync(requestUri);

            var pList = result.Result.Split(',');
            foreach (var item in pList)
            {
                var p = item.Split('|');
                string sql = string.Format("insert into province values('{0}','{1}');", p[0], p[1]);
                SQLiteHelper.ExecuteNonQuery(sql);
                //二级城市
                HttpClient client2 = new HttpClient();
                client2.Timeout = new TimeSpan(0, 0, 2);
                var requestUri2 = string.Format("http://www.weather.com.cn/data/list3/city{0}.xml?level=2", p[0]);

                var result2 = client2.GetStringAsync(requestUri2);

                var pList2 = result2.Result.Split(',');
                foreach (var jtem in pList2)
                {
                    var p2 = jtem.Split('|');
                    string sql2 = string.Format("insert into city values('{0}','{1}','{2}');", p2[0], p2[1], p[0]);
                    SQLiteHelper.ExecuteNonQuery(sql2);

                    //三级县市区
                }
            }
        }
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);
        /// <summary>
        /// 判断网络连接状态
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectInternet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }

}
}
