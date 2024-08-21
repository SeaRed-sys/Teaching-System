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

namespace 教务系统.窗体设计综括.用户注册登录
{
    public partial class frm_Person : Form
    {
        public frm_Person()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
        }
        private string _StudentNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">学号</param>
        public frm_Person(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }

        private void frm_Person_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNo}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                if (sqlHelper["Gender"].Equals(1))
                {
                    this.txt_Sex.Text = "男";
                }
                else { this.txt_Sex.Text = "女"; }
                this.txt_Name.Text = sqlHelper["Name"].ToString();
                this.txt_No.Text = sqlHelper["StuNo"].ToString();
                this.txt_Class.Text = sqlHelper["Class"].ToString();
                //this.txt_Sex.Text = sqlHelper["Gender"].ToString();
                this.txt_Specialty.Text = sqlHelper["Specialty"].ToString();
                this.txt_Birth.Text = ((DateTime)sqlHelper["BirthDate"]).ToShortDateString();
            }
        }
    }
}
