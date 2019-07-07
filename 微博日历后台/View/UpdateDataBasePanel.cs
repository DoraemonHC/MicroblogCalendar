using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroBlogCalendar.Utility;
using System.IO;

namespace 微博日历后台
{
    public partial class UpdateDataBasePanel : UserControl
    {
        public UpdateDataBasePanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CRF.TestAll(textBox2.Text);
                MessageBox.Show("任务已完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "CRF":
                    ofd.Title = "打开CRF模型";
                    var dr = ofd.ShowDialog();
                    if (dr!=DialogResult.OK)
                    {
                        return;
                    }
                    textBox2.Text = ofd.FileName;
                    break;
                case "LDA":
                    ofd.Title = "打开LDA模型";
                    ofd.Filter = "LDA模型|model-final*";
                    var dr2 = ofd.ShowDialog();
                    if (dr2 != DialogResult.OK)
                    {
                        return;
                    }
                    textBox1.Text = ofd.FileName;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var fullPath = Path.GetFullPath(textBox1.Text);
                var dir = Path.GetDirectoryName(fullPath);
                var inferDocFile = "ldaInferDoc.txt";
                var thetaFile = inferDocFile + ".theta";
                var topicLabelFile = "ldaTopicLabel.txt";
                var inferDocAbsPath = Path.Combine(dir, inferDocFile);
                var thetaAbsPath = Path.Combine(dir, thetaFile);
                var topicLabelAbsPath = Path.Combine(dir, topicLabelFile);

                Console.WriteLine("[{0}]开始预测主题...", DateTime.Now);

                List<string> tidList = null;
                Console.WriteLine("[{0}]获取微博...", DateTime.Now);
                var inferOriginalDocs = LDA.GetLDAInferDoc(out tidList);

                Console.WriteLine("[{0}]预处理...", DateTime.Now);
                var inferDocs = Preprocessor.SegmentRemoveStopWords(inferOriginalDocs, false);

                Console.WriteLine("[{0}]写入文件...", DateTime.Now);
                LDA.WriteLdaDocToFile(inferDocs, inferDocAbsPath);

                Console.WriteLine("[{0}]吉布斯采样...", DateTime.Now);
                string args = string.Format("-inf  -dir {0} -model {1} -dfile {2} -niters 20", dir, "model-final", inferDocFile);
                ProcessUtils.StartProcess("lda.exe", args);

                //控制台输出预测结果
                Console.WriteLine("[{0}]读取预测结果...", DateTime.Now);
                var docTopicArray = LDA.ReadDocumentTopicData(thetaAbsPath);//把预测结果读入内存

                Console.WriteLine("[{0}]读取主题映射...", DateTime.Now);
                var topicLabel = LDA.GetTopicLabel(topicLabelAbsPath);//这个话题标签在执行本句代码之前需要人工指定好,根据model-final.twords文件一一对照打上标签

                Console.WriteLine("[{0}]开始预测主题...", DateTime.Now);
                var topicIndex = LDA.GetDocmentTopicIndexList(docTopicArray);//根据预测结果挑选出每篇文档最可能的主题的索引

                Console.WriteLine("[{0}]以下是微博的主题预测情况：", DateTime.Now);
                LDA.PrintTopics(inferOriginalDocs, topicIndex, topicLabel);

                //保存数据库
                Console.WriteLine("[{0}]开始存储主题...", DateTime.Now);
                LDA.SaveTopicToDB(topicIndex, topicLabel, tidList);
                MessageBox.Show("任务已完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("[{0}]开始处理时间...", DateTime.Now);
            var i = DBUtils.SetEventDate();
            MessageBox.Show("本次共处理" + i + "条微博", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
