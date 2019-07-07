using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBlogCalendar.Model
{
    public class Pair
    {
        public Pair(string word, string flag)
        {
            Word = word;
            Flag = flag;
        }

        public string Flag { get; set; }
        public string Word { get; set; }
    }
}
