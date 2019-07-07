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
    public partial class CRFTrainPanel : UserControl
    {
        public CRFTrainPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            switch (btn.Tag.ToString())
            {
                case "训练语料":
                    ofd.Title = "打开" + btn.Tag.ToString();
                    ofd.Multiselect = true;
                    ofd.Filter = "YEDDA语料|*.anns";
                    var res = ofd.ShowDialog();
                    if (res != DialogResult.OK)
                    {
                        return;
                    }
                    txtTrainDoc.Text = string.Join(";", ofd.FileNames);
                    break;
                case "特征模板":
                    ofd.Title = "打开" + btn.Tag.ToString();
                    var res2 = ofd.ShowDialog();
                    if (res2 != DialogResult.OK)
                    {
                        return;
                    }
                    txtTemplate.Text = ofd.FileName;
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存CRF模型";
            sfd.InitialDirectory = Environment.CurrentDirectory;
            var res = sfd.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            txtModel.Text = sfd.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var dir = Path.GetDirectoryName(txtTrainDoc.Text.Split(';')[0]);
                var bioFile = "data/crfTrainDoc.txt";
                CRF.ConvertAnnsToBio3(bioFile, txtTrainDoc.Text.Split(';'));
                string args = string.Format(@"{0} {1} {2} {3}", txtTemplate.Text, bioFile, txtModel.Text, txtOther.Text);
                //var aString = Encoding.Default.GetString(Encoding.UTF8.GetBytes(args));
                ProcessUtils.StartProcess("crf_learn.exe", args);
                MessageBox.Show("训练完成");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
