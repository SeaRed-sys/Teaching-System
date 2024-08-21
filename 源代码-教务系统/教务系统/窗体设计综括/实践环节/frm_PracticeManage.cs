using SmartLinli.DatabaseDevelopement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 教务系统
{
    public partial class frm_PracticeManage : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_PracticeManage(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_PracticeManage()
        {
            InitializeComponent();
            InitListView();
        }
        private void InitListView()
        {
            // 设置显示模式
            listView1.View = View.Details;
            // 整行选中
            listView1.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView1.Columns.Add("序号", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("学年", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("实习医院", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("实习科室", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("分组名", 85, HorizontalAlignment.Center);
            listView1.Columns.Add("安排周次", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("安排时间", -2, HorizontalAlignment.Center);
                         


        }

        private void frm_PracticeManage_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Practice WHERE StuNo='{this._StudentNumber}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                ListViewItem item  = new ListViewItem( sqlHelper["No"].ToString() );
                item.SubItems.Add(sqlHelper["Term"].ToString());
                item.SubItems.Add(sqlHelper["Hospital"].ToString());
                item.SubItems.Add(sqlHelper["HospitalDepart"].ToString());
                item.SubItems.Add(sqlHelper["GroupNo"].ToString());
                item.SubItems.Add(sqlHelper["Week"].ToString());
                item.SubItems.Add(sqlHelper["Time"].ToString());
                listView1.Items.Add(item);
            }
        }
    }
}
