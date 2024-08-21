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
using 教务系统.辅助项;

namespace 教务系统
{
    public partial class frm_CultruePlaning : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_CultruePlaning(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_CultruePlaning()
        {
            InitializeComponent();

        }
        
        

        private void Form7_Load(object sender, EventArgs e)
        {
            string commandText = "select No 序号,Term 学期,CourseNo 课程号,CourseName 课程名称, \r\nUnit 开课单位,CourseCredit 学分,CourseHour 学时,ExamType 考试类型,CourseType 课程类型,isExam 是否考试 from tb_TeachingTask";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill(commandText, this.dgv_TeachingTest);
            sqlHelper.QuickFill("select distinct TermName from tb_Course", this.cb_Term);
             commandText =
                $"SELECT *FROM tb_StudentIDCard WHERE StuNo='{this._StudentNumber}';";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.txt_Name.Text = sqlHelper["Name"].ToString();
                this.txt_Number.Text = sqlHelper["StuNo"].ToString();
                this.txt_Class.Text = sqlHelper["Class"].ToString();  
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

        private void cb_Term_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Term.Text == "2022-2023-1")
            {
                this.lbl_Term.Text = "2022-2023学年 第1学期 执行计划";
            }
            else if (cb_Term.Text == "2022-2023-2")
            {
                this.lbl_Term.Text = "2022-2023学年 第2学期 执行计划";
            }
            else if (cb_Term.Text == "2023-2024-1")
            {
                this.lbl_Term.Text = "2023-2024学年 第1学期 执行计划";
            }
            else if (cb_Term.Text == "2023-2024-2")
            {
                this.lbl_Term.Text = "2023-2024学年 第2学期 执行计划";
            }
            else if (cb_Term.Text == "2024-2025-1")
            {
                this.lbl_Term.Text = "2024-2025学年 第1学期 执行计划";
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            string commandeText =
                $@"select 
                TermName 学期,CourseNo 课程号 ,CourseName 课程名,CourseCredit 课程学分,StudyType 课程类别,ExamType 考查形式,Department 开课单位,Faculty 教师,FacultyTitle 教师级别 
                from tb_Course where TermName='{this.cb_Term.Text}'";

            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill(commandeText, this.dgv_TermPlan);
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            int selectCredit;
            int CompulsoryCredit;
            int alreadtCredit;
            string commandText =
               $"select sum(CONVERT(float,学分)) 学分 from tb_SelectStuScores;";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.txt_CompulsoryCredit.Text = sqlHelper["学分"].ToString();

            }
            commandText =
               $"select sum(CONVERT(float,Credit)) 学分 from tb_ChooseCourse;";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.txt_SelectCredit.Text = sqlHelper["学分"].ToString();


            }
            CompulsoryCredit = int.Parse(txt_CompulsoryCredit.Text);
            selectCredit = int.Parse(txt_SelectCredit.Text);
            alreadtCredit = CompulsoryCredit + selectCredit;
            txt_AlreadyCredit.Text = alreadtCredit.ToString();
        }
    }
}
