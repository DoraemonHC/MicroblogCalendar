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
    public partial class LDATrainPanel : UserControl
    {
        string dir = string.Empty;
        public LDATrainPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.Title = "选择工作目录";
            var res = sfd.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            textBox2.Text = sfd.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var docs = LDA.GetLDATrainDoc(Convert.ToInt32(textBox1.Text));
            var bow = Preprocessor.SegmentRemoveStopWords(docs);
            LDA.WriteLdaDocToFile(bow, textBox2.Text);
            MessageBox.Show("已经生成训练集，接下来可以开始训练LDA了");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dir = Path.GetDirectoryName(Path.GetFullPath(textBox2.Text));
            StringBuilder sb = new StringBuilder();
            sb.Append("-est ");
            if (txtB.Text!="")
            {
                sb.AppendFormat(" -beta {0} ", txtB.Text);
            }
            if (txtK.Text != "")
            {
                sb.AppendFormat(" -ntopics {0} ", txtK.Text);
            }
            if (txtI.Text != "")
            {
                sb.AppendFormat(" -niters {0} ", txtI.Text);
            }
            if (txtA.Text != "")
            {
                sb.AppendFormat(" -alpha {0} ", txtA.Text);
            }
            sb.AppendFormat(" -savestep 300 -twords 15 -dfile {0} ", textBox2.Text);
            ProcessUtils.StartProcess("lda.exe",sb.ToString());
            var data = LDA.ReadTopicWordsWeight(Path.Combine(dir, "model-final.twords"));
            ShowWords(data);
            MessageBox.Show("模型训练完成，接下来请根据高频词填写对应的主题标签，并记得保存");
        }

        private void ShowWords(List<Dictionary<string, double>> data)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                var words = string.Join(" ", data[i].Keys.ToArray());
                dataGridView1.Rows.Add("话题" + i, words,"");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] labels = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                labels[i] = dataGridView1[2,i].Value.ToString();
            }
            LDA.SetTopicLabel(labels, Path.Combine(dir, "ldaTopicLabel.txt"));
            MessageBox.Show("模型保存成功");
        }
    }
}
