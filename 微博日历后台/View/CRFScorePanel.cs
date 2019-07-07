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
    public partial class CRFScorePanel : UserControl
    {
        public CRFScorePanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "带人工标注的测试语料|*.anns";
            ofd.Title = "选择一个或多个带人工标注的测试集";
            ofd.Multiselect = true;
            var res = ofd.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            textBox1.Tag = ofd.FileNames;
            textBox1.Text = string.Join(";",ofd.FileNames);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float p = 0f, r = 0f, f = 0f;
            try
            {
                string dir = Path.GetDirectoryName(Path.GetFullPath(textBox1.Text.Split(';')[0]));
                string testPath = Path.Combine(dir, "crfTestDoc.txt");
                string resultPath = Path.Combine(dir, "crfResultDoc.txt");
                string args = string.Format(" -m {0} {1}", textBox2.Text, testPath);
                //如果是字特征/字+词性特征把这里改成ConvertAnnsToBio1/ConvertAnnsToBio2
                CRF.ConvertAnnsToBio3(testPath, textBox1.Text.Split(';'));
                ProcessUtils.StartProcessRedirect("crf_test.exe", resultPath, args);
                //如果是字特征/字+词性特征把这里改成Score1/Score2
                CRF.Score3(resultPath, ref p, ref r, ref f);
                lblP.Text = p.ToString();
                lblR.Text = r.ToString();
                lblF.Text = f.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Title = "选择CRF模型";
            ofd.Multiselect = false;
            var res = ofd.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            textBox2.Text = ofd.FileName;
        }
    }
}
