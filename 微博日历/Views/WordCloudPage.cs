using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCloudSharp;

namespace 微博日历
{
    public partial class WordCloudPage : UserControl
    {
        List<int> freqs = new List<int>(50);
        List<string> words = new List<string>(50);
        public WordCloudPage(List<string> list)
        {
            InitializeComponent();
            pictureEdit1.Dock = DockStyle.None;
            this.Dock = DockStyle.Fill;

            for (int i = 0; i < list.Count; i++)
            {
                freqs.Add(1);
                words.Add(list[i].Replace("#", ""));
            }
        }

        private async void WordCloudPage_Load(object sender, EventArgs e)
        {
            pictureEdit1.Location = new Point((this.Width - pictureEdit1.Width) / 2, (this.Height - pictureEdit1.Height) / 2);

            var img = await Task.Run<Image>(new Func<Image>(() =>
            {
                WordCloud wc = new WordCloud(this.Width, this.Height);
                return wc.Draw(words, freqs);
            }));
            pictureEdit1.Dock = DockStyle.Fill;
            pictureEdit1.Image = img;
        }
    }
}
