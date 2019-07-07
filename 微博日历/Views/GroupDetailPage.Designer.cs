namespace 微博日历
{
    partial class GroupDetailPage
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
            this.winLayoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelDescription = new DevExpress.XtraEditors.LabelControl();
            this.imageControl = new DevExpress.XtraEditors.PictureEdit();
            this.labelSubtitle = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.winLayoutControl1)).BeginInit();
            this.winLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // winLayoutControl1
            // 
            this.winLayoutControl1.Controls.Add(this.labelDescription);
            this.winLayoutControl1.Controls.Add(this.imageControl);
            this.winLayoutControl1.Controls.Add(this.labelSubtitle);
            this.winLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winLayoutControl1.Location = new System.Drawing.Point(50, 0);
            this.winLayoutControl1.Name = "winLayoutControl1";
            this.winLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(704, 250, 803, 350);
            this.winLayoutControl1.Root = this.layoutControlGroup1;
            this.winLayoutControl1.Size = new System.Drawing.Size(727, 552);
            this.winLayoutControl1.TabIndex = 0;
            this.winLayoutControl1.Text = "winLayoutControl1";
            // 
            // labelDescription
            // 
            this.labelDescription.Appearance.Font = new System.Drawing.Font("Segoe UI Symbol", 14F);
            this.labelDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelDescription.Location = new System.Drawing.Point(12, 365);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(413, 146);
            this.labelDescription.StyleController = this.winLayoutControl1;
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "labelControl2";
            // 
            // imageControl
            // 
            this.imageControl.Location = new System.Drawing.Point(12, 57);
            this.imageControl.Name = "imageControl";
            this.imageControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.imageControl.Size = new System.Drawing.Size(413, 304);
            this.imageControl.StyleController = this.winLayoutControl1;
            this.imageControl.TabIndex = 5;
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Appearance.Font = new System.Drawing.Font("Segoe UI Symbol", 20F);
            this.labelSubtitle.Location = new System.Drawing.Point(12, 12);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(413, 41);
            this.labelSubtitle.StyleController = this.winLayoutControl1;
            this.labelSubtitle.TabIndex = 4;
            this.labelSubtitle.Text = "labelControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlGroup2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(667, 552);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelSubtitle;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(417, 45);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(417, 45);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(417, 45);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.imageControl;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 45);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(417, 308);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(417, 308);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(417, 308);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelDescription;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 353);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(417, 150);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(417, 150);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(417, 150);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Location = new System.Drawing.Point(467, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(180, 532);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 503);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(417, 29);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(417, 0);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(50, 532);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(50, 532);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(50, 532);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // GroupDetailPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.winLayoutControl1);
            this.Name = "GroupDetailPage";
            this.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.Size = new System.Drawing.Size(827, 552);
            ((System.ComponentModel.ISupportInitialize)(this.winLayoutControl1)).EndInit();
            this.winLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl winLayoutControl1;
        private DevExpress.XtraEditors.LabelControl labelDescription;
        private DevExpress.XtraEditors.PictureEdit imageControl;
        private DevExpress.XtraEditors.LabelControl labelSubtitle;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;


    }
}
