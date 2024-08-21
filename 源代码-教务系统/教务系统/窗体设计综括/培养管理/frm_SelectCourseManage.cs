using SmartLinli.DatabaseDevelopement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 教务系统
{
    public partial class frm_SelectCourseManage : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_SelectCourseManage(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_SelectCourseManage()
        {
            InitializeComponent();
            InitListView();
        }
        private void InitListView()
        {
            // 设置显示模式
            listView1.View = View.Details;
            // 整行选中
            listView1.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView1.Columns.Add("学年学期", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("选课类别", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("课程号", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("课程名称", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("开课单位", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("学分", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("考查方式", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("授课教师", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("选课时间", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("开课时间 ", 120, HorizontalAlignment.Center);
            listView1.Columns.Add("结课时间", 120, HorizontalAlignment.Center);




            listView2.View = View.Details;
            // 整行选中
            listView2.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView2.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("课程号", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("课程", 130, HorizontalAlignment.Center);
            listView2.Columns.Add("课程类别", 120, HorizontalAlignment.Center);
            listView2.Columns.Add("开课单位", 150, HorizontalAlignment.Center);
            listView2.Columns.Add("学分", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("考查方式", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("授课教师", 120, HorizontalAlignment.Center);

            listView3.View = View.Details;
            // 整行选中
            listView3.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView3.Columns.Add("学年学期", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("选课类别", 120, HorizontalAlignment.Center);
            listView3.Columns.Add("课程号", 120, HorizontalAlignment.Center);
            listView3.Columns.Add("课程名称", 180, HorizontalAlignment.Center);
            listView3.Columns.Add("学分", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("授课教师", 120, HorizontalAlignment.Center);
            listView3.Columns.Add("考查方式", 150, HorizontalAlignment.Center);
            listView3.Columns.Add("最终成绩", 100, HorizontalAlignment.Center);


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

        private void frm_SelectCourseManage_Load(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill("select * from tb_Term", cb_Term1);
            sqlHelper.QuickFill("select * from tb_Term", cb_Term3);
            sqlHelper.QuickFill("select distinct StudyType from tb_ChooseCourse",cb_StudyType1 );
            sqlHelper.QuickFill("select distinct StudyType from tb_ChooseCourse",cb_StudyType3 );
        }

        private void btn_Search1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText = $@"select *
                               from tb_ChooseCourse
                               where Term='{cb_Term1.Text}'and StudyType='{cb_StudyType1.Text}'
                               order by Term";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["Term"].ToString();
                str[2] = dr["StudyType"].ToString();
                str[3] = dr["CourseNo"].ToString();
                str[4] = dr["CourseName"].ToString();
                str[5] = dr["CourseDepartment"].ToString();
                str[6] = dr["Credit"].ToString();
                str[7] = dr["ExamType"].ToString();
                str[8] = dr["FacultyName"].ToString();
                str[9] = dr["ChoseTime"].ToString();
                str[10] = dr["StartTime"].ToString();
                str[11] = dr["EndTime"].ToString();
                
                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                item.SubItems.Add(str[5]);
                item.SubItems.Add(str[6]);
                item.SubItems.Add(str[7]);
                item.SubItems.Add(str[8]);
                item.SubItems.Add(str[9]);
                item.SubItems.Add(str[10]);
                item.SubItems.Add(str[11]);
                listView1.Items.Add(item);
            }
        }

        private void btn_Search3_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText = $@"select * from tb_ChooseCourse
                               where Term='{cb_Term3.Text}'and StudyType='{cb_StudyType3.Text}'
                               order by Term";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["Term"].ToString();
                str[2] = dr["StudyType"].ToString();
                str[3] = dr["CourseNo"].ToString();
                str[4] = dr["CourseName"].ToString();
                str[5] = dr["Credit"].ToString();
                str[6] = dr["FacultyName"].ToString();
                str[7] = dr["ExamType"].ToString();
                str[8] = dr["Score"].ToString();

                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                item.SubItems.Add(str[5]);
                item.SubItems.Add(str[6]);
                item.SubItems.Add(str[7]);
                item.SubItems.Add(str[8]);
                listView3.Items.Add(item);
            }
        }

        private void btn_Load2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText = $@"select * from tb_ChooseCourse order by No";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["No"].ToString();
                str[2] = dr["CourseNo"].ToString();
                str[3] = dr["CourseName"].ToString();
                str[4] = dr["StudyType"].ToString();
                str[5] = dr["CourseDepartment"].ToString();
                str[6] = dr["Credit"].ToString();
                str[7] = dr["ExamType"].ToString();
                str[8] = dr["FacultyName"].ToString();

                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                item.SubItems.Add(str[5]);
                item.SubItems.Add(str[6]);
                item.SubItems.Add(str[7]);
                item.SubItems.Add(str[8]);
                listView2.Items.Add(item);
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            int No = int.Parse(this.listView2.SelectedItems[0].SubItems[0].Text);
            string commandText = $@"select *from tb_ChooseCourse where No={No}";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                string Course = sqlHelper["CourseName"].ToString();                
                if (sqlHelper["Status"].ToString()=="未选")
                {
                    
                    string CommandText1 = $@"update tb_ChooseCourse
                     set ChoseTime=GETDATE()
                     where No={No}";
                    string CommandText2 = $@"update tb_ChooseCourse
                     set StartTime='2024-2-20'
                     where No={No}";
                    string CommandText3 = $@"update tb_ChooseCourse
                     set StartTime='2024-6-20'
                     where No={No}";
                    string CommandText4 = $@"update tb_ChooseCourse
                     set Term='2023-2024-2'
                     where No={No}";
                    string CommandText5 = $@"update tb_ChooseCourse
                     set Status='已选'
                     where No={No}";
                    MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                    DialogResult dr = MessageBox.Show($"确定要选修《{Course}》吗?", "学生选修", messButton);
                    if (dr == DialogResult.OK)
                    {
                        int affectRow = sqlHelper.QuickSubmit(CommandText1);
                        sqlHelper.QuickSubmit(CommandText2);
                        sqlHelper.QuickSubmit(CommandText3);
                        sqlHelper.QuickSubmit(CommandText4);
                        sqlHelper.QuickSubmit(CommandText5);
                        MessageBox.Show($"成功完成{affectRow}门课选修。");
                        btn_Search3_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show
                  ("已选修！",
                   "学生选修",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            
            
        }
    }
}
