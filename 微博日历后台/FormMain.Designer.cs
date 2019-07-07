namespace 微博日历后台
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem8 = new DevExpress.XtraEditors.TileItem();
            this.tileItem9 = new DevExpress.XtraEditors.TileItem();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.tileItem2 = new DevExpress.XtraEditors.TileItem();
            this.tileItem11 = new DevExpress.XtraEditors.TileItem();
            this.tileItem3 = new DevExpress.XtraEditors.TileItem();
            this.tileItem7 = new DevExpress.XtraEditors.TileItem();
            this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem4 = new DevExpress.XtraEditors.TileItem();
            this.tileItem5 = new DevExpress.XtraEditors.TileItem();
            this.tileItem12 = new DevExpress.XtraEditors.TileItem();
            this.tileGroup4 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem6 = new DevExpress.XtraEditors.TileItem();
            this.tileItem13 = new DevExpress.XtraEditors.TileItem();
            this.tileItem14 = new DevExpress.XtraEditors.TileItem();
            this.tileItem10 = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.AllowItemHover = true;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.Groups.Add(this.tileGroup1);
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Groups.Add(this.tileGroup3);
            this.tileControl1.Groups.Add(this.tileGroup4);
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.MaxId = 15;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.ShowGroupText = true;
            this.tileControl1.ShowText = true;
            this.tileControl1.Size = new System.Drawing.Size(1220, 732);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "微博开放域事件抽取系统(后台管理)";
            // 
            // tileGroup1
            // 
            this.tileGroup1.Items.Add(this.tileItem8);
            this.tileGroup1.Items.Add(this.tileItem9);
            this.tileGroup1.Name = "tileGroup1";
            this.tileGroup1.Text = "控制台开关";
            // 
            // tileItem8
            // 
            tileItemElement1.Text = "打开控制台";
            tileItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileItemElement2.Text = "使用其他功能前请先打开控制台";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.tileItem8.Elements.Add(tileItemElement1);
            this.tileItem8.Elements.Add(tileItemElement2);
            this.tileItem8.Id = 10;
            this.tileItem8.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem8.Name = "tileItem8";
            toolTipItem1.Text = "建议先打开控制台界面，方便观察输出结果";
            superToolTip1.Items.Add(toolTipItem1);
            this.tileItem8.SuperTip = superToolTip1;
            this.tileItem8.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem8_ItemClick);
            // 
            // tileItem9
            // 
            tileItemElement3.Text = "关闭控制台";
            this.tileItem9.Elements.Add(tileItemElement3);
            this.tileItem9.Id = 9;
            this.tileItem9.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem9.Name = "tileItem9";
            this.tileItem9.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem8_ItemClick);
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Items.Add(this.tileItem2);
            this.tileGroup2.Items.Add(this.tileItem11);
            this.tileGroup2.Items.Add(this.tileItem3);
            this.tileGroup2.Items.Add(this.tileItem7);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = "数据获取/存储";
            // 
            // tileItem1
            // 
            tileItemElement4.Text = "OAuth2.0授权";
            this.tileItem1.Elements.Add(tileItemElement4);
            this.tileItem1.Id = 1;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem1.Name = "tileItem1";
            this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem1_ItemClick);
            // 
            // tileItem2
            // 
            tileItemElement5.Text = "循环抓取微博";
            this.tileItem2.Elements.Add(tileItemElement5);
            this.tileItem2.Id = 2;
            this.tileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem2.Name = "tileItem2";
            this.tileItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem2_ItemClick);
            // 
            // tileItem11
            // 
            tileItemElement6.Text = "停止循环抓取微博";
            this.tileItem11.Elements.Add(tileItemElement6);
            this.tileItem11.Id = 11;
            this.tileItem11.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem11.Name = "tileItem11";
            this.tileItem11.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem11_ItemClick);
            // 
            // tileItem3
            // 
            tileItemElement7.Text = "抓取一次";
            this.tileItem3.Elements.Add(tileItemElement7);
            this.tileItem3.Id = 3;
            this.tileItem3.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem3.Name = "tileItem3";
            this.tileItem3.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem3_ItemClick);
            // 
            // tileItem7
            // 
            tileItemElement8.Text = "完善数据库，将抽取到的事件存入数据库";
            this.tileItem7.Elements.Add(tileItemElement8);
            this.tileItem7.Id = 7;
            this.tileItem7.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem7.Name = "tileItem7";
            this.tileItem7.Tag = "DB";
            this.tileItem7.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileGroup3
            // 
            this.tileGroup3.Items.Add(this.tileItem4);
            this.tileGroup3.Items.Add(this.tileItem5);
            this.tileGroup3.Items.Add(this.tileItem12);
            this.tileGroup3.Name = "tileGroup3";
            this.tileGroup3.Text = "CRF";
            // 
            // tileItem4
            // 
            tileItemElement9.Text = "训练模型";
            this.tileItem4.Elements.Add(tileItemElement9);
            this.tileItem4.Id = 4;
            this.tileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem4.Name = "tileItem4";
            this.tileItem4.Tag = "CRFTrain";
            this.tileItem4.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItem5
            // 
            tileItemElement10.Text = "测试模型";
            this.tileItem5.Elements.Add(tileItemElement10);
            this.tileItem5.Id = 5;
            this.tileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem5.Name = "tileItem5";
            this.tileItem5.Tag = "CRFTest";
            this.tileItem5.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItem12
            // 
            tileItemElement11.Text = "评估模型";
            this.tileItem12.Elements.Add(tileItemElement11);
            this.tileItem12.Id = 12;
            this.tileItem12.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem12.Name = "tileItem12";
            this.tileItem12.Tag = "CRFScore";
            this.tileItem12.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileGroup4
            // 
            this.tileGroup4.Items.Add(this.tileItem6);
            this.tileGroup4.Items.Add(this.tileItem13);
            this.tileGroup4.Items.Add(this.tileItem14);
            this.tileGroup4.Name = "tileGroup4";
            this.tileGroup4.Text = "LDA";
            // 
            // tileItem6
            // 
            tileItemElement12.Text = "评估模型";
            this.tileItem6.Elements.Add(tileItemElement12);
            this.tileItem6.Id = 6;
            this.tileItem6.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem6.Name = "tileItem6";
            this.tileItem6.Tag = "LDAScore";
            this.tileItem6.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItem13
            // 
            tileItemElement13.Text = "训练模型";
            this.tileItem13.Elements.Add(tileItemElement13);
            this.tileItem13.Id = 13;
            this.tileItem13.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem13.Name = "tileItem13";
            this.tileItem13.Tag = "LDATrain";
            this.tileItem13.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItem14
            // 
            tileItemElement14.Text = "测试模型";
            this.tileItem14.Elements.Add(tileItemElement14);
            this.tileItem14.Id = 14;
            this.tileItem14.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem14.Name = "tileItem14";
            this.tileItem14.Tag = "LDATest";
            this.tileItem14.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem_ItemClick);
            // 
            // tileItem10
            // 
            tileItemElement15.Text = "循环抓取微博";
            this.tileItem10.Elements.Add(tileItemElement15);
            this.tileItem10.Id = 2;
            this.tileItem10.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem10.Name = "tileItem10";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 732);
            this.Controls.Add(this.tileControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "微博日历";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private DevExpress.XtraEditors.TileItem tileItem2;
        private DevExpress.XtraEditors.TileItem tileItem3;
        private DevExpress.XtraEditors.TileGroup tileGroup3;
        private DevExpress.XtraEditors.TileGroup tileGroup4;
        private DevExpress.XtraEditors.TileItem tileItem4;
        private DevExpress.XtraEditors.TileItem tileItem5;
        private DevExpress.XtraEditors.TileItem tileItem6;
        private DevExpress.XtraEditors.TileItem tileItem7;
        private DevExpress.XtraEditors.TileItem tileItem8;
        private DevExpress.XtraEditors.TileItem tileItem9;
        private DevExpress.XtraEditors.TileItem tileItem11;
        private DevExpress.XtraEditors.TileItem tileItem10;
        private DevExpress.XtraEditors.TileItem tileItem12;
        private DevExpress.XtraEditors.TileItem tileItem13;
        private DevExpress.XtraEditors.TileItem tileItem14;
    }
}

