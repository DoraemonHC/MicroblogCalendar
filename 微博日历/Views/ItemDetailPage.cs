using DevExpress.XtraEditors;
using MicroBlogCalendar.Utility;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Media;

namespace 微博日历
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public partial class ItemDetailPage : XtraUserControl
    {
        public ItemDetailPage(DataItem item)
        {
            InitializeComponent();

            string sql = "select name,description from user where uid = (select uid from home_timeline where tid = @tid)";

            SQLiteParameter pms = new SQLiteParameter("tid", item.Tid);
            var reader = SQLiteHelper.ExecuteReader(sql, pms);
            while (reader.Read())
            {
                labelUser.Text = reader.GetString(0);
                labelDescription.Text = reader.GetString(1);
            }
            imageControl.Image = string.IsNullOrEmpty(item.Original_pic) ? Utils.GetRandomImg() : Utils.ImageFrom(item.Original_pic);
            labelContent.Text = item.Text;
            labelContent.ImageOptions.Image = global::微博日历.Properties.Resources.喇叭;
            labelContent.ImageAlignToText = ImageAlignToText.LeftCenter;
        }
        private void labelContent_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //微软发音人
                MSSpeaker.Speak(Preprocessor.RemoveInvalidStringForSpeaking(labelContent.Text));
                /*
                 //讯飞发音人
                var stream = XFSpeaker.Speak(Preprocessor.RemoveInvalidStringForSpeaking(labelContent.Text));
                SoundPlayer sp = new SoundPlayer(stream);
                sp.Play();*/
                //System.Windows.Forms.MessageBox.Show(labelText.Text, labelName.Text, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                //sp.Stop();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var url = Preprocessor.GetUrl(labelContent.Text);
                ProcessUtils.OpenUrl(url);
            }
        }
    }
}
