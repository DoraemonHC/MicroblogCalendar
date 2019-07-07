using MicroBlogCalendar.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微博日历
{
    public class DataItem
    {
        string tid, text, name, person, location, organization, event_phrase, topic, original_pic;
        DateTime time;
        public string Tid { get { return tid; } }
        public string Text { get { return text; } }
        public string Name { get { return name; } }
        public string Person { get { return person; } }
        public string Location { get { return location; } }
        public string Organization { get { return organization; } }
        public string Event_phrase { get { return event_phrase; } }
        public DateTime Time { get { return time; } }
        public string Topic { get { return topic; } }
        public string Original_pic { get { return original_pic; } }

        public DataItem() { }
        public DataItem(string tid,string text, string topic,string name, string person, string location, string organization, string event_phrase,DateTime time,string original_pic)
        {
            this.tid = tid;
            this.text = text;
            this.name = name;
            this.person = person;
            this.location = location;
            this.organization = organization;
            this.event_phrase = event_phrase;
            this.time = time;
            this.topic = topic;
            this.original_pic = original_pic;
        }
    }

    public class DataGroup
    {
        string nameCore,descriptionCore;
        Collection<DataItem> itemsCore;
        public DataGroup(string name,string description)
        {
            this.nameCore = name;
            this.descriptionCore = description;
            itemsCore = new Collection<DataItem>();
        }
        public string Name { get { return nameCore; } }
        public string Description { get { return descriptionCore; } }
        public Collection<DataItem> Items { get { return itemsCore; } }
        public bool AddItem(DataItem tile)
        {
            if (!itemsCore.Contains(tile))
            {
                itemsCore.Add(tile);
                return true;
            }
            return false;
        }
    }

    class DataModel
    {
        Collection<DataGroup> groupsCore;
        public DataModel()
        {
            groupsCore = new Collection<DataGroup>();
        }
        public Collection<DataGroup> Groups { get { return groupsCore; } }
        DataGroup GetGroup(string name)
        {
            foreach (var group in groupsCore)
                if (group.Name == name) return group;
            return null;
        }
        public bool AddItem(DataItem tile)
        {
            if (tile == null) return false;
            string groupName = tile.Topic == null ? "" : tile.Topic;
            DataGroup thisGroup = GetGroup(groupName);
            if (thisGroup == null)
            {
                thisGroup = new DataGroup(groupName, "这是描述");
                groupsCore.Add(thisGroup);
            }
            return thisGroup.AddItem(tile);
        }
        bool ContainsGroup(string name)
        {
            return GetGroup(name) != null;
        }
        public void CreateGroup(string name,string description)
        {
            if (ContainsGroup(name)) return;
            DataGroup group = new DataGroup(name, description);
            groupsCore.Add(group);
        }
    }

    class DataSource
    {
        DataModel dataCore;
        public DataModel Data { get { return dataCore; } }
        public DataSource()
        {
            dataCore = new DataModel();
            string sql = @"SELECT result.tid,text,topic,name,person,location,organization,event,event_date,original_pic 
from result,home_timeline 
where result.tid=home_timeline.tid  and date(event_date)< '@endDate' and event != ''
order by date(event_date) desc,datetime(created_at) desc limit 80;";
            System.Data.SQLite.SQLiteParameter[] pms = new System.Data.SQLite.SQLiteParameter[]
                {
                    //new System.Data.SQLite.SQLiteParameter("startDate",DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd")),//过去30天
                    new System.Data.SQLite.SQLiteParameter("endDate",DateTime.Today.AddDays(5).ToString("yyyy-MM-dd")),//最多未来5天
                };
            var reader = SQLiteHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                var tid = reader.GetString(0);
                var text = reader.GetString(1);
                var topic = reader.IsDBNull(2) ? "" : reader.GetString(2);
                var name = reader.GetString(3);
                var person = reader.GetString(4);
                var location = reader.GetString(5);
                var organization = reader.GetString(6);
                var event_phrase = reader.GetString(7);
                var time = reader.IsDBNull(8) ? "" : reader.GetString(8);
                var original_pic = reader.IsDBNull(9) ? "" : reader.GetString(9);
                dataCore.AddItem(new DataItem(tid, text, topic, name, person, location, organization, event_phrase, Convert.ToDateTime(time), original_pic));
            }
        }

        public DataSource(string topic,int limit)
        {
            dataCore = new DataModel();
            string sql = @"SELECT result.tid,text,topic,name,person,location,organization,event,event_date,original_pic 
                from result,home_timeline 
where result.tid=home_timeline.tid and topic=@topic  
order by date(event_date) desc,datetime(created_at) desc limit @count;";

            System.Data.SQLite.SQLiteParameter[] pms = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("count",limit),
                    new System.Data.SQLite.SQLiteParameter("topic",topic),
                };
            var reader = SQLiteHelper.ExecuteReader(sql, pms);
            while (reader.Read())
            {
                var tid = reader.GetString(0);
                var text = reader.GetString(1);
                var topics = reader.IsDBNull(2) ? "" : reader.GetString(2);
                var name = reader.GetString(3);
                var person = reader.GetString(4);
                var location = reader.GetString(5);
                var organization = reader.GetString(6);
                var event_phrase = reader.GetString(7);
                var time = reader.IsDBNull(8) ? "" : reader.GetString(8);
                var original_pic = reader.IsDBNull(9) ? "":reader.GetString(9);
                dataCore.AddItem(new DataItem(tid, text, topics, name, person, location, organization, event_phrase, Convert.ToDateTime(time), original_pic));
            }
        }

        /// <summary>
        /// 根据微博id获取微博数据
        /// </summary>
        /// <param name="tid"></param>
        public DataSource(string tid)
        {
            dataCore = new DataModel();
            string sql = @"SELECT result.tid,text,topic,name,person,location,organization,event,event_date,original_pic 
from result,home_timeline 
where result.tid=home_timeline.tid  and home_timeline.tid=@tid;";

            System.Data.SQLite.SQLiteParameter[] pms = new System.Data.SQLite.SQLiteParameter[]
                {
                    new System.Data.SQLite.SQLiteParameter("tid",tid),
                };
            var reader = SQLiteHelper.ExecuteReader(sql, pms);
            while (reader.Read())
            {
                var tid2 = reader.GetString(0);
                var text = reader.GetString(1);
                var topics = reader.IsDBNull(2) ? "" : reader.GetString(2);
                var name = reader.GetString(3);
                var person = reader.GetString(4);
                var location = reader.GetString(5);
                var organization = reader.GetString(6);
                var event_phrase = reader.GetString(7);
                var time = reader.IsDBNull(8) ? "" : reader.GetString(8);
                var original_pic = reader.IsDBNull(9) ? "" : reader.GetString(9);
                dataCore.AddItem(new DataItem(tid2, text, topics, name, person, location, organization, event_phrase, Convert.ToDateTime(time), original_pic));
            }
        }

    }

}
