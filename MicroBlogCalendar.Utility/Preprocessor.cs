using JiebaNet.Segmenter;
using JiebaNet.Segmenter.PosSeg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Utility
{
    /// <summary>
    /// 文本预处理
    /// </summary>
    public class Preprocessor
    {
        private const string stop_words_path = @"Resources\停用词.txt";
        private const string user_dict_path = @"Resources\用户词典.txt";
        private static JiebaSegmenter seg = null;
        private static List<string> stopWordList = null;
        private static PosSegmenter posSeg = null;

        static Preprocessor()
        {
            seg = new JiebaSegmenter();
            posSeg = new PosSegmenter(seg);
            //载入用户词典
            seg.LoadUserDict(user_dict_path);
            //停用词
            stopWordList = GetStopWords();
        }

        /// <summary>
        /// 获取停用词表
        /// </summary>
        /// <returns></returns>
        private static List<string> GetStopWords()
        {
            var sr = File.OpenText(stop_words_path);
            string line = null;
            List<string> stopWordList = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                stopWordList.Add(line.Trim());
            }
            stopWordList.Add(" ");
            stopWordList.Add("\t");
            return stopWordList;
        }

        /// <summary>
        /// 分词并去除停用词
        /// </summary>
        /// <param name="sentences">句子列表</param>
        /// <param name="dropEmptySentence">是否删除空语句，如果删除,返回集合中元素可能变少，索引将无法一一对照</param>
        /// <returns></returns>
        public static List<List<string>> SegmentRemoveStopWords(List<string> sentences, bool dropEmptySentence = true,bool deleteNumber=true)
        {
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < sentences.Count; i++)
            {
                var str = RemoveInvalidString(sentences[i],deleteNumber);

                var wordList = seg.Cut(str);//分词
                
                wordList = wordList.Except(stopWordList);//去除停用词
                if (wordList.Count() < 1)//空行
                {
                    if (dropEmptySentence == false)
                    {
                        List<string> emptyList = new List<string>();
                        emptyList.Add(sentences[i]);
                        list.Add(emptyList);
                    }
                }
                else
                {
                    list.Add(wordList.ToList());
                }

            }
            return list;
        }

        /// <summary>
        /// 移除无效文本（主要是表情、网址、转发标记）
        /// 微博内容太杂，包含太多不可见字符和特殊字符，本程序只列出其中一部分
        /// 因此在后面的处理中可能会遇到新的问题
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveInvalidString(string input,bool deleteNumber=false)
        {
            //匹配[*]表情
            input = Regex.Replace(input, @"\[.+?]", string.Empty);
            //匹配网址
            input = Regex.Replace(input, @"http\S*", string.Empty, RegexOptions.IgnoreCase);
            //匹配转发标记
            input = Regex.Replace(input, @"@((.+?):|\S*)", string.Empty, RegexOptions.IgnoreCase);
            //去除零宽空白（8203)参考https://blog.csdn.net/edfeff/article/details/84919657
            input = input.Replace((char)8203, ' ');
            input = input.Replace((char)12288, ' ');//全角空格
            //去除可显示字符到最后一个汉字的ASCII码以外的字符，#号也去掉
            input = Regex.Replace(input, @"[^\u0020-\u9FA5]|#", string.Empty);
            if (deleteNumber)
            {
                input = Regex.Replace(input, @"\d", "");
            }
            return input.Trim();
        }
        /// <summary>
        /// 为发音人读出微博，移除微博中的无效文本
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveInvalidStringForSpeaking(string input)
        {
            //匹配[*]表情
            input = Regex.Replace(input, @"\[.+?]", string.Empty);
            //匹配网址
            input = Regex.Replace(input, @"http\S*", string.Empty, RegexOptions.IgnoreCase);
            //匹配转发标记
            input = Regex.Replace(input, @"@((.+?):|\S*)", string.Empty, RegexOptions.IgnoreCase);
            return input.Trim();
        }

        /// <summary>
        /// 读取文本中每一行
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static List<string> ReadLine(string path)
        {
            var sr = File.OpenText(path);
            List<string> list = new List<string>();
            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;//略过空行
                }
                list.Add(sr.ReadLine());
            }
            return list;
        }
        /// <summary>
        /// 分词、词性标注
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<MicroBlogCalendar.Model.Pair> Cut(string text)
        {
            var collection = posSeg.Cut(text);
            List<MicroBlogCalendar.Model.Pair> list = new List<Model.Pair>(collection.Count());
            foreach (var item in collection)
            {
                Model.Pair p = new Model.Pair(item.Word, item.Flag);
                list.Add(p);
            }
            return list;
        }
        /// <summary>
        /// 从文本中匹配网址
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetUrl(string text)
        {
            var mat = Regex.Match(text, "http:\\S*");
            if (mat.Success)
            {
                return mat.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        #region 以下代码是根据分词自动标注命名实体，因为底层分词技术的原因，识别结果较差，因此没有采用，放在这里备用
        /// <summary>
        /// 词性标注并写入文件
        /// </summary>
        /// <param name="sentences"></param>
        public  static void PosSegmentWriteToFile(List<string> sentences, string path)
        {
            JiebaSegmenter jbSeg = new JiebaSegmenter();
            PosSegmenter posSeg = new PosSegmenter(jbSeg);
            StreamWriter writer = File.CreateText(path);
            foreach (var sentence in sentences)
            {
                IEnumerable<Pair> wordList = posSeg.Cut(sentence);
                foreach (var item in wordList)
                {
                    //nr 人名 | nr1 汉语姓氏 | nr2 汉语名字 | nrj 日语人名 | nrf 音译人名
                    if (item.Flag.StartsWith("nr"))//人名
                    {
                        writer.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B-Person");
                        for (int i = 1; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "I-Person");
                        }
                    }
                    else if (item.Flag.Equals("ns"))//地名
                    {
                        writer.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B-Location");
                        for (int i = 1; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "I-Location");
                        }
                    }
                    else if (item.Flag.Equals("nt"))//机构名
                    {
                        writer.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B-Organization");
                        for (int i = 1; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "I-Organization");
                        }
                    }
                    else if (item.Flag.Equals("t"))//时间
                    {
                        writer.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B-Time");
                        for (int i = 1; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "I-Time");
                        }
                    }
                    else if (item.Flag.Equals("v"))//动词
                    {
                        writer.WriteLine(item.Word[0] + "\t" + item.Flag + "\t" + "B-Event");
                        for (int i = 1; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "I-Event");
                        }
                    }
                    else//非实体
                    {
                        for (int i = 0; i < item.Word.Length; i++)
                        {
                            writer.WriteLine(item.Word[i] + "\t" + item.Flag + "\t" + "O");
                        }
                    }
                }
            }
            writer.WriteLine();
            writer.Close();
        }

        /// <summary>
        /// 长句拆分算法
        /// </summary>
        /// <param name="text">文本语句</param>
        /// <param name="maxLen">大于该值才对文本拆分</param>
        /// <returns></returns>
        private static List<string> SplitLongSentence(string text, int maxLen = 70)
        {
            List<string> list = new List<string>();
            if (string.IsNullOrEmpty(text))
            {
                return list;
            }
            else if (text.Length < maxLen)
            {
                list.Add(text.Trim());
            }
            else
            {
                int mIndex = text.IndexOfAny(new char[] { '，', '；', '。' }, text.Length / 2);
                if (mIndex > 0)
                {
                    list.Add(text.Substring(0, mIndex).Trim());
                    list.Add(text.Substring(mIndex + 1).Trim());
                }
                else
                {
                    int lIndex = text.LastIndexOfAny(new char[] { '，', '；', '。' }, text.Length / 2);
                    if (lIndex > 0)
                    {
                        list.Add(text.Substring(0, lIndex).Trim());
                        list.Add(text.Substring(lIndex + 1).Trim());
                    }
                    else
                    {
                        list.Add(text.Trim());
                    }
                }
            }
            return list;
        }
        #endregion
    }
}
