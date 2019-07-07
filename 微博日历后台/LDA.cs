using MicroBlogCalendar.Utility;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微博日历后台
{
    /// <summary>
    /// 包含了利用LDA主题模型训练、预测、保存模型所需的各种方法
    /// </summary>
    static class LDA
    {

        /// <summary>
        /// 从数据库随机获取LDA训练文档
        /// </summary>
        /// <param name="count">返回多少条数据</param>
        /// <param name="minLen">每个文档的最短长度,小于此长度的微博将被忽略</param>
        /// <returns></returns>
        public static List<string> GetLDATrainDoc(int count = int.MaxValue - 1, int minLen = 70)
        {
            List<string> list = new List<string>();

            string sql = "select text from home_timeline where LENGTH(text) > @minLen order by random() limit 1,@count;";
            SQLiteParameter[] pms = new SQLiteParameter[]
            {
            new SQLiteParameter("count",count+1),
            new SQLiteParameter("minLen",minLen),
            };
            var reader = SQLiteHelper.ExecuteReader(sql, pms);

            while (reader.Read())
            {
                var sentence = reader.GetString(0);
                list.Add(sentence);
            }

            return list;
        }

        /// <summary>
        /// 从数据库获取LDA预测文档,返回所有话题字段为空的微博（前2000个，数据量过大程序运行较慢）
        /// </summary>
        /// <param name="tidList">微博的id,与返回的预测文档集合相对应</param>
        /// <returns></returns>
        public static List<string> GetLDAInferDoc(out List<string> tidList)
        {
            List<string> list = new List<string>();
            tidList = new List<string>();
            string sql = "select tid,text from home_timeline where  tid  in (SELECT tid from result where topic is null) limit 0,2000";
            var reader = SQLiteHelper.ExecuteReader(sql);

            while (reader.Read())
            {
                var tid = reader.GetString(0);
                var sentence = reader.GetString(1);
                list.Add(sentence);
                tidList.Add(tid);
            }

            return list;
        }

        /// <summary>
        /// 将LDA训练文档或预测文档写入文件
        /// </summary>
        /// <param name="data">已经分好词的文章列表</param>
        /// <param name="path">要保存的文件路径</param>
        public static void WriteLdaDocToFile(List<List<string>> data, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);//使用ANSI编码,不能使用UTF8编码
            sw.WriteLine(data.Count);//第1行是总共的文章篇数
            foreach (var wordList in data)//后面跟着n行数据,数据间不能有空行
            {
                sw.WriteLine(string.Join(" ", wordList));
            }
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// 获取主题标签映射,如果重新生成了LDA主题模型，主题标签需要重新进行人工手动指定
        /// </summary>
        /// <param name="path">data/ldaTopicLabel.txt</param>
        /// <returns></returns>
        public static string[] GetTopicLabel(string path)
        {
            var sr = File.OpenText(path);
            List<string> list = new List<string>();
            string line = null;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                list.Add(line.Trim());
            }
            sr.Close();
            return list.ToArray();
        }
        /// <summary>
        /// 设置主题标签映射,如果重新生成了LDA主题模型，主题标签需要重新进行人工手动指定
        /// </summary>
        /// <param name="path">data/ldaTopicLabel.txt</param>
        /// <returns></returns>
        public static void SetTopicLabel(string[] labels,string path)
        {
            var sw = File.CreateText(path);
            foreach (var item in labels)
            {
                sw.WriteLine(item);
            }
            sw.Close();
        }

        /// <summary>
        /// 读取话题-词分布文件
        /// </summary>
        /// <param name="twordsFile">data/*.twords</param>
        /// <returns></returns>
        public static List<Dictionary<string, double>> ReadTopicWordsWeight(string twordsFile)
        {
            List<Dictionary<string, double>> twordsList = new List<Dictionary<string, double>>();
            FileStream fs = new FileStream(twordsFile,FileMode.Open);
            var sr = new StreamReader(fs, Encoding.Default);
            string line = null;
            Dictionary<string, double> topic = null;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                if (line.StartsWith("Topic"))
                {
                    if (topic != null)
                    {
                        twordsList.Add(topic);
                    }
                    topic = new Dictionary<string, double>();
                }
                else
                {
                    var wordWeight = line.Trim().Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
                    topic.Add(wordWeight[0], double.Parse(wordWeight[1]));
                }
            }
            twordsList.Add(topic);
            sr.Close();
            fs.Close();
            return twordsList;
        }

        /// <summary>
        /// 从LDA++工具生成的文档-主题矩阵文件中读取数据，保存在二维数组中
        /// </summary>
        /// <param name="thetaFile">data/*.theta</param>
        /// <returns></returns>
        public static List<double[]> ReadDocumentTopicData(string thetaFile)
        {
            List<double[]> list = new List<double[]>();
            var sr = File.OpenText(thetaFile);
            string line = null;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                string[] numbers = line.Trim().Split();
                double[] lineNums = Array.ConvertAll(numbers, new Converter<string, double>(input => double.Parse(input)));
                list.Add(lineNums);
            }
            sr.Close();
            return list;
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="othersFile">data/*.others</param>
        /// <returns></returns>
        public static Dictionary<string, double> ReadOthersData(string othersFile)
        {
            Dictionary<string, double> others = new Dictionary<string, double>();
            var sr = File.OpenText(othersFile);
            string line = null;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                string[] numbers = line.Split('=');
                others.Add(numbers[0], Convert.ToDouble(numbers[1]));
            }
            sr.Close();
            return others;
        }

        /// <summary>
        /// 将文档-主题二维数组中每行数据排序，挑选出每个文档最有可能的主题的索引
        /// </summary>
        /// <param name="docTopicData">调用ReadDocmentTopicData()方法返回的列表</param>
        /// <returns></returns>
        public static List<int> GetDocmentTopicIndexList(List<double[]> docTopicData)
        {
            List<int> list = new List<int>(docTopicData.Count);
            for (int i = 0; i < docTopicData.Count; i++)
            {
                double max = docTopicData[i][0];
                int index = 0;
                for (int j = 1; j < docTopicData[i].Length; j++)
                {
                    if (max.CompareTo(docTopicData[i][j]) < 0)
                    {
                        max = docTopicData[i][j];
                        index = j;
                    }
                }
                list.Add(index);
            }
            return list;
        }

        /// <summary>
        /// 输出微博以及其对应的类别
        /// </summary>
        /// <param name="inferDocs">微博文本列表</param>
        /// <param name="topicIndex">文本对应的话题索引的列表</param>
        /// <param name="topicLabel">话题的标签</param>
        public static void PrintTopics(List<string> inferDocs,List<int> topicIndex,string[] topicLabel)
        {
            for (int i = 0; i < inferDocs.Count; i++)
            {
                Console.WriteLine("------------------------" + topicLabel[topicIndex[i]] + "------------------------------");
                Console.WriteLine(inferDocs[i]);
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 保存主题到数据库
        /// </summary>
        /// <param name="topic">主题分类</param>
        /// <param name="tid">微博id</param>
        public static void SaveTopicToDB(List<int> topicIndex, string[] topicLabel, List<string> tidList)
        {
            string sql = "update result set topic=@topic where tid= @tid;";
            for (int i = 0; i < tidList.Count; i++)
            {
                Console.WriteLine("【保存主题】保存第 {0} / {1} 个，进度 {2:f2} %", i, topicIndex.Count, ((float)i * 100 / topicIndex.Count));
                var tid = tidList[i];
                var topic = topicLabel[topicIndex[i]];
                SQLiteParameter[] pms = new SQLiteParameter[]
                {
                new SQLiteParameter("tid",tid),
                new SQLiteParameter("topic",topic),
                };

                SQLiteHelper.ExecuteNonQuery(sql, pms);
            }

        }
        /// <summary>
        /// 获得LDA模型的困惑度
        /// </summary>
        /// <param name="tw_list">topic word矩阵(.phi文件)的每一行</param>
        /// <param name="dt_list">document topic 矩阵（.theta）的每一行</param>
        /// <param name="as_list">.tassign文件的每一行</param>
        /// <returns></returns>
        public static double GetPerplexity(List<string[]> tw_list, List<string[]> dt_list, List<string[]> as_list)
        {
            double perp = 0.0;
            double sum_ln_pt = 0.0;
            int sum_t = 0;
            for (int i = 0; i < as_list.Count; i++)
            {
                string[] as_arr = as_list[i];
                sum_t += as_arr.Length;
                double pt = 0.0;
                foreach (string asa in as_arr)
                {
                    if (!string.IsNullOrWhiteSpace(asa))
                    {
                        double pz = 0.0;
                        string[] tz_arr = asa.Split(':');
                        int t_id = Convert.ToInt32(tz_arr[0]);
                        for (int j = 0; j < tw_list.Count; j++)
                        {
                            double p_tz = 0.0;
                            p_tz = Convert.ToDouble(tw_list[j][t_id]);
                            double p_zd = 0.0;
                            p_zd = Convert.ToDouble(dt_list[i][j]);
                            pz += p_tz * p_zd;
                        }
                        pt += Math.Log(pz);
                    }
                }
                sum_ln_pt += pt;
            }
            perp = Math.Pow(Math.E, (-sum_ln_pt / sum_t));
            return perp;
        }


    }
}
