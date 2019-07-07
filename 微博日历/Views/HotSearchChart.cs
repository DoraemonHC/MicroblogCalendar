using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 微博日历
{
    public partial class HotSearchChart : UserControl
    {
        public HotSearchChart(DataTable table)
        {
            InitializeComponent();
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl1.Series[0].DataSource = ConvertDataTable(table);
            chartControl1.Series[0].ArgumentDataMember = "title";
            chartControl1.Series[0].ValueDataMembers.AddRange("count");
        }
        /// <summary>
        /// 修改数据表DataTable某一列的类型和记录值(正确步骤：1.克隆表结构，2.修改列类型，3.修改记录值，4.返回希望的结果)
        /// </summary>
        /// <param name="dt">数据表DataTable</param>
        /// <returns>数据表DataTable</returns>
        private DataTable ConvertDataTable(DataTable dt)
        {
            DataTable datatable = new DataTable();
            //克隆表结构，表的数据并没有克隆
            datatable = dt.Clone();
            //修改列类型
            datatable.Columns["count"].DataType = typeof(int);
            //为新表填充数据
            foreach (DataRow row in dt.Rows)
            {
                DataRow nr = datatable.NewRow();
                nr["title"] = row["title"];
                //修改记录值
                nr["count"] = Convert.ToInt32(row["count"]);
                datatable.Rows.Add(nr);
            }
            //返回一个DataTa
            return datatable;
        }
    }
}
