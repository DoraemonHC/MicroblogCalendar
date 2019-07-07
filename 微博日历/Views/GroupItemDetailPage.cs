using System;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System.Drawing;
using MicroBlogCalendar.Utility;
using System.Media;

namespace 微博日历
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public partial class GroupItemDetailPage : DevExpress.XtraEditors.XtraUserControl
    {
        public GroupItemDetailPage(DataItem item)
        {
            InitializeComponent();
            labelPerson.Text = item.Person;
            labelLocation.Text = item.Name;
            //把大图换成中图
            imageControl.Image = string.IsNullOrEmpty(item.Original_pic) ? global::微博日历.Properties.Resources.item : Utils.ImageFrom(item.Original_pic.Replace("original_pic", "bmiddle_pic"));
            imageControl.Tag = item.Tid;
            labelEvent.Text = item.Event_phrase;
            labelLocation.Text = item.Location;
            labelTime.Text = item.Time.ToString("yyyy-MM-dd");
            labelName.Text = item.Name;
            labelOrganization.Text = item.Organization;
            labelText.Text = item.Text;
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            var stream = XFSpeaker.Speak(Preprocessor.RemoveInvalidStringForSpeaking(labelText.Text));
            SoundPlayer sp = new SoundPlayer(stream);
            sp.Play();
            System.Windows.Forms.MessageBox.Show(labelText.Text, labelName.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            sp.Stop();
        }

        private void labelText_Click(object sender, EventArgs e)
        {
            var url = Preprocessor.GetUrl(labelText.Text);
            ProcessUtils.OpenUrl(url);
        }
    }
}
