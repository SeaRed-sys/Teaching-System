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
using 教务系统.窗体设计综括.用户注册登录;

namespace 教务系统
{
    public partial class frm_HomePage : Form
    {
        public frm_HomePage()
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
        public frm_HomePage(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }
        private void 公告留言ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frm_AnMessage form2 = new frm_AnMessage(lbl_No.Text.Trim());
            form2.Show();
            this.Close();
            
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_InforPassword person =new frm_InforPassword(lbl_No.Text.Trim());
            person.Show();
            this.Close();
        }

        private void 教学周历ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TeachingCalendar form = new frm_TeachingCalendar(lbl_No.Text.Trim());
            form.Show();
            this.Close();
        }

        private void 学籍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_StuRollManage form = new frm_StuRollManage(lbl_No.Text.Trim());
            form.Show();
        }

        private void 我的成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_StuScore form = new frm_StuScore(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 培养方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CultruePlaning form = new frm_CultruePlaning(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 我的课表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CourseManage form = new frm_CourseManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 选课管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_SelectCourseManage form = new frm_SelectCourseManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 教材管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BookManage form = new frm_BookManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        

        private void 我的申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ExamManage frm_ExamApply = new frm_ExamManage(this.lbl_No.Text.Trim(),this.lbl_Name.Text.Trim());
            frm_ExamApply.Show();
        }

      
       

        private void 毕业设计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_GraduateProject form = new frm_GraduateProject(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 实验教学ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ExprimentManage form = new frm_ExprimentManage(this.lbl_No.Text.Trim(),this.lbl_Name.Text.Trim());
            form.Show();
        }

        private void 实习管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PracticeManage form = new frm_PracticeManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void 学生评教ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TeachingEvaluation form = new frm_TeachingEvaluation(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void XuanKe_Click(object sender, EventArgs e)
        {
            frm_SelectCourseManage form = new frm_SelectCourseManage(this.lbl_No.Text.Trim());
            form.Show();
            
        }

        private void XueShengPingjiao_Click(object sender, EventArgs e)
        {
            frm_TeachingEvaluation form = new frm_TeachingEvaluation(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_AnMessage form = new frm_AnMessage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frm_AnMessage form = new frm_AnMessage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_CultruePlaning form = new frm_CultruePlaning(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_StuRollManage form = new frm_StuRollManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_StuScore form = new frm_StuScore(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_TeachingCalendar form = new frm_TeachingCalendar(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_CourseManage form = new frm_CourseManage(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_StuScore form = new frm_StuScore(this.lbl_No.Text.Trim());
            form.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult messageboxResult =                                                 //定义对话框操作结果，用于接收消息框操作结果；
                MessageBox.Show                                                             //消息框的Show方法除了显示消息框，还能在用户完成对消息框的操作后，返回消息框操作结果；
                ("即将退出综合教务管理系统，请确认是否关闭！",
                 "警告",
                 MessageBoxButtons.YesNo,                                                   //消息框按钮；
                 MessageBoxIcon.Warning); 
            if (messageboxResult == DialogResult.Yes)                                       //若消息框操作结果为是；
            {
                MessageBox.Show("记得给五星好评哦^-^");
                frm_LogIn logIn = new frm_LogIn();
                logIn.Show();
                this.Close();
            }   
        }


        private void pic_Personnal_Click(object sender, EventArgs e)
        {
            frm_Person person = new frm_Person(this.lbl_No.Text.Trim());
            person.Show();
        }

        private void frm_HomePage_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNo}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "("+ sqlHelper["StuNo"].ToString() + ")";
                this.lbl_No.Text = sqlHelper["StuNo"].ToString();
                this.lbl_Name.Text = sqlHelper["Name"].ToString();
            }
            else
            {
                frm_Personal person = new frm_Personal();
                person.Show();
                this.Close();
            }
        }

    }
}
