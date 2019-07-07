using MicroBlogCalendar.Utility;
using NetDimension.OpenAuth.Winform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 微博日历后台
{
    public partial class FormMain : Form
    {
        string appKey, appSecret, accessToken;
        public FormMain()
        {
            InitializeComponent();
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //获取Configuration对象
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appKey = config.AppSettings.Settings["appKey"].Value;
            var appSecret = config.AppSettings.Settings["appSecret"].Value;
            var callbackUrl = config.AppSettings.Settings["callbackUrl"].Value;

            //请自行修改appKey，appSecret和回调地址。winform的回调地址可以是一个随便可以访问的地址，貌似不可以访问的地址也是可以的，只要URL中带着Code就行
            var client = new NetDimension.OpenAuth.Sina.SinaWeiboClient(appKey, appSecret, callbackUrl);

            //NetDimension.OpenAuth.Winform封装的一个登录窗口，主要原理就是个WebBrowser控件，然后在该控件的导航事件里面监测Url是不是带有Code，如果有就调用GetAccessTokenByCode
            var authForm = client.GetAuthenticationForm();

            authForm.StartPosition = FormStartPosition.CenterScreen;

            if (authForm.ShowDialog() == DialogResult.OK)
            {
                config.AppSettings.Settings["accessToken"].Value = client.AccessToken;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Clipboard.SetText(client.AccessToken);
                MessageBox.Show("您的AccessToken：" + client.AccessToken + ",已复制到剪切板", "授权成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        Thread t;
        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            appKey = ConfigurationManager.AppSettings["appKey"];
            appSecret = ConfigurationManager.AppSettings["appSecret"];
            accessToken = ConfigurationManager.AppSettings["accessToken"];
            t = Spider.GetHomeTimelineRepeat(appKey,appSecret,accessToken);
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            appKey = ConfigurationManager.AppSettings["appKey"];
            appSecret = ConfigurationManager.AppSettings["appSecret"];
            accessToken = ConfigurationManager.AppSettings["accessToken"];
            Task.Run(() => { Spider.GetHomeTimeline(appKey, appSecret, accessToken); });
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (e.Item.Text=="打开控制台")
            {
                Shell.OpenConsole();
            }
            else
            {
                Shell.CloseConsole();
            }
        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (t != null)
            {
                t.Abort();
            }
        }

        private void tileItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Form f = new Form();
            Control control = null;
            switch (e.Item.Tag.ToString())
            {
                case "DB":
                    control = new UpdateDataBasePanel();
                    break;
                case "CRFTrain":
                    control = new CRFTrainPanel();
                    break;
                case "CRFTest":
                    control = new CRFTestPanel();
                    break;
                case "CRFScore":
                    control = new CRFScorePanel();
                    break;
                case "LDATest":
                    control = new LDATestPanel();
                    break;
                case "LDATrain":
                    control = new LDATrainPanel();
                    break;
                case "LDAScore":
                    control = new LDAScorePanel();
                    break;
                default:
                    break;
            }
            f.Size = control.Size;
            f.Controls.Add(control);
            f.Show();
        }
    }
}
