using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Drawing;

namespace 微博日历
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public partial class GroupDetailPage : XtraUserControl
    {
        public GroupDetailPage(DataGroup dataGroup)
        {
            InitializeComponent();

            imageControl.Image = Utils.GetRandomImg(); // DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(dataGroup.ImagePath, typeof(MainForm).Assembly);
            labelSubtitle.Text = dataGroup.Name;
            labelDescription.Text = dataGroup.Description;
            CreateLayout(dataGroup);
        }

        public GroupDetailPage(string topic,string description)
        {
            InitializeComponent();

            imageControl.Image = Utils.GetRandomImg();// DevExpress.Utils.ResourceImageHelper.CreateImageFromResources(dataGroup.ImagePath, typeof(MainForm).Assembly);
            labelSubtitle.Text = topic;
            labelDescription.Text = description;

            var ds = new DataSource(topic, 40);
            CreateLayout(ds.Data.Groups[0]);
        }

        void CreateLayout(DataGroup dataGroup)
        {
            for (int i = 0; i < dataGroup.Items.Count; i++)
                CreateLayoutCore(dataGroup.Items[i], i);
        }
        void CreateLayoutCore(DataItem item, int index)
        {
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            DevExpress.XtraLayout.LayoutControlItem layoutTileItem = new DevExpress.XtraLayout.LayoutControlItem();
            GroupItemDetailPage page = new GroupItemDetailPage(item);
            page.Tag = this.Tag;
            layoutTileItem.Control = page;
            layoutTileItem.Location = new System.Drawing.Point(0, 0);
            layoutTileItem.MinSize = new System.Drawing.Size(winLayoutControl1.Width, page.Height);
            layoutTileItem.MaxSize = new System.Drawing.Size(0, page.Height);
            layoutTileItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutTileItem.TextSize = new System.Drawing.Size(0, 0);
            layoutTileItem.TextToControlDistance = 0;
            layoutTileItem.TextVisible = false;
            layoutControlGroup2.Add(layoutTileItem);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
        }
    }
}
