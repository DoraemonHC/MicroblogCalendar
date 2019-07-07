using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Views;
using System.Drawing;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010;
using MicroBlogCalendar.Utility;

namespace 微博日历
{
    public partial class MainForm : XtraForm
    {
        DataSource dataSource;
        Dictionary<string, string> desc = new Dictionary<string, string>()
        {
            {"娱乐","娱乐新闻是根据现代人的某种需要而生产出来供一部分人消费的信息产品。而娱乐新闻大行其道与中国的各种文化，社会因素存在千丝万缕的联系。而新闻的娱乐化在内容上偏重于微小新闻， 减少严肃新闻的比例，从严肃的政治、经济变动中挖掘其娱乐价值。 " },
            {"国际","国际新闻是指国际间发生的具有影响力的事件或消息动态。国际新闻从当代意义来讲，是指跨越了国家界限并具有跨文化性质的新闻，或者说，新闻及新闻要素在国际间的传播和流动。" },
            {"社会","社会新闻是涉及人民群众日常生活的社会事件、社会问题、社会风貌的报道,包括社会问题、社会事件和社会生活方面的内容,尤以社会道德伦理为基础反映社会风尚的新闻为主。" },
            {"体育","体育新闻（外文名：Sports news）对体育运动中新近发生的事实的报道。包括运动竞赛、运动训练、学校体育、群众体育领域中的各种新发生的事实。其中运动竞赛中的新闻占据主要地位。" },
            {"政务","政府新闻发布制度是指国家机构任命或指定的专职或兼职新闻发布人员，在一定时间内就某一重大事件或时局的问题，举行新闻发布会，或约见个别记者，发布有关新闻或阐述本部门的观点立场，并代表有关部门回答记者的提问一项社会活动。" },
            {"影视","从新闻角度看电影，从电影角度发现新闻。《中国电影报道》是电影频道旗舰栏目，新鲜的影视资讯、快速的热点直击、丰富的背景展现、深度的现象分析，是节目的基本风貌。" },
            {"健康","着眼于大众健康生活、突出公众立场，以新闻事件对公众健康生活观念的影响深度、广泛性为评选准则，旨在引领公众的健康生活观念或行为、警示行业不和谐因素。" },
            {"教育","第一时间为您传递教育资讯，报道教育动态，追踪教育热点；了解最新的招考信息、感受最新的教育理念、解决孩子教育中遇到的难题！" },
            {"财经","覆盖全部社会经济生活和与经济有关的领域，包括从生产到消费、从城市到农村、从宏观到微观、从安全生产到服务质量，从经济工作到政治、社会生活中的相关领域。" },
        };
        public MainForm()
        {
            InitializeComponent();
            try
            {
                windowsUIView.AddTileWhenCreatingDocument = DevExpress.Utils.DefaultBoolean.False;
                windowsUIView.BackgroundImage = Image.FromFile(@"Resource/background.jpg");
                windowsUIView.ActivateContainer(tileContainer);
                windowsUIView.UseLoadingIndicator = DevExpress.Utils.DefaultBoolean.True;
            }
            catch{ }


            try
            {
               CreateHotSearch();
            }
            catch { }
            try
            {
               CreateHotTopic();
            }
            catch { }
            try
            {
                var weatherJson = NetUtils.GetWeather();
                CreateWeatherTile(weatherJson);
            }
            catch (Exception ex)
            {
                CreateWeatherTile(ex.Message);
            }
            try
            {
              CreateLayout();
            }
            catch { }

        }

