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
    public partial class frm_Personal : Form
    {
        public frm_Personal()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Save;
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
        public frm_Personal(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            int Sex;
            if (txt_Sex.Text=="女"){
                Sex = 0;
            }
            else
            {
                Sex = 1;
            }
            string commandText =
                $@"INSERT tb_Personal(StuNo,Name,Gender,BirthDate,Specialty,Class)
					VALUES
					('{this.txt_No.Text.Trim()}','{this.txt_Name.Text.Trim()}',
                     '{Sex}','{this.txt_Birth.Text.Trim()}',
                     '{this.txt_Specialty.Text.Trim()}','{this.txt_Class.Text.Trim()}');";
            SqlHelper sqlHelper = new SqlHelper();
            int rowAffected = sqlHelper.QuickSubmit(commandText);
            if (rowAffected == 1)
            {
                MessageBox.Show("保存成功。");
                frm_LogIn logIn = new frm_LogIn();
                logIn.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void frm_Personal_Load(object sender, EventArgs e)
        {
            txt_No.Text = _StudentNo;
        }
    }
}
