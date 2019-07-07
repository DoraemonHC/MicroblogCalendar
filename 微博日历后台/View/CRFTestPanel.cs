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
    public partial class CRFTestPanel : UserControl
    {
        public CRFTestPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Title = "选择CRF模型";
            var res = ofd.ShowDialog();
            if (res!=DialogResult.OK)
            {
                return;
            }
            textBox1.Text = ofd.FileName;
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
                string testPath = Path.Combine(dir, "crfTestDoc.txt");
                string resultPath = Path.Combine(dir, "crfResultDoc.txt");
                CRF.WriteSentenceToFile3(Preprocessor.RemoveInvalidString(textBox2.Text), testPath);
                string args = string.Format(" -m {0} {1}", textBox1.Text, testPath);
                ProcessUtils.StartProcessRedirect("crf_test.exe", resultPath, args);
                var list = CRF.GetNameEntityFromFile(resultPath);
                var dict = CRF.MergeNameEntity(list);

                //在这里必须创建一个BindIngSource对象，用该对象接收Dictionary<>泛型集合的对象  
                BindingSource bs = new BindingSource();
                //将泛型集合对象的值赋给BindingSourc对象的数据源  
                bs.DataSource = dict;
                this.dataGridView1.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
    }
}
