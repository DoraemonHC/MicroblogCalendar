using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Model
{
    /// <summary>
    /// 命名实体类，也可能是事件短语等
    /// </summary>
    public class NameEntity
    {
        private string word;
        private string type;

        public string Word
        {
            get
            {
                return word;
            }

            set
            {
                word = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
    /// <summary>
    /// 判断两个命名实体是否相同,用于去重
    /// </summary>
    public class NameEntityListEquality : IEqualityComparer<NameEntity>
    {
        public bool Equals(NameEntity x, NameEntity y)
        {
            return x.Type == y.Type && x.Word == y.Word;
        }

        public int GetHashCode(NameEntity obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.Word.GetHashCode();
            }
        }
    }

}
