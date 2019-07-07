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
    public partial class LDAScorePanel : UserControl
    {
        DataTable table;
        string args = string.Empty;
        public LDAScorePanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //路径
                var fullPath = Path.GetFullPath(textBox2.Text);
                var dir = Path.GetDirectoryName(fullPath);
                var trainDoc = FileUtils.RelativePath(Application.StartupPath, fullPath).Replace('\\', '/');
                var finalData = Path.Combine(dir, "evaluate.txt");
                File.Delete(finalData);

                //初始参数
                int cnt = Convert.ToInt32(txtCnt.Text);
                double init = Convert.ToDouble(txtIni.Text);
                double inc = Convert.ToDouble(txtInc.Text);
                //初始化数据表
                InitTable();
                //开始评估
                for (int i = 0; i < cnt; i++)
                {
                    if (rbK.Checked)
                    {
                        args = string.Format("-est -dir -beta {0} -ntopics {1} -niters 1000 -savestep 500 -dfile {2}", 0.1, (int)(init + i * inc), trainDoc);
                    }
                    else
                    {
                        args = string.Format("-est -beta {0} -ntopics {1} -niters 1000 -savestep 500 -dfile {2}", init + i * inc, 12, trainDoc);
                    }
                    ProcessUtils.StartProcess("lda.exe", args);
                    var tt = FileUtils.ReadAsList(Path.Combine(dir, "model-final.theta"));
                    var pp = FileUtils.ReadAsList(Path.Combine(dir, "model-final.phi"));
                    var aa = FileUtils.ReadAsList(Path.Combine(dir, "model-final.tassign"));
                    var d = LDA.GetPerplexity(pp, tt, aa);

                    table.Rows.Add(init + i * inc, d);
                    label6.Text = string.Format("已完成:{0}/{1}", i + 1, cnt);
                }
                //设置图表
                chartControl1.Series[0].DataSource = table;
                chartControl1.Series[0].SetDataMembers("x", "y");
                var xyDiagram = (DevExpress.XtraCharts.XYDiagram)(chartControl1.Diagram);
                xyDiagram.AxisX.Title.Text = rbK.Checked ? "主题个数K" : "超参数β";
                xyDiagram.EnableAxisYScrolling = true;
                xyDiagram.EnableAxisYZooming = true;
                chartControl1.Titles[0].Text = rbK.Checked ? "主题个数K对聚类的影响" : "超参数β对聚类的影响";

                //保存模型评估数据
                var sw = File.AppendText(finalData);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    sw.WriteLine(table.Rows[i]["x"] + "\t" + table.Rows[i]["y"]);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private void InitTable()
        {
            table = new DataTable();
            table.Columns.Add("x");
            table.Columns.Add("y");
            table.Columns["y"].DataType = typeof(double);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var docs = LDA.GetLDATrainDoc(Convert.ToInt32(textBox1.Text));
            var bow = Preprocessor.SegmentRemoveStopWords(docs);
            LDA.WriteLdaDocToFile(bow, textBox2.Text);
            MessageBox.Show("已经生成验证集，接下来可以验证了");
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

        private void rbK_CheckedChanged(object sender, EventArgs e)
        {
            if (rbK.Checked)
            {
                txtIni.Text = 0 + "";
                txtInc.Text = 1 + "";
                txtCnt.Text = 10 + "";
            }
            else
            {
                txtIni.Text = 0.1 + "";
                txtInc.Text = 0.1 + "";
                txtCnt.Text = 10 + "";
            }
        }
    }
}
