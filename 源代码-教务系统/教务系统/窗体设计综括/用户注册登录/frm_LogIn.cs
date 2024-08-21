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

namespace 教务系统.窗体设计综括.用户注册登录
{
    public partial class frm_LogIn : Form
    {
        public frm_LogIn()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Login;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string commandText =
            $@"SELECT 1 
					FROM tb_LogIn
					WHERE StuNo='{this.txt_No.Text.Trim()}' AND Password=HASHBYTES('MD5','{this.txt_Password.Text}');";
            SqlHelper sqlHelper = new SqlHelper();
            int result = sqlHelper.QuickReturn<int>(commandText);
            if (result == 1)
            {
                MessageBox.Show("登录成功。");
                frm_HomePage homePage = new frm_HomePage(this.txt_No.Text.Trim());
                homePage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");
                this.txt_Password.Focus();
                this.txt_Password.SelectAll();
            }
        }

        private void linlbl_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_SignUp signUp = new frm_SignUp();
            signUp.Show();
            this.Close();
        }


    }
}
