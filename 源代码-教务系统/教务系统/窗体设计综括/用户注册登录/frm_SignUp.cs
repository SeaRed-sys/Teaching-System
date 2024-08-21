using SmartLinli.DatabaseDevelopement;
using System;
using System.Windows.Forms;

namespace 教务系统.窗体设计综括.用户注册登录
{
    public partial class frm_SignUp : Form
    {
        public frm_SignUp()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_SignUp;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
        }

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            string commandText =
                $@"INSERT tb_LogIn(StuNo,TeaNo,Name,Password)
					VALUES
					('{this.txt_No.Text.Trim()}','','',HASHBYTES('MD5','{this.txt_Password.Text.Trim()}'));";
            SqlHelper sqlHelper = new SqlHelper();
            int rowAffected = sqlHelper.QuickSubmit(commandText);
            if (rowAffected == 1)
            {
                MessageBox.Show("注册成功。");
                frm_Personal person = new frm_Personal(txt_No.Text);
                person.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("注册失败！");
            }
        }
    }
}
