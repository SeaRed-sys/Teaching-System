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
    public partial class frm_CourseManage : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_CourseManage(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_CourseManage()
        {
            InitializeComponent();
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
        //选修课课表查询
        private void button9_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string commandText = $@"select * from tb_ClassTime2 where Term='{this.cb_Term2.Text}' ";
            //dgv_ClassTime1.RowTemplate.Height = 110;
            sqlHelper.QuickFill(commandText, dgv_ClassTime2);
        }
        private void btn_Search1_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string commandText = $@"select * from tb_ClassTime1 where Term='{this.cb_Term.Text}' ";
            //dgv_ClassTime2.RowTemplate.Height = 110;
            sqlHelper.QuickFill(commandText, dgv_ClassTime1);
        }

        private void frm_CourseManage_Load(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill("select * from tb_Term", cb_Term);
            sqlHelper.QuickFill("select * from tb_Week", cb_Week );
            sqlHelper.QuickFill("select * from tb_Term", cb_Term2);
            sqlHelper.QuickFill("select * from tb_Term", cb_Term3);
            sqlHelper.QuickFill("select * from tb_Term", cb_Term4);
            sqlHelper.QuickFill("select * from tb_Term", cb_Term5);
            sqlHelper.QuickFill("select * from tb_Week", cb_Week2);
            sqlHelper.QuickFill("select * from tb_Week", cb_Week31);
            sqlHelper.QuickFill("select * from tb_Week", cb_Week4);
            sqlHelper.QuickFill("select * from tb_Week", cb_Week5);
            //sqlHelper.QuickFill("select * from tb_Week", cb_Week32);
            sqlHelper.QuickFill("select Name from tb_FacultyTitle", cb_FacultyTitle3);
            sqlHelper.QuickFill("select Name from tb_Faculty",cb_Faculty3 );
            sqlHelper.QuickFill("select Name from tb_ClassRoom", cb_ClassRoom4);
            sqlHelper.QuickFill("select distinct Building from tb_ClassRoom",cb_Building4 );
            sqlHelper.QuickFill("select  distinct Campus from tb_ClassRoom", cb_Department4);
            sqlHelper.QuickFill("select distinct Course from tb_Curriculum", cb_Course5);
        }
        //查询教师课表
        private void btn_Search3_Click(object sender, EventArgs e)
        {
            string commandText;
            if (cb_Faculty3.Text == "-请选择-" && cb_FacultyTitle3.Text == "-请选择-" &&cb_Week31.Text == "-请选择-" )
            {
                 commandText = $@"select Term 学期,Week 周次 ,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,Faculty 教师,FacultyTitle 教师职称,Building 楼,Name 教室
                                from tb_Curriculum
                                where Term='{this.cb_Term3.Text}'
                                 order by ClassDate ";
            }
            else if(cb_Faculty3.Text != "-请选择-" && cb_FacultyTitle3.Text == "-请选择-" && cb_Week31.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次 ,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,Faculty 教师,FacultyTitle 教师职称,Building 楼,Name 教室
                                from tb_Curriculum
                                where Term='{this.cb_Term3.Text}'and Faculty='{this.cb_Faculty3.Text}'
                                 order by ClassDate ";
            }
            else if (cb_Faculty3.Text != "-请选择-" && cb_FacultyTitle3.Text != "-请选择-"&& cb_Week31.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次 ,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,Faculty 教师,FacultyTitle 教师职称,Building 楼,Name 教室
                                from tb_Curriculum
                                where Term='{this.cb_Term3.Text}'and Faculty='{this.cb_Faculty3.Text}' and FacultyTitle='{this.cb_FacultyTitle3.Text}'
                                 order by ClassDate ";
            }
            else
            {
                commandText = $@"select Term 学期,Week 周次 ,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,Faculty 教师,FacultyTitle 教师职称,Building 楼,Name 教室
                                from tb_Curriculum
                                where Term='{this.cb_Term3.Text}'and Faculty='{this.cb_Faculty3.Text}' and FacultyTitle='{this.cb_FacultyTitle3.Text}'and Week='{this.cb_Week31.Text}'
                                 order by ClassDate ";
            }
            SqlHelper sqlHelper = new SqlHelper();
            
            //dgv_ClassTime2.RowTemplate.Height = 110;
            sqlHelper.QuickFill(commandText, dgv_ClassTime3);
        }
        //查询教室课表
        private void btn_Search4_Click(object sender, EventArgs e)
        {
            string commandText;
            if (cb_Department4.Text == "-请选择-" && cb_Building4.Text == "-请选择-" && cb_ClassRoom4.Text == "-请选择-" && cb_Week4.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,Week 星期,Noon 午别,ClassTimeName 上课时间,Campus 校区,Building 教学楼,Name 教室,Course 课程,Department 开课单位,Faculty 教师
                               from tb_Curriculum
                               where Term='{cb_Term4.Text}'
                               order by ClassDate ";
            }
           
            else if (cb_Department4.Text != "-请选择-" && cb_Building4.Text != "-请选择-" && cb_ClassRoom4.Text == "-请选择-" && cb_Week4.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,Week 星期,Noon 午别,ClassTimeName 上课时间,Campus 校区,Building 教学楼,Name 教室,Course 课程,Department 开课单位,Faculty 教师
                               from tb_Curriculum
                               where Term='{cb_Term4.Text}' and Building='{cb_Building4.Text}'
                               order by ClassDate ";
            }
            else if (cb_Department4.Text != "-请选择-" && cb_Building4.Text != "-请选择-" && cb_ClassRoom4.Text != "-请选择-" && cb_Week4.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,Week 星期,Noon 午别,ClassTimeName 上课时间,Campus 校区,Building 教学楼,Name 教室,Course 课程,Department 开课单位,Faculty 教师
                               from tb_Curriculum
                               where Term='{cb_Term4.Text}'and Campus='{cb_Department4.Text}' and Building='{cb_Building4.Text}' and Name='{cb_ClassRoom4.Text}' 
                               order by ClassDate ";
            }
            else
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,Week 星期,Noon 午别,ClassTimeName 上课时间,Campus 校区,Building 教学楼,Name 教室,Course 课程,Department 开课单位,Faculty 教师
                               from tb_Curriculum
                               where Term='{cb_Term4.Text}'  and Name='{cb_ClassRoom4.Text}'and Week='{cb_Week4.Text}'
                               order by ClassDate ";
            }
            SqlHelper sqlHelper = new SqlHelper();

            //dgv_ClassTime2.RowTemplate.Height = 110;
            sqlHelper.QuickFill(commandText, dgv_ClassTime4);
        }



        private void btn_Search5_Click(object sender, EventArgs e)
        {
            string commandText;
            if (cb_Term5.Text == "-请选择-" && cb_Course5.Text != "-请选择-" && cb_Week5.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,StudyType 课程性质,Department 开课单位,Faculty 教师,Campus 校区,Building 教学楼,Name 教室
                               from tb_Curriculum
                               where Course='{cb_Course5.Text}'
                               order by ClassDate ";
            }
            else if (cb_Term5.Text != "-请选择-" && cb_Course5.Text == "-请选择-" && cb_Week5.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,StudyType 课程性质,Department 开课单位,Faculty 教师,Campus 校区,Building 教学楼,Name 教室
                               from tb_Curriculum
                               where Term='{cb_Term5.Text}'
                               order by ClassDate ";
            }
            else if (cb_Term5.Text != "-请选择-" && cb_Course5.Text != "-请选择-" && cb_Week5.Text == "-请选择-")
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,StudyType 课程性质,Department 开课单位,Faculty 教师,Campus 校区,Building 教学楼,Name 教室
                               from tb_Curriculum
                               where Term='{cb_Term5.Text}'and Course='{cb_Course5.Text}'
                               order by ClassDate ";
            }         
            else
            {
                commandText = $@"select Term 学期,Week 周次,ClassDate 日期,WeekTime 星期,Noon 午别,ClassTimeName 上课时间,Course 课程,StudyType 课程性质,Department 开课单位,Faculty 教师,Campus 校区,Building 教学楼,Name 教室
                               from tb_Curriculum
                               where Term='{cb_Term5.Text}'and Course='{cb_Course5.Text}' and Week='{cb_Week5.Text}' 
                               order by ClassDate ";
            }
            SqlHelper sqlHelper = new SqlHelper();

            //dgv_ClassTime2.RowTemplate.Height = 110;
            sqlHelper.QuickFill(commandText, dgv_ClassTime5);
        }

        private void cb_Term5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            cb_Course5.Items.Clear();
            sqlHelper.QuickFill($"select distinct Course from tb_Curriculum where Term='{cb_Term5.Text}'", cb_Course5);
        }

        private void cb_Building4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            cb_ClassRoom4.Items.Clear();
            sqlHelper.QuickFill($"select Name from tb_ClassRoom where Building='{cb_Building4.Text}'", cb_ClassRoom4);
        }

        private void cb_Term4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_Faculty3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            cb_FacultyTitle3.Items.Clear();
            sqlHelper.QuickFill($"select distinct FacultyTitle from tb_Curriculum where Faculty='{cb_Faculty3.Text}'", cb_FacultyTitle3);
        }

        private void cb_Term3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            cb_Faculty3.Items.Clear();
            sqlHelper.QuickFill($"select distinct Faculty from tb_Curriculum where Term='{cb_Term3.Text}'", cb_Faculty3);
        }
    }
}
