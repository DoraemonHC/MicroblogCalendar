namespace 微博日历后台
{
    partial class LDAScorePanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCnt = new System.Windows.Forms.TextBox();
            this.txtInc = new System.Windows.Forms.TextBox();
            this.txtIni = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbK = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "验证集规模：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "300";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成验证集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(891, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "开始评估LDA模型";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.Text = "困惑度";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(0, 122);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1087, 659);
            this.chartControl1.TabIndex = 4;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCnt);
            this.groupBox1.Controls.Add(this.txtInc);
            this.groupBox1.Controls.Add(this.txtIni);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbB);
            this.groupBox1.Controls.Add(this.rbK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1087, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // txtCnt
            // 
            this.txtCnt.Location = new System.Drawing.Point(729, 79);
            this.txtCnt.Name = "txtCnt";
            this.txtCnt.Size = new System.Drawing.Size(113, 25);
            this.txtCnt.TabIndex = 8;
            this.txtCnt.Text = "10";
            // 
            // txtInc
            // 
            this.txtInc.Location = new System.Drawing.Point(729, 49);
            this.txtInc.Name = "txtInc";
            this.txtInc.Size = new System.Drawing.Size(113, 25);
            this.txtInc.TabIndex = 8;
            this.txtInc.Text = "1";
            // 
            // txtIni
            // 
            this.txtIni.Location = new System.Drawing.Point(729, 18);
            this.txtIni.Name = "txtIni";
            this.txtIni.Size = new System.Drawing.Size(113, 25);
            this.txtIni.TabIndex = 8;
            this.txtIni.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "次数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "步进：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(888, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "已完成：0/0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "初始值：";
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(541, 84);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(88, 19);
            this.rbB.TabIndex = 5;
            this.rbB.Text = "超参数β";
            this.rbB.UseVisualStyleBackColor = true;
            this.rbB.CheckedChanged += new System.EventHandler(this.rbK_CheckedChanged);
            // 
            // rbK
            // 
            this.rbK.AutoSize = true;
            this.rbK.Checked = true;
            this.rbK.Location = new System.Drawing.Point(541, 45);
            this.rbK.Name = "rbK";
            this.rbK.Size = new System.Drawing.Size(96, 19);
            this.rbK.TabIndex = 4;
            this.rbK.TabStop = true;
            this.rbK.Text = "主题个数K";
            this.rbK.UseVisualStyleBackColor = true;
            this.rbK.CheckedChanged += new System.EventHandler(this.rbK_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "验证集保存路径：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(149, 39);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(228, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "data/ldaTest/ldaTrainDoc.txt";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(383, 39);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // LDAScorePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "LDAScorePanel";
            this.Size = new System.Drawing.Size(1087, 781);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtInc;
        private System.Windows.Forms.TextBox txtIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
