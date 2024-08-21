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
    public partial class frm_SearchPassword : Form
    {
        public frm_SearchPassword()
        {
            InitializeComponent();
        }

        private void btn_SearchPassw_Click(object sender, EventArgs e)
        {
            string commandText =
            $@"OPEN SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto
                                 DECRYPTION BY  ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto
                                 WITH PASSWORD = '1qaz@WSX'
                    SELECT 1 
					FROM tb_ChangeInformation
					WHERE StuNo='{this.txt_No.Text.Trim()}' AND Answer1=HASHBYTES('MD5','{txt_Birth.Text}') AND Answer2=HASHBYTES('MD5','{txt_Age.Text}')";
            SqlHelper sqlHelper = new SqlHelper();
            int result = sqlHelper.QuickReturn<int>(commandText);
            commandText = $@"OPEN SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto
                                 DECRYPTION BY  ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto
                                 WITH PASSWORD = '1qaz@WSX'
                            SELECT Password FROM tb_LogIn WHERE StuNo='{this.txt_No.Text.Trim()}' ";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                string password = sqlHelper["Password"].ToString();
                MessageBox.Show
                ($"用户{this.txt_No.Text}的密码为：" + password,
                 "找回密码",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                frm_LogIn logIn = new frm_LogIn();
                logIn.Show();
                 this.Close();
            }

            

        }
    }
}
