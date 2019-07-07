namespace 微博日历
{
    partial class ItemDetailPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.winLayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.imageControl = new DevExpress.XtraEditors.PictureEdit();
            this.labelContent = new DevExpress.XtraEditors.LabelControl();
            this.labelDescription = new DevExpress.XtraEditors.LabelControl();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.winLayoutControl1)).BeginInit();
            this.winLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // winLayoutControl1
            // 
            this.winLayoutControl1.Controls.Add(this.imageControl);
            this.winLayoutControl1.Controls.Add(this.labelContent);
            this.winLayoutControl1.Controls.Add(this.labelDescription);
            this.winLayoutControl1.Controls.Add(this.labelUser);
            this.winLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winLayoutControl1.Location = new System.Drawing.Point(67, 0);
            this.winLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.winLayoutControl1.Name = "winLayoutControl1";
            this.winLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1093, 194, 450, 350);
            this.winLayoutControl1.Root = this.layoutControlGroup1;
            this.winLayoutControl1.Size = new System.Drawing.Size(939, 558);
            this.winLayoutControl1.TabIndex = 0;
            this.winLayoutControl1.Text = "winLayoutControl1";
            // 
            // imageControl
            // 
            this.imageControl.Location = new System.Drawing.Point(12, 211);
            this.imageControl.Margin = new System.Windows.Forms.Padding(4);
            this.imageControl.Name = "imageControl";
            this.imageControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.imageControl.Size = new System.Drawing.Size(415, 355);
            this.imageControl.StyleController = this.winLayoutControl1;
            this.imageControl.TabIndex = 7;
            // 
            // labelContent
            // 
            this.labelContent.Appearance.Font = new System.Drawing.Font("Segoe UI Symbol", 14F);
            this.labelContent.Appearance.Options.UseFont = true;
            this.labelContent.Appearance.Options.UseTextOptions = true;
            this.labelContent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelContent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelContent.Location = new System.Drawing.Point(498, 12);
            this.labelContent.Margin = new System.Windows.Forms.Padding(4);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(408, 554);
            this.labelContent.StyleController = this.winLayoutControl1;
            this.labelContent.TabIndex = 6;
            this.labelContent.Text = "labelControl3";
            this.labelContent.ToolTip = "左键语音播报，右键打开微博中的链接";
            this.labelContent.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.labelContent.ToolTipTitle = "提示";
            this.labelContent.UseMnemonic = false;
            this.labelContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelContent_MouseClick);
            // 
            // labelDescription
            // 
            this.labelDescription.Appearance.Font = new System.Drawing.Font("Segoe UI Symbol", 14F);
            this.labelDescription.Appearance.Options.UseFont = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 63);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(415, 144);
            this.labelDescription.StyleController = this.winLayoutControl1;
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "labelControl2";
            // 
            // labelUser
            // 
            this.labelUser.Appearance.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.labelUser.Appearance.Options.UseFont = true;
            this.labelUser.Location = new System.Drawing.Point(12, 12);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(415, 47);
            this.labelUser.StyleController = this.winLayoutControl1;
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "labelControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(918, 578);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.labelDescription;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 51);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(419, 148);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(419, 148);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(419, 148);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelUser;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(419, 51);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(419, 51);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(419, 51);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelContent;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(486, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(89, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(412, 558);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.imageControl;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 199);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(419, 359);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(419, 359);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(419, 359);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(419, 0);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(67, 558);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(67, 558);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(67, 558);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ItemDetailPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.winLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemDetailPage";
            this.Padding = new System.Windows.Forms.Padding(67, 0, 67, 0);
            this.Size = new System.Drawing.Size(1073, 558);
            ((System.ComponentModel.ISupportInitialize)(this.winLayoutControl1)).EndInit();
            this.winLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl winLayoutControl1;
        private DevExpress.XtraEditors.PictureEdit imageControl;
        private DevExpress.XtraEditors.LabelControl labelContent;
        private DevExpress.XtraEditors.LabelControl labelDescription;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

    }
}
