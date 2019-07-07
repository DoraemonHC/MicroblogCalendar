namespace 微博日历后台
{
    partial class UpdateDataBasePanel
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "更新命名实体";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(275, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "更新事件类别";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(627, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Tag = "LDA";
            this.button3.Text = "浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(208, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 25);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "data/ldaModel/model-final.others";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "LDA模型路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "CRF模型路径：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(208, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(391, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "data/crfModel";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(627, 63);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Tag = "CRF";
            this.button4.Text = "浏览";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(471, 305);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(179, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "更新事件时间";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(99, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(551, 188);
            this.label3.TabIndex = 6;
            this.label3.Text = "整个过程比较耗时，请耐心等待。\r\n建议使用之前在主界面打开控制台窗口，所有输出均会在控制台显示。\r\n在控制台界面按Ctrl+C结束程序。";
            // 
            // UpdateDataBasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "UpdateDataBasePanel";
            this.Size = new System.Drawing.Size(841, 665);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
    }
}
