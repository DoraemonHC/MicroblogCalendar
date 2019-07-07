namespace 微博日历后台
{
    partial class CRFScorePanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "使用YEDDA导出的带人工标注的测试集：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(304, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "data/train200.txt.anns";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(662, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "精确度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "召回率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "F值：";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(265, 159);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(23, 15);
            this.lblP.TabIndex = 4;
            this.lblP.Text = "0%";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(265, 253);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(23, 15);
            this.lblR.TabIndex = 5;
            this.lblR.Text = "0%";
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Location = new System.Drawing.Point(265, 357);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(23, 15);
            this.lblF.TabIndex = 5;
            this.lblF.Text = "0%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "训练模型：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(501, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "data/crfModel";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(662, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CRFScorePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "CRFScorePanel";
            this.Size = new System.Drawing.Size(779, 431);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
    }
}
