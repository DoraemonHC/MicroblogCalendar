namespace 微博日历
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.tileContainer = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.windowsUIView;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView});
            // 
            // windowsUIView
            // 
            this.windowsUIView.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI Light", 36F);
            this.windowsUIView.AppearanceCaption.Options.UseFont = true;
            this.windowsUIView.Caption = "微博日历";
            this.windowsUIView.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.tileContainer});
            this.windowsUIView.LoadingIndicatorProperties.Caption = "";
            this.windowsUIView.LoadingIndicatorProperties.Description = "";
            this.windowsUIView.SplashScreenProperties.AppearanceCaption.Font = new System.Drawing.Font("方正萌艺体 简", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windowsUIView.SplashScreenProperties.AppearanceCaption.Options.UseFont = true;
            this.windowsUIView.SplashScreenProperties.Caption = "随时随地发现新鲜事";
            this.windowsUIView.SplashScreenProperties.CaptionToLoadingElementsDistance = 250;
            this.windowsUIView.SplashScreenProperties.Image = global::微博日历.Properties.Resources.splash;
            this.windowsUIView.SplashScreenProperties.LoadingDescription = "正在加载中，请稍等...";
            // 
            // tileContainer
            // 
            this.tileContainer.AppearanceSubtitle.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.tileContainer.AppearanceSubtitle.Options.UseFont = true;
            this.tileContainer.Caption = "微博日历";
            this.tileContainer.Name = "tileContainer1";
            this.tileContainer.Properties.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.tileContainer.Properties.ShowGroupText = DevExpress.Utils.DefaultBoolean.True;
            this.tileContainer.Subtitle = "Sina Weibo Calendar";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 586);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer;

    }

}

