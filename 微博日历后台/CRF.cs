using MicroBlogCalendar.Model;
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
    /// 包含了利用CRF模型转换数据格式、训练模型、利用模型进行序列标注、保存到数据库的各种方法
    /// </summary>
    static class CRF
    {

        #region 语料格式转换
        /// <summary>
        /// 将一个或多个带有命名实体标注的anns格式的文件转为一个bio标注的文件(只有字特征)
        /// </summary>
        /// <param name="bioFile">要保存的文件名</param>
        /// <param name="annsFiles">要转换的文件列表</param>
        public static void ConvertAnnsToBio(string bioFile, params string[] annsFiles)
        {
            if (annsFiles == null)
            {
                return;
            }
            var fs = new FileStream(bioFile, FileMode.Create);
            var sw = new StreamWriter(fs, Encoding.UTF8);
            StreamReader sr;
            for (int j = 0; j < annsFiles.Length; j++)
            {
                sr = File.OpenText(annsFiles[j]);
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        sw.WriteLine();
                        continue;
                    }
                    var word = line.Split();

                    switch (word[1])
                    {
                        case "S-Name"://专有名词
                            sw.WriteLine(word[0][0] + "\t" + "B-Name");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Name");
                            }
                            break;
                        case "S-Person"://人名
                            sw.WriteLine(word[0][0] + "\t" + "B-Person");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Person");
                            }
                            break;
                        case "S-Location"://地名
                            sw.WriteLine(word[0][0] + "\t" + "B-Location");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Location");
                            }
                            break;
                        case "S-Organization"://机构名
                            sw.WriteLine(word[0][0] + "\t" + "B-Organization");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Organization");
                            }
                            break;
                        case "S-Event"://事件
                            sw.WriteLine(word[0][0] + "\t" + "B-Event");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Event");
                            }
                            break;
                        case "S-Count":
                            sw.WriteLine(word[0][0] + "\t" + "B-Count");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Count");
                            }
                            break;
                        case "S-Time"://日期时间
                            sw.WriteLine(word[0][0] + "\t" + "B-Time");
                            for (int i = 1; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "I-Time");
                            }
                            break;
                        default://非实体
                            for (int i = 0; i < word[0].Length; i++)
                            {
                                sw.WriteLine(word[0][i] + "\t" + "O");
                            }
                            break;
                    }
                }

                sr.Close();
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 将一个或多个带有命名实体标注的anns格式的文件转为一个bio标注的文件（包含字特征、词性特征）
        /// </summary>
        /// <param name="bioFile">要保存的文件名</param>
        /// <param name="annsFiles">要转换的文件列表</param>
        public static void ConvertAnnsToBio2(string bioFile, params string[] annsFiles)
        {
            if (annsFiles == null)
            {
                return;
            }
            var fs = new FileStream(bioFile, FileMode.Create);
            var sw = new StreamWriter(fs, Encoding.UTF8);

            List<MicroBlogCalendar.Model.Pair> tokens = null;

            StreamReader sr;
            for (int j = 0; j < annsFiles.Length; j++)
            {
                sr = File.OpenText(annsFiles[j]);
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        sw.WriteLine();
                        continue;
                    }
                    var word = line.Split();

                    tokens = Preprocessor.Cut(word[0]);
                    switch (word[1])
                    {
                        case "S-Name"://专有名词

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Name");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Name");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Name");
                                    }

                                }
                            }


                            break;
                        case "S-Person"://人名

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Person");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Person");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Person");
                                    }

                                }
                            }
                            break;
                        case "S-Location"://地名

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Location");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Location");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Location");
                                    }

                                }
                            }
                            break;
                        case "S-Organization"://机构名

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Organization");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Organization");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Organization");
                                    }

                                }
                            }
                            break;
                        case "S-Event"://事件

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Event");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Event");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Event");
                                    }

                                }
                            }
                            break;
                        case "S-Count":

                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Count");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Count");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Count");
                                    }

                                }
                            }
                            break;
                        case "S-Time"://日期时间
                            if (tokens.Count > 0)
                            {
                                sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B-Time");
                                for (int i = 1; i < tokens[0].Word.Length; i++)
                                {
                                    sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "I-Time");
                                }
                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "I-Time");
                                    }

                                }
                            }
                            break;
                        default://非实体
                            if (tokens.Count > 0)
                            {
                                for (int i = 0; i < tokens.Count; i++)
                                {
                                    for (int k = 0; k < tokens[i].Word.Length; k++)
                                    {
                                        sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "O");
                                    }

                                }
                            }
                            break;
                    }
                }

                sr.Close();
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 将一个或多个带有命名实体标注的anns格式的文件转为一个bio标注的文件（字特征、词性特征、词边界特征）
        /// </summary>
        /// <param name="bioFile">要保存的文件名</param>
        /// <param name="annsFiles">要转换的文件列表</param>
        public static void ConvertAnnsToBio3(string bioFile, params string[] annsFiles)
        {
            if (annsFiles == null)
            {
                return;
            }
            var fs = new FileStream(bioFile, FileMode.Create);
            var sw = new StreamWriter(fs, Encoding.UTF8);
            List<MicroBlogCalendar.Model.Pair> tokens = null;

            StreamReader sr;
            for (int j = 0; j < annsFiles.Length; j++)
            {
                sr = File.OpenText(annsFiles[j]);
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        sw.WriteLine();
                        continue;
                    }
                    var word = line.Split();

                    tokens = Preprocessor.Cut(word[0]);
                    switch (word[1])
                    {
                        case "S-Name"://专有名词

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Name");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Name");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Name");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Name");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Name");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Name");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Name");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Name");
                                    }

                                }
                            }


                            break;
                        case "S-Person"://人名

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Person");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Person");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Person");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Person");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Person");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Person");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Person");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Person");
                                    }

                                }
                            }

                            break;
                        case "S-Location"://地名

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Location");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Location");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Location");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Location");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Location");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Location");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Location");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Location");
                                    }

                                }
                            }

                            break;
                        case "S-Organization"://机构名

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Organization");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Organization");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Organization");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Organization");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Organization");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Organization");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Organization");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Organization");
                                    }

                                }
                            }

                            break;
                        case "S-Event"://事件

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Event");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Event");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Event");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Event");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Event");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Event");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Event");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Event");
                                    }

                                }
                            }
                            break;
                        case "S-Count":

                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Count");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Count");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Count");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Count");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Count");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Count");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Count");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Count");
                                    }

                                }
                            }
                            break;
                        case "S-Time"://日期时间
                            if (tokens.Count > 0)
                            {
                                //单个字组成词
                                if (tokens[0].Word.Length == 1)
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "W" + "\t" + "B-Time");
                                }
                                else
                                {
                                    sw.WriteLine(tokens[0].Word[0] + "\t" + tokens[0].Flag + "\t" + "B" + "\t" + "B-Time");
                                    for (int i = 1; i < tokens[0].Word.Length - 1; i++)
                                    {
                                        sw.WriteLine(tokens[0].Word[i] + "\t" + tokens[0].Flag + "\t" + "M" + "\t" + "I-Time");
                                    }
                                    sw.WriteLine(tokens[0].Word[tokens[0].Word.Length - 1] + "\t" + tokens[0].Flag + "\t" + "E" + "\t" + "I-Time");
                                }

                                for (int i = 1; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "I-Time");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "I-Time");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "I-Time");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "I-Time");
                                    }

                                }
                            }
                            break;
                        default://非实体
                            if (tokens.Count > 0)
                            {
                                //单个字组成词

                                for (int i = 0; i < tokens.Count; i++)
                                {
                                    if (tokens[i].Word.Length == 1)
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "W" + "\t" + "O");
                                    }
                                    else
                                    {
                                        sw.WriteLine(tokens[i].Word[0] + "\t" + tokens[i].Flag + "\t" + "B" + "\t" + "O");
                                        for (int k = 1; k < tokens[i].Word.Length - 1; k++)
                                        {
                                            sw.WriteLine(tokens[i].Word[k] + "\t" + tokens[i].Flag + "\t" + "M" + "\t" + "O");
                                        }
                                        sw.WriteLine(tokens[i].Word[tokens[i].Word.Length - 1] + "\t" + tokens[i].Flag + "\t" + "E" + "\t" + "O");
                                    }

                                }
                            }
                            break;
                    }
                }

                sr.Close();
            }
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 语料写入
        /// <summary>
        /// 将所给字符串写入文件，每行一个字符，共1列，1个特征：【字特征】
        /// </summary>
        /// <param name="text">要写入文件的字符串</param>
        /// <param name="path">保存路径</param>
        public static void WriteSentenceToFile(string text, string path)
        {
            var sw = File.CreateText(path);
            for (int i = 0; i < text.Length; i++)
            {
                sw.WriteLine(text[i]);
            }
            sw.Close();
        }
        /// <summary>
        /// 将所给字符串写入文件，每行一个字符，共3列，3个特征：【字特征、词性特征、词边界特征】
        /// </summary>
        /// <param name="text">要写入文件的字符串</param>
        /// <param name="path">保存路径</param>
        public static void WriteSentenceToFile3(string text, string path)
        {
            var sw = File.CreateText(path);
            var words = Preprocessor.Cut(text);
            foreach (var item in words)
            {
                if (item.Word.Length == 1)
                {
                    sw.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "W");
                }
                else
                {
                    sw.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B");
                    //每个字一行
                    for (int i = 1; i < item.Word.Length - 1; i++)
                    {
                        sw.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "M");
                    }
                    sw.WriteLine(item.Word[item.Word.Length - 1] + "\t" + item.Flag + "\t" + "E");
                }
            }
            /*
            for (int i = 0; i < text.Length; i++)
            {
                sw.WriteLine(text[i]);
            }*/
            sw.Close();
        }
        #endregion

        #region 提取命名实体
        /// <summary>
        /// 从数据库中选出所有没有进行过抽取的微博进行事件抽取，并将结果存入数据库
        /// </summary>
        public static void TestAll(string crfModel)
        {
            string sql = "select tid,text from home_timeline where tid not in (select tid from result);";
            var dt = SQLiteHelper.ExecuteDataTable(sql);
            string dir = Path.GetDirectoryName(Path.GetFullPath(crfModel));
            string testPath = Path.Combine(dir, "crfTestDoc.txt");
            string resultPath = Path.Combine(dir, "crfResultDoc.txt");
            string args = string.Format("-m {0} {1}", crfModel, testPath);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var tid = dt.Rows[i][0].ToString();
                var text = dt.Rows[i][1].ToString();

                WriteSentenceToFile3(Preprocessor.RemoveInvalidString(text), testPath);
                ProcessUtils.StartProcessRedirect("crf_test.exe", resultPath, args);
                var neList = GetNameEntityFromFile(resultPath);
                SaveNameEntityToDB(neList, tid);
                Console.WriteLine("【提取命名实体】已处理 {0} / {1} ,进度 {2:f2} % ", i, dt.Rows.Count, ((float)i * 100 / dt.Rows.Count));
            }
        }

        /// <summary>
        /// 打印命名实体列表
        /// </summary>
        /// <param name="list"></param>
        public static void PrintNameEntity(List<NameEntity> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Word + "---------------" + list[i].Type);
            }
        }

        /// <summary>
        /// 从CRF推测结果获取命名实体
        /// </summary>
        /// <param name="path">data/crfResultDoc.txt</param>
        /// <returns></returns>
        public static List<NameEntity> GetNameEntityFromFile(string path)
        {
            StreamReader reader = File.OpenText(path);
            string line = null;//每一行文本
            StringBuilder sb = new StringBuilder();//用于连接第一列的实体
            string lastType = "O";//上一行的实体类别
            List<NameEntity> list = new List<NameEntity>();//包含命名实体的数组
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;//略过空行
                }
                else
                {
                    string[] wordTag = line.Split();
                    //遇到实体首部，可能前一个是实体中部(根据缓冲区有无字词判断)，也可能是非实体
                    if (wordTag.Last().StartsWith("B-"))
                    {
                        //把上一个结果存进去，并清除缓存，并追加当前行
                        if (sb.Length != 0)
                        {
                            NameEntity ne = new NameEntity();
                            ne.Word = sb.ToString();
                            ne.Type = lastType.Substring(2);
                            list.Add(ne);
                            sb.Clear();
                            sb.Append(wordTag.First());
                        }
                        else
                        {
                            sb.Append(wordTag.First());
                        }
                    }
                    //遇到实体中部，只要继续追加字即可，因为不知道后面还有没有实体中部
                    else if (wordTag.Last().StartsWith("I-"))
                    {
                        sb.Append(wordTag.First());
                    }
                    //遇到非实体，可能是前一个实体结束，或者前一个也是非实体
                    else
                    {
                        if (lastType.StartsWith("I-") || lastType.StartsWith("B-"))
                        {
                            NameEntity ne = new NameEntity();
                            ne.Word = sb.ToString();
                            ne.Type = lastType.Substring(2);
                            list.Add(ne);
                            sb.Clear();
                        }
                        //若是B无效，若是O不管
                        //本来b后面是O隔了个I是无效的，但是可能是单个实体（只有头部）
                    }
                    //更新上个状态为这一行，然后继续下一行读取
                    lastType = wordTag.Last();
                }
            }
            reader.Close();
            return list;
        }

        /// <summary>
        /// 以空格分隔，合并同类命名实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Dictionary<string, string> MergeNameEntity(List<NameEntity> list)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var neCollection = list.Distinct(new NameEntityListEquality());//先去重
            StringBuilder nameBuilder = new StringBuilder();
            StringBuilder personBuilder = new StringBuilder();
            StringBuilder locationBuilder = new StringBuilder();
            StringBuilder organizationBuilder = new StringBuilder();
            StringBuilder eventBuilder = new StringBuilder();
            StringBuilder countBuilder = new StringBuilder();
            StringBuilder timeBuilder = new StringBuilder();
            foreach (var item in neCollection)
            {
                switch (item.Type)
                {
                    case "Person":
                        personBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Location":
                        locationBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Organization":
                        organizationBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Event":
                        eventBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Count":
                        countBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Time":
                        timeBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    case "Name":
                        nameBuilder.AppendFormat("{0} ", item.Word);
                        break;
                    default:
                        break;
                }
            }
            dict["Person"] = personBuilder.ToString();
            dict["Location"] = locationBuilder.ToString();
            dict["Organization"] = organizationBuilder.ToString();
            dict["Event"] = eventBuilder.ToString();
            dict["Count"] = countBuilder.ToString();
            dict["Time"] = timeBuilder.ToString();
            dict["Name"] = nameBuilder.ToString();
            return dict;
        }
        #endregion

        #region 保存到数据库
        /// <summary>
        /// 保存命名实体到数据库
        /// </summary>
        /// <param name="list">命名实体集合</param>
        /// <param name="tid">微博id</param>
        private static void SaveNameEntityToDB(List<NameEntity> list, string tid)
        {
            var dict = MergeNameEntity(list);
            string sql = "insert into result(tid,name,person,location,organization,event,count,time) values(@tid,@name,@person,@location,@organization,@event,@count,@time)";
            SQLiteParameter[] pms = new SQLiteParameter[]
            {
                new SQLiteParameter("tid",tid),
                new SQLiteParameter("name",dict["Name"]),
                new SQLiteParameter("person",dict["Person"]),
                new SQLiteParameter("location",dict["Location"]),
                new SQLiteParameter("organization",dict["Organization"]),
                new SQLiteParameter("event",dict["Event"]),
                new SQLiteParameter("count", dict["Count"] ),
                new SQLiteParameter("time", dict["Name"]),
            };

            SQLiteHelper.ExecuteNonQuery(sql, pms);
        }

        /// <summary>
        /// 更新命名实体到数据库
        /// </summary>
        /// <param name="list">命名实体集合</param>
        /// <param name="tid">微博id</param>
        private static void UpdateNameEntityToDB(List<NameEntity> list, string tid)
        {
            var dict = MergeNameEntity(list);
            string sql = "update result set name=@name,person=@person,location=@location,organization=@organization,event=@event,count=@count where tid=@tid";
            SQLiteParameter[] pms = new SQLiteParameter[]
            {
                new SQLiteParameter("tid",tid),
                new SQLiteParameter("name",dict["Name"]),
                new SQLiteParameter("person",dict["Person"]),
                new SQLiteParameter("location",dict["Location"]),
                new SQLiteParameter("organization",dict["Organization"]),
                new SQLiteParameter("event",dict["Event"]),
                new SQLiteParameter("count", dict["Count"] ),
                new SQLiteParameter("time", dict["Name"]),
            };

            SQLiteHelper.ExecuteNonQuery(sql, pms);
        }
        #endregion

        #region 模型评测相关

        /// <summary>
        /// 测试集至少要有3列，第一列为特征，第二列人工标注结果，第三列CRF标注结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="precision"></param>
        /// <param name="recall"></param>
        /// <param name="fMeasure"></param>
        public static void Score(string path, ref float precision, ref float recall, ref float fMeasure)
        {
            //nRecognizedRight提取出的正确信息条数
            //nRecognizedAll提取出的信息条数
            //nSampleAll样本中的信息条数
            int nRecognizedRight = 0, nRecognizedAll = 0, nSampleAll = 0;
            var sr = System.IO.File.OpenText(path);
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var words = line.Split();
                if (words[1].StartsWith("B-"))//这里简单地以实体头部判断是否提取正确，而不管头部以后是否一致
                {
                    nSampleAll++;
                    if (words[1] == words[2])
                    {
                        nRecognizedRight++;
                        nRecognizedAll++;
                    }
                    else if (words[2].StartsWith("B-"))
                    {
                        nRecognizedAll++;
                    }
                }

            }

            precision = 1.0f * nRecognizedRight / nRecognizedAll;//正确率
            recall = 1.0f * nRecognizedRight / nSampleAll;//召回率
            fMeasure = 2 * precision * recall / (precision + recall);//F值

        }
        /// <summary>
        /// 测试集至少要有4列，第1、2列为特征，第3列人工标注结果，第4列CRF标注结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="precision"></param>
        /// <param name="recall"></param>
        /// <param name="fMeasure"></param>
        public static void Score2(string path, ref float precision, ref float recall, ref float fMeasure)
        {
            //nRecognizedRight提取出的正确信息条数
            //nRecognizedAll提取出的信息条数
            //nSampleAll样本中的信息条数
            int nRecognizedRight = 0, nRecognizedAll = 0, nSampleAll = 0;
            var sr = System.IO.File.OpenText(path);
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var words = line.Split();
                if (words[2].StartsWith("B-"))//这里简单地以实体头部判断是否提取正确，而不管头部以后是否一致
                {
                    nSampleAll++;
                    if (words[2] == words[3])
                    {
                        nRecognizedRight++;
                        nRecognizedAll++;
                    }

                }
                if (words[3].StartsWith("B-"))
                {
                    nRecognizedAll++;
                }
            }

            precision = 1.0f * nRecognizedRight / nRecognizedAll;//正确率
            recall = 1.0f * nRecognizedRight / nSampleAll;//召回率
            fMeasure = 2 * precision * recall / (precision + recall);//F值

        }
        /// <summary>
        /// 测试集至少要有5列，第1、2、3列为特征，第4列人工标注结果，第5列CRF标注结果
        /// </summary>
        /// <param name="path"></param>
        /// <param name="precision"></param>
        /// <param name="recall"></param>
        /// <param name="fMeasure"></param>
        public static void Score3(string path, ref float precision, ref float recall, ref float fMeasure)
        {
            //nRecognizedRight提取出的正确信息条数
            //nRecognizedAll提取出的信息条数
            //nSampleAll样本中的信息条数
            int nRecognizedRight = 0, nRecognizedAll = 0, nSampleAll = 0;
            var sr = System.IO.File.OpenText(path);
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var words = line.Split();
                if (words[3].StartsWith("B-"))//这里简单地以实体头部判断是否提取正确，而不管头部以后是否一致
                {
                    nSampleAll++;
                    if (words[3] == words[4])
                    {
                        nRecognizedRight++;
                        nRecognizedAll++;
                    }
                    else if (words[4].StartsWith("B-"))
                    {
                        nRecognizedAll++;
                    }
                }
            }
            sr.Close();
            precision = 1.0f * nRecognizedRight / nRecognizedAll;//正确率
            recall = 1.0f * nRecognizedRight / nSampleAll;//召回率
            fMeasure = 2 * precision * recall / (precision + recall);//F值
        }
        #endregion
    }

}
