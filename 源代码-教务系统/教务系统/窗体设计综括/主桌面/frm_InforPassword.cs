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
    public partial class frm_InforPassword : Form
    {
        public frm_InforPassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private string _StudentNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">学号</param>
        public frm_InforPassword(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }
        //修改个人信息
        private void button1_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
             string conmand = $@"OPEN SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto
                                 DECRYPTION BY  ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto
                                 WITH PASSWORD = '1qaz@WSX'

                                 UPDATE tb_ChangeInformation SET
                                 PasswordQuestional1 = '{this.txt_Pwd1.Text}'
                               , Answer1 = ENCRYPTBYKEY(KEY_GUID('sk_EduBase_ForSymKeyCrypto'), '{this.txt_Aswer}')
                               , PasswordQuestional2 = '{this.txt_Pwd2.Text}'
                               , Answer2 = ENCRYPTBYKEY(KEY_GUID('sk_EduBase_ForSymKeyCrypto'), '{this.txt_Answer2}')

                               WHERE StuNo = '{this._StudentNo}'
                              CLOSE SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto ";
            
            int a = sqlHelper.QuickSubmit(conmand);
            if (a == 1)
            {
                MessageBox.Show
                ($"保存{a}条数据成功。",
                 "消息",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.txt_Pwd1.Clear();
            this.txt_Pwd2.Clear();
            this.txt_Answer2.Clear();
            this.txt_Aswer.Clear();
            

        }
        //修改密码
        private void button2_Click(object sender, EventArgs e)
        {
            string commandText =
               $"SELECT 1 FROM tb_LogIn AS U WHERE U.StuNo='{this._StudentNo}'AND U.Password=HASHBYTES('MD5','{this.txt_OldPassword.Text}')";
            SqlHelper sqlHelper = new SqlHelper();
            int result = sqlHelper.QuickReturn<int>(commandText);
            if (result == 1)
            {
                string conmand1 = $"UPDATE tb_LogIn SET Password=HASHBYTES('MD5','{txt_NewPassword.Text}') WHERE StuNo='{this._StudentNo}'";
                SqlHelper sqlHelper1 = new SqlHelper();
                int a = sqlHelper.QuickSubmit(conmand1);
                if (a == 1)
                {
                    MessageBox.Show
                   ($"保存{a}条数据成功。",
                    "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");
                this.txt_OldPassword.Focus();
                this.txt_OldPassword.SelectAll();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txt_OldPassword.Clear();
            this.txt_NewPassword.Clear();
            this.txt_PasswordAgain.Clear();
        }

        private void frm_InforPassword_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNo}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";
            }
            string conmand = $"SELECT * FROM tb_ChangeInformation where StuNO='{this._StudentNo}'";
            //SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(conmand);
            if (sqlHelper.HasRecord)
            {
                this.txt_Number.Text = sqlHelper["StuNO"].ToString();
                this.txt_Name.Text = sqlHelper["Name"].ToString();
                this.txt_No.Text= this._StudentNo;
            }
            
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //调整选项卡文字方向
            //创建颜色画刷
            SolidBrush lightPink = new SolidBrush(Color.MistyRose);
            SolidBrush lightPink1 = new SolidBrush(Color.White);
            SolidBrush _Brush = new SolidBrush(Color.Black);

            //RectangleF _TabTextArea = (RectangleF)tabControl1.GetTabRect(e.Index);//绘制区域
            //封装文本布局格式信息，并设置文本格式
            StringFormat _sf = new StringFormat();
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            //用画刷将选项卡外边填满
            Rectangle rectangle = new Rectangle(tabControl1.Left, tabControl1.Top, tabControl1.Width, tabControl1.Height);
            Region region = new Region(rectangle);
            e.Graphics.FillRegion(lightPink1, region);
            //用画刷将选项卡内部边框填满
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle Rec = tabControl1.GetTabRect(i);//返回选项卡控件中指定选项卡的边框
                e.Graphics.FillRectangle(lightPink, Rec);//用画刷将选项卡内部边框填满
                e.Graphics.DrawString(tabControl1.Controls[i].Text, SystemInformation.MenuFont, _Brush, Rec, _sf);//绘制指定文本字符串
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frm_HomePage form = new frm_HomePage(_StudentNo);
            form.Show();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frm_HomePage form = new frm_HomePage(_StudentNo);
            form.Show();
        }
    }
}
