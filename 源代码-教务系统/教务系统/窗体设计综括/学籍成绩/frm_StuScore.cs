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
    
    public partial class frm_StuScore : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_StuScore(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_StuScore()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //查询课程成绩
        private void button13_Click(object sender, EventArgs e)
        {
            string commandText =
                $@"SELECT *FROM tb_SelectStuScores WHERE 学号='{this._StudentNumber}'
                    AND 学期='{this.cb_Term.Text.Trim()}'AND 课程类型='{this.cb_StudyType.Text.Trim()}'
                    AND 课程='{this.txt_Course.Text.Trim()}'";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);           
            switch (cb_PrintType.Text)
            {
                case "显示全部成绩":
                    if (sqlHelper.HasRecord)
                    {
                        string Message = "课程名称：" + sqlHelper["课程"].ToString() + "\n"
                                            + "课程性质：" + sqlHelper["课程类型"].ToString()
                                            + "  开课时间：" + sqlHelper["学期"].ToString() + "\n"
                                             + "平时成绩：" + sqlHelper["平时成绩"].ToString() +
                                             "  期末成绩：" + sqlHelper["期末成绩"].ToString() +
                                             "  总成绩：" + sqlHelper["总成绩"].ToString();
                        MessageBox.Show
                          ($"{Message}。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show
                          ("无此课程数据。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    break;
                case "显示平时成绩":
                    if (sqlHelper.HasRecord)
                    {
                        string Message = "课程名称：" + sqlHelper["课程"].ToString() + "\n"
                                            + "课程性质：" + sqlHelper["课程类型"].ToString()
                                            + "  开课时间：" + sqlHelper["学期"].ToString() + "\n"
                                             + "平时成绩：" + sqlHelper["平时成绩"].ToString();
                        MessageBox.Show
                          ($"{Message}。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show
                          ("无此课程数据。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    break;
                case "显示期末成绩":
                    if (sqlHelper.HasRecord)
                    {
                        string Message = "课程名称：" + sqlHelper["课程"].ToString() + "\n"
                                            + "课程性质：" + sqlHelper["课程类型"].ToString()
                                            + "  开课时间：" + sqlHelper["学期"].ToString() + "\n"
                                            + "期末成绩：" + sqlHelper["期末成绩"].ToString();
                        MessageBox.Show
                          ($"{Message}。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show
                          ("无此课程数据。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    break;
                default:
                    if (sqlHelper.HasRecord)
                    {
                        string Message = "课程名称：" + sqlHelper["课程"].ToString() + "\n"
                                            + "课程性质：" + sqlHelper["课程类型"].ToString()
                                            + "  开课时间：" + sqlHelper["学期"].ToString() + "\n"
                                            + "总成绩 ：" + sqlHelper["总成绩"].ToString();
                        MessageBox.Show
                          ($"{Message}。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show
                          ("无此课程数据。",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }; 
                    break;
            }
        }
        //打印电子成绩单
        private void button1_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill("SELECT 学期,课程,学分,课程类型,考试类型,平时成绩,期末成绩,总成绩 FROM tb_SelectStuScores order by 学期", this.dgv_Score);
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
        //页面加载数据
        private void frm_StuScore_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT *FROM tb_StudentIDCard WHERE StuNo='{this._StudentNumber}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";     
            }
            sqlHelper.QuickFill("select distinct 学期 from tb_SelectStuScores", this.cb_Term);
            sqlHelper.QuickFill("select distinct 课程类型 from tb_SelectStuScores", this.cb_StudyType);
            commandText =
                $"Select No 序号 ,ExamCount 社会考试名称 ,Scores 分数,ExamTime 考试时间 from tb_GradeExam WHERE StuNo='{this._StudentNumber}';";
            sqlHelper.QuickFill(commandText, this.dgv_Scores);
        }

        private void dgv_Scores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string messageNumber = this.dgv_Scores.CurrentRow.Cells["序号"].Value.ToString();
            string  commandText =
                $"Select * from tb_GradeExam WHERE No='{messageNumber}'and StuNo={this._StudentNumber};";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                string Message = sqlHelper["Name"].ToString()+"同学，"+"您的"+ sqlHelper["ExamCount"].ToString()+"等级为：\n"
                                  + sqlHelper["Rank"].ToString();
                MessageBox.Show
                          ($"{Message}",
                           "消息",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
        }

    }
}
