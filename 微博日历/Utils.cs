using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using WordCloudSharp;
using Newtonsoft.Json;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MicroBlogCalendar.Utility;

namespace 微博日历
{
    class Utils
    {
        static List<Image> imgs = null;

        static Utils()
        {
            imgs = new List<Image>();
            var files = Directory.GetFiles("Resource/");
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".gif")
                {
                    imgs.Add(Image.FromFile(files[i]));
                }
            }
        }
        /// <summary>
        /// 随机返回一张图片
        /// </summary>
        /// <returns></returns>
        internal static Image GetRandomImg()
        {
            try
            {
                Random r = new Random();
                return imgs[r.Next(imgs.Count - 1)];
            }
            catch (Exception)
            {

                //throw;
            }
            return null;
        }
        /// <summary>
        /// 从网络流中读取图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image ImageFrom(string url)
        {
            if (!NetUtils.IsConnectInternet())
            {
                return Utils.GetRandomImg();
            }
            try
            {
                var resp = WebRequest.CreateHttp(url).GetResponse().GetResponseStream();
                
                return Image.FromStream(resp);
            }
            catch (Exception e)
            {
                return Utils.GetRandomImg();
                //throw;
            }

        }

    }
}