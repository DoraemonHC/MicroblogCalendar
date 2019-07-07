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
    public partial class LDATestPanel : UserControl
    {
        public LDATestPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select text from home_timeline order by random() limit 1;";
            string text = (string)SQLiteHelper.ExecuteScalar(sql);
            textBox2.Text = text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Path.GetDirectoryName(Path.GetFullPath(textBox1.Text));
                string testPath = "ldaTestDoc.txt";
                string model = Path.GetFileNameWithoutExtension(textBox1.Text);
                LDA.WriteLdaDocToFile(Preprocessor.SegmentRemoveStopWords(new string[] { textBox2.Text }.ToList(),false),Path.Combine(dir, testPath));
                string args = string.Format("-inf  -dir {0} -model {1} -dfile {2} -niters 20",dir, model, testPath);
                ProcessUtils.StartProcess("lda.exe", args);

                //控制台输出预测结果
                var docTopicArray = LDA.ReadDocumentTopicData(Path.Combine(dir, "ldaTestDoc.txt.theta"));//把预测结果读入内存

                Console.WriteLine("[{0}]读取主题映射...", DateTime.Now);
                var topicLabel = LDA.GetTopicLabel(Path.Combine(dir,"ldaTopicLabel.txt"));//这个话题标签在执行本句代码之前需要人工指定好,根据model-final.twords文件一一对照打上标签

                Console.WriteLine("[{0}]开始预测主题...", DateTime.Now);
                var topicIndex = LDA.GetDocmentTopicIndexList(docTopicArray);//根据预测结果挑选出每篇文档最可能的主题的索引

                label3.Text = topicLabel[topicIndex[0]];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "LDA模型|model-final*";
            ofd.Title = "选择LDA模型";
            var res = ofd.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            textBox1.Text = ofd.FileName;
        }
    }
}
