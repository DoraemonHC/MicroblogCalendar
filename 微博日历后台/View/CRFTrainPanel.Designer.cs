namespace 微博日历后台
{
    partial class CRFTrainPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrainDoc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Controls.Add(this.txtOther, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTemplate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTrainDoc, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 226);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtOther
            // 
            this.txtOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtOther.Location = new System.Drawing.Point(139, 96);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(336, 25);
            this.txtOther.TabIndex = 10;
            this.txtOther.Text = "-e 0.000001 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "其他参数：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModel.Location = new System.Drawing.Point(139, 65);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(336, 25);
            this.txtModel.TabIndex = 7;
            this.txtModel.Text = "data/crfModel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "模型输出路径：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTemplate
            // 
            this.txtTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTemplate.Location = new System.Drawing.Point(139, 34);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(336, 25);
            this.txtTemplate.TabIndex = 5;
            this.txtTemplate.Text = "data/crfTemplate3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "特征模板：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "训练语料：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTrainDoc
            // 
            this.txtTrainDoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTrainDoc.Location = new System.Drawing.Point(139, 3);
            this.txtTrainDoc.Name = "txtTrainDoc";
            this.txtTrainDoc.Size = new System.Drawing.Size(336, 25);
            this.txtTrainDoc.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Tag = "训练语料";
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Tag = "特征模板";
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Tag = "model";
            this.button3.Text = "浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(481, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Tag = "start";
            this.button4.Text = "开始训练";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CRFTrainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CRFTrainPanel";
            this.Size = new System.Drawing.Size(616, 226);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrainDoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
    }
}
