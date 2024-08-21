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

namespace 教务系统
{
    public partial class frm_TeachingCalendar : Form
    {
        public frm_TeachingCalendar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;           
        }
        private string _StudentNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">学号</param>
        public frm_TeachingCalendar(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }
        private void frm_TeachingCalendar_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNo}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";
            }

            sqlHelper.QuickFill("SELECT distinct TermName FROM tb_TeachingCalender", this.cb_Term);

        }


        private void btn_Print_Click(object sender, EventArgs e)
        {
            string commandeText =
                 $@"SELECT distinct Date 日期,TermPart 学期部分,TeachingWeek 周次,WeekDay 星期,Remark 任务,TermName 学期 
                      FROM tb_TeachingCalender AS T
                      WHERE  T.TermName='{this.cb_Term.Text}'";

            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill(commandeText, this.gv_TeachingCalendar);
        }

        private void cb_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Term.Text == "2023-2024-1")
            {
                this.lbl_Term.Text = "2023-2024学年 第1学期 教学周历";
            }
            else
            {
                this.lbl_Term.Text = "2023-2024学年 第2学期 教学周历";
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frm_HomePage form = new frm_HomePage(_StudentNo);
            form.Show();
        }
    }
}