        /// <summary>
        /// 创建实时话题榜Tile控件
        /// </summary>
        private async void CreateHotTopic()
        {
            var tile = new Tile();
            tile.Group = "热门推荐";
            tile.Click += HotTopicClick;
            tileContainer.Items.Add(tile);

            await Task.Run(() =>
            {
                var hotTopic = Spider.GetTopicList();
                tile.Tag = hotTopic;
                for (int i = 0; i < hotTopic.Count && i < 15; i++)
                {
                    TileItemFrame tileFrame = new TileItemFrame();
                    tileFrame.Interval = 5000;

                    TileItemElement elemTitle = new TileItemElement();
                    elemTitle.Text = hotTopic[i];
                    elemTitle.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 15.0f, System.Drawing.GraphicsUnit.Point);
                    elemTitle.TextAlignment = TileItemContentAlignment.MiddleCenter;
                    tileFrame.Elements.Add(elemTitle);

                    TileItemElement elemType = new TileItemElement();
                    elemType.Text = "微博实时话题榜";
                    //elemType.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);
                    elemType.TextAlignment = TileItemContentAlignment.BottomLeft;
                    tileFrame.Elements.Add(elemType);

                    TileItemElement elemIndex = new TileItemElement();
                    elemIndex.Text = string.Format("No.{0}", i + 1);
                    elemIndex.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 13.0f, System.Drawing.GraphicsUnit.Point);
                    elemIndex.TextAlignment = TileItemContentAlignment.TopLeft;
                    tileFrame.Elements.Add(elemIndex);

                    tile.Frames.Add(tileFrame);
                }
            });
        }

        /// <summary>
        /// 创建实时热搜榜tile控件
        /// </summary>
        private async void CreateHotSearch()
        {
            var tile = new Tile();
            tile.Properties.ItemSize = TileItemSize.Large;
            tile.Group = "热门推荐";
            tile.Click += HotSearchClick;
            tileContainer.Items.Add(tile);

            await Task.Run(() =>
            {
                var dt = Spider.GetHotTable();
                tile.Tag = dt;//利用tag字段保存数据表
                for (int i = 0; i < dt.Rows.Count && i < 10; i++)
                {
                    TileItemFrame tileFrame = new TileItemFrame();
                    tileFrame.Interval = 3000;

                    TileItemElement elemTitle = new TileItemElement();
                    elemTitle.Text = dt.Rows[i][0].ToString();
                    elemTitle.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 15.0f, System.Drawing.GraphicsUnit.Point);
                    elemTitle.TextAlignment = TileItemContentAlignment.MiddleCenter;
                    tileFrame.Elements.Add(elemTitle);

                    TileItemElement elemCount = new TileItemElement();
                    elemCount.Text = string.Format("热度:{0}", dt.Rows[i][1]);
                    //elemTitle.Appearance.Normal.Font=new 
                    elemCount.TextAlignment = TileItemContentAlignment.BottomRight;
                    tileFrame.Elements.Add(elemCount);

                    TileItemElement elemType = new TileItemElement();
                    elemType.Text = "微博实时热搜榜";
                    //elemType.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);
                    elemType.TextAlignment = TileItemContentAlignment.BottomLeft;
                    tileFrame.Elements.Add(elemType);

                    TileItemElement elemIndex = new TileItemElement();
                    elemIndex.Text = string.Format("No.{0}", i + 1);
                    elemIndex.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 13.0f, System.Drawing.GraphicsUnit.Point);
                    elemIndex.TextAlignment = TileItemContentAlignment.TopLeft;
                    tileFrame.Elements.Add(elemIndex);

                    tile.Frames.Add(tileFrame);
                }
            });
        }

        #region MyRegion

        /// <summary>
        /// 创建天气Tile控件
        /// </summary>
        /// <param name="str"></param>
        private void CreateWeatherTile(string str)
        {
            var t = new Tile();
            //t.Click += new TileClickEventHandler(moreTile_Click);
            t.Group = "热门推荐";

            tileContainer.Items.Add(t);

            try
            {
                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(str);

                //frame #1 
                TileItemFrame frameOne = new TileItemFrame();
                frameOne.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);

                TileItemElement elemHigh = new TileItemElement();
                var low = obj.data.forecast[0].low.ToString();
                var high = obj.data.forecast[0].high.ToString();
                low = System.Text.RegularExpressions.Regex.Replace(low, @"[^\d|\.]", string.Empty);
                high = System.Text.RegularExpressions.Regex.Replace(high, @"[^\d|\.]", string.Empty);
                elemHigh.Text = string.Format("{0}℃ ~ {1}℃", low, high);
                elemHigh.TextAlignment = TileItemContentAlignment.TopLeft;
                frameOne.Elements.Add(elemHigh);

                TileItemElement elemtype = new TileItemElement();
                elemtype.Text = obj.data.forecast[0].type;
                elemtype.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18.0f, System.Drawing.GraphicsUnit.Point);
                elemtype.TextAlignment = TileItemContentAlignment.MiddleCenter;
                frameOne.Elements.Add(elemtype);

                TileItemElement elemCity = new TileItemElement();
                elemCity.Text = obj.cityInfo.city;
                elemCity.TextAlignment = TileItemContentAlignment.BottomLeft;
                frameOne.Elements.Add(elemCity);

                TileItemElement elemFx = new TileItemElement();
                elemFx.Text = string.Format("{0} {1}", obj.data.forecast[0].fx, obj.data.forecast[0].fl);
                elemFx.TextAlignment = TileItemContentAlignment.TopRight;
                frameOne.Elements.Add(elemFx);

                TileItemElement elemNotice = new TileItemElement();
                elemNotice.Text = obj.data.forecast[0].notice;
                elemNotice.TextAlignment = TileItemContentAlignment.BottomRight;
                frameOne.Elements.Add(elemNotice);

                TileItemElement elemYmd = new TileItemElement();
                elemFx.Text = string.Format("{0} {1}", Convert.ToDateTime(obj.data.forecast[0].ymd).ToString("M月d日"), obj.data.forecast[0].week);
                elemFx.TextAlignment = TileItemContentAlignment.TopRight;
                frameOne.Elements.Add(elemFx);
                // aaa.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18.0f, System.Drawing.GraphicsUnit.Point);

                frameOne.Interval = 5000;
                frameOne.Animation = TileItemContentAnimationType.ScrollDown;

                //frame #2 
                TileItemFrame frameTwo = new TileItemFrame();
                frameTwo.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);

                TileItemElement elemShidu = new TileItemElement();
                elemShidu.Text = string.Format("最近更新 : {0}", obj.cityInfo.updateTime);
                elemShidu.TextAlignment = TileItemContentAlignment.MiddleRight;
                frameTwo.Elements.Add(elemShidu);

                TileItemElement elemPM25 = new TileItemElement();
                elemPM25.Text = string.Format("PM2.5: {0}", obj.data.pm25);
                elemPM25.TextAlignment = TileItemContentAlignment.TopLeft;
                frameTwo.Elements.Add(elemPM25);

                TileItemElement elemQuality = new TileItemElement();
                elemQuality.Text = string.Format("空气质量: {0}", obj.data.quality);
                elemQuality.TextAlignment = TileItemContentAlignment.TopRight;
                frameTwo.Elements.Add(elemQuality);

                TileItemElement elemWendu = new TileItemElement();
                elemWendu.Text = string.Format("温度: {0}℃", obj.data.wendu);
                elemWendu.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18.0f, System.Drawing.GraphicsUnit.Point);
                elemWendu.TextAlignment = TileItemContentAlignment.MiddleLeft;
                frameTwo.Elements.Add(elemWendu);

                TileItemElement elemGanmao = new TileItemElement();
                elemGanmao.Text = obj.data.ganmao;
                elemGanmao.TextAlignment = TileItemContentAlignment.BottomLeft;
                frameTwo.Elements.Add(elemGanmao);

                frameTwo.Interval = 4000;
                frameTwo.Animation = TileItemContentAnimationType.Default;

                t.Frames.Add(frameOne);
                t.Frames.Add(frameTwo);
            }
            catch (Exception)
            {
                TileItemFrame tileFrameTmp = new TileItemFrame();
                tileFrameTmp.Elements.Add(new TileItemElement() { Text = "天气获取失败", TextAlignment = TileItemContentAlignment.MiddleCenter });
                tileFrameTmp.Appearance.Font = new Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);
                t.Frames.Add(tileFrameTmp);
                //throw;
            }


        }


        #endregion

        /// <summary>
        /// 创建天气Tile控件（该接口不准确，停用）
        /// </summary>
        /// <param name="str"></param>
        private void CreateWeatherTile2(string str)
        {
            var t = new Tile();
            //t.Click += new TileClickEventHandler(moreTile_Click);
            t.Group = "热门推荐";

            tileContainer.Items.Add(t);

            try
            {
                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(str);

                //frame #1 
                TileItemFrame frameOne = new TileItemFrame();
                frameOne.Appearance.Font = new System.Drawing.Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);

                TileItemElement elemHigh = new TileItemElement();
                var low = obj.weatherinfo.temp1.ToString();
                var high = obj.weatherinfo.temp2.ToString();
                elemHigh.Text = string.Format("{0} ~ {1}", low, high);
                elemHigh.TextAlignment = TileItemContentAlignment.TopLeft;
                frameOne.Elements.Add(elemHigh);

                TileItemElement elemtype = new TileItemElement();
                elemtype.Text = obj.weatherinfo.weather.ToString();
                elemtype.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", 18.0f, System.Drawing.GraphicsUnit.Point);
                elemtype.TextAlignment = TileItemContentAlignment.MiddleCenter;
                elemtype.Image = Utils.ImageFrom(string.Format("http://www.weather.com.cn/m/i/weatherpic/29x20/{0}", obj.weatherinfo.img1.ToString()));
                elemtype.ImageOptions.ImageAlignment = TileItemContentAlignment.TopRight;
                frameOne.Elements.Add(elemtype);

                TileItemElement elemCity = new TileItemElement();
                elemCity.Text = obj.weatherinfo.city.ToString();
                elemCity.TextAlignment = TileItemContentAlignment.BottomLeft;
                frameOne.Elements.Add(elemCity);


                TileItemElement elemDate = new TileItemElement();
                elemDate.Text = string.Format("{0} {1}", DateTime.Today.ToString("M月d日"), DateUtils.DayOfWeek(DateTime.Today));
                elemDate.TextAlignment = TileItemContentAlignment.BottomRight;
                frameOne.Elements.Add(elemDate);

                frameOne.Interval = 5000;
                frameOne.Animation = TileItemContentAnimationType.ScrollDown;

                t.Frames.Add(frameOne);
            }
            catch (Exception)
            {
                TileItemFrame tileFrameTmp = new TileItemFrame();
                tileFrameTmp.Elements.Add(new TileItemElement() { Text = "天气获取失败", TextAlignment = TileItemContentAlignment.MiddleCenter });
                tileFrameTmp.Appearance.Font = new Font("微软雅黑", 12.0f, System.Drawing.GraphicsUnit.Point);
                t.Frames.Add(tileFrameTmp);
                //throw;
            }


        }
        /// <summary>
        /// 创建主布局
        /// </summary>
        private void CreateLayout()
        {
            //await Task.Run(() => { });
            dataSource = new DataSource();
            windowsUIView.BeginUpdate();
            for (int i = 0; i < dataSource.Data.Groups.Count; i++)
            {
                DataGroup group = dataSource.Data.Groups[i];
                var uiBtn = new DevExpress.XtraBars.Docking2010.WindowsUIButton(group.Name, null, -1, DevExpress.XtraBars.Docking2010.ImageLocation.AboveText, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, null, true, -1, true, null, false, false, true, null, group.Name, -1, false, false);
                uiBtn.Appearance.ForeColor = Color.FromArgb(new Random(i).Next());
                tileContainer.Buttons.Add(uiBtn);
                foreach (DataItem item in group.Items)
                {
                    ItemDetailPage itemDetailPage = new ItemDetailPage(item);
                    itemDetailPage.Dock = System.Windows.Forms.DockStyle.Fill;
                    BaseDocument document = windowsUIView.AddDocument(itemDetailPage);
                    document.Caption = item.Topic;
                    CreateTile(document as Document, item);
                }
                CreateTileMore(group.Name);

            }
            windowsUIView.EndUpdate();
            windowsUIView.ActivateContainer(tileContainer);
            tileContainer.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(buttonClick);

        }
        /// <summary>
        /// 每个类别下有一个更多按钮
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Tile CreateTileMore(string topic)
        {
            var t = new Tile();
            t.Elements.Add(CreateTileItemElement("更多", TileItemContentAlignment.MiddleCenter, Point.Empty, 30));
            t.Click+= new TileClickEventHandler(moreTile_Click);
            t.Tag = topic;
            t.Group = topic;
            tileContainer.Items.Add(t);
            return t;
        }
        /// <summary>
        /// 更多按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moreTile_Click(object sender, TileClickEventArgs e)
        {
            var topic = e.Tile.Tag as string;
            var des = desc.ContainsKey(topic) ? desc[topic] : "";

            windowsUIView.BeginUpdate();
            PageGroup pg = new PageGroup();
            pg.Parent = tileContainer;
            pg.Caption = topic;
            GroupDetailPage pageGroup = new GroupDetailPage(topic, des);
            pageGroup.Tag = pg;//保存当前分组所在页面的容器
            var doc = windowsUIView.AddDocument(pageGroup);
            pg.Items.Add(doc as Document);
            windowsUIView.ContentContainers.Add(pg);
            windowsUIView.ActivateContainer(pg);
            windowsUIView.EndUpdate();
        }
        /// <summary>
        /// 创建单个tile控件
        /// </summary>
        /// <param name="document"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Tile CreateTile(Document document, DataItem item)
        {
            Random r = new Random();
            Tile tile = new Tile();
            tile.Document = document;
            tile.Group = item.Topic;
            tile.Tag = item;
            var str = item.Person;
            if (string.IsNullOrWhiteSpace(str))
            {
                str = item.Name;
            }
            if (string.IsNullOrWhiteSpace(str))
            {
                str = item.Organization;
            }
            tile.Elements.Add(CreateTileItemElement(str, TileItemContentAlignment.MiddleLeft, Point.Empty, 10));
            tile.Elements.Add(CreateTileItemElement(item.Location, TileItemContentAlignment.BottomLeft, new Point(0, 0), 10));
            tile.Elements.Add(CreateTileItemElement(item.Time.ToString("yyyy-MM-dd"), TileItemContentAlignment.BottomRight, new Point(0, 0), 12));
            tile.Elements.Add(CreateTileItemElement(item.Event_phrase, TileItemContentAlignment.Manual, new Point(0, 100), 12));
            Color color = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255));
            tile.Appearances.Selected.BackColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BackColor = color;
            tile.Appearances.Selected.BorderColor = tile.Appearances.Hovered.BorderColor = tile.Appearances.Normal.BorderColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            tile.Click += new TileClickEventHandler(tile_Click);
            //windowsUIView.Tiles.Add(tile);
            tileContainer.Items.Add(tile);
            return tile;
        }
        /// <summary>
        /// 创建TileItemElement
        /// </summary>
        /// <param name="text"></param>
        /// <param name="alignment"></param>
        /// <param name="location"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        TileItemElement CreateTileItemElement(string text, TileItemContentAlignment alignment, Point location, float fontSize)
        {
            TileItemElement element = new TileItemElement();
            element.TextAlignment = alignment;
            if (!location.IsEmpty) element.TextLocation = location;
            element.Appearance.Normal.Options.UseFont = true;
            element.Appearance.Normal.Font = new System.Drawing.Font("微软雅黑", fontSize);
            element.Text = text;
            //element.Image = Image.FromFile(@"C:\Users\Doraemon\Pictures\1.jpg");
            return element;
        }
        /// <summary>
        /// tile点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tile_Click(object sender, TileClickEventArgs e)
        {
            PageGroup page = ((e.Tile as Tile).ActivationTarget as PageGroup);
            if (page != null)
            {
                page.Parent = tileContainer;
                page.SetSelected((e.Tile as Tile).Document);
            }
        }
        /// <summary>
        /// 右上方按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void buttonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string topic = (e.Button.Properties.Tag as string);

            var des = desc.ContainsKey(topic) ? desc[topic] : "";
            PageGroup pg = new PageGroup();
            pg.Parent = tileContainer;
            pg.Caption = topic;
            GroupDetailPage pageGroup = new GroupDetailPage(topic, des);
            pageGroup.Tag = pg;//保存当前分组所在页面的容器
            var doc = windowsUIView.AddDocument(pageGroup);
            pg.Items.Add(doc as Document);
            windowsUIView.ContentContainers.Add(pg);
            windowsUIView.ActivateContainer(pg);
        }
        /// <summary>
        /// 热搜点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotSearchClick(object sender, TileClickEventArgs e)
        {
            try
            {
                var dt = e.Tile.Tag as System.Data.DataTable;
                PageGroup pg = new PageGroup();
                pg.Parent = tileContainer;
                pg.Caption = string.Format("微博实时热搜榜Top{0}", dt.Rows.Count);
                HotSearchChart chart = new HotSearchChart(dt);
                var doc = windowsUIView.AddDocument(chart);
                pg.Items.Add(doc as Document);
                windowsUIView.ContentContainers.Add(pg);
                windowsUIView.ActivateContainer(pg);
            }
            catch (Exception)
            {

                //throw;
            }

        }
        /// <summary>
        /// 热门话题点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HotTopicClick(object sender, TileClickEventArgs e)
        {
            var list = e.Tile.Tag as List<string>;
            PageGroup pg = new PageGroup();
            pg.Parent = tileContainer;
            pg.Caption = "微博实时话题榜";
            WordCloudPage chart = new WordCloudPage(list);
            var doc = windowsUIView.AddDocument(chart);
            pg.Items.Add(doc as Document);
            windowsUIView.ContentContainers.Add(pg);
            windowsUIView.ActivateContainer(pg);
        }

    }
}
