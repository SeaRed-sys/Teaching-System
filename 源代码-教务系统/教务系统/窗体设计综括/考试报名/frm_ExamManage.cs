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
using 教务系统.窗体设计综括.用户注册登录;

namespace 教务系统
{
    public partial class frm_ExamManage : Form
    {
        //窗体的属性
        private string _StudentNumber;
        private string _StudentName;

        //窗体的构造函数
        public frm_ExamManage(string studentNumber,string studentName) : this()
        {
            this._StudentNumber = studentNumber;
            this._StudentName = studentName;
        }
        public frm_ExamManage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            listView1.Columns.Add("序号", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("学期", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("课程", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("开课单位", 160, HorizontalAlignment.Center);
            listView1.Columns.Add("考试周次", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("考试日期", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("午别", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("起始时间", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("考试教室", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("上课校区",100, HorizontalAlignment.Center);
            listView1.Columns.Add("考试校区", 100, HorizontalAlignment.Center);

        }

        private void frm_ExamApply_Load(object sender, EventArgs e)
        {
            //给下拉列表添加数据
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill("select distinct Term from tb_ExamApply", this.cb_Term1);
            sqlHelper.QuickFill("select distinct ApplyType from tb_ExamApply", this.cb_ApplyType);
            sqlHelper.QuickFill("select distinct Term from tb_ExamEndPlaning", this.cb_Term3);

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //调整选项卡文字方向
            SolidBrush lightPink = new SolidBrush(Color.MistyRose);//创建一个淡粉色画刷
            SolidBrush lightPink1 = new SolidBrush(Color.White);//创建一个淡粉色画刷
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)tabControl1.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            Rectangle Rec = tabControl1.GetTabRect(e.Index);//返回选项卡控件中指定选项卡的边框
            Rectangle rectangle = new Rectangle(tabControl1.Left, tabControl1.Top, tabControl1.Width, tabControl1.Height);
            e.Graphics.FillRectangle(lightPink, Rec);//用画刷将选项卡内部边框填满
            Region region = new Region(rectangle);
            e.Graphics.FillRegion(lightPink1, region);//用画刷将选项卡内部边框填满
            e.Graphics.DrawString(tabControl1.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);
        }
        //查询考试申请
        private void btn_Search1_Click(object sender, EventArgs e)
        {
            string commandText =
                $"select * from tb_ExamApply where Term='{this.cb_Term1.Text}' and StudentNo='{this._StudentNumber}'and Course='{this.txt_Course1.Text}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                string Message = $"{this._StudentName}" + "同学，" + "您于" + sqlHelper["ApplyTime"].ToString() + "申请" +
                                   "课程《"+sqlHelper["Course"].ToString() + "》"+sqlHelper["ApplyType"].ToString() + "" +
                                   "\n审核状态:" + sqlHelper["State"].ToString();
                MessageBox.Show
                          ($"{Message}",
                           "考试申请",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show
                          ($"无申请《{this.txt_Course1.Text}》课程任何记录",
                           "考试申请",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
        }
        //申请
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            string commandText =
                $@"insert tb_ExamApply(StudentNo,Term,Course,ApplyType,ApplyTime,ApplyReason)values
                   ('{this._StudentNumber}','{this.cb_Term2.Text}','{this.txt_Course2.Text}','{this.cb_ApplyType.Text}',GETDATE(),'{this.txt_ApplyReason.Text}');";
            SqlHelper sqlHelper = new SqlHelper();
            int rowAffected = sqlHelper.QuickSubmit(commandText);
            if (rowAffected == 1)
            {
                MessageBox.Show($"申请课程《{this.txt_Course2.Text}》{this.cb_ApplyType.Text}成功。"
                                ,"考试申请",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show($"申请课程《{this.txt_Course2.Text}》{this.cb_ApplyType.Text}失败！", "考试申请",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
            }
        }
        //查询考试安排
        private void btn_Search2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            listView1.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText;
            if (this.cb_ExamType.Text=="半期考")
            {
                commandText = $"select * from tb_ExamMediumPlaning where Term='{this.cb_Term3.Text}'";
            }
            else
            {
                commandText =$"select * from tb_ExamEndPlaning where Term='{this.cb_Term3.Text}'";
            }
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[1] = dr["Term"].ToString();
                str[2] = dr["Course"].ToString();
                str[3] = dr["Department"].ToString();
                str[4] = dr["WeekTime"].ToString();
                str[5] = dr["ExamTime"].ToString();
                str[6] = dr["Noon"].ToString();
                str[7] = dr["StartEndTime"].ToString();
                str[8] = dr["ClassRoom"].ToString();
                str[9] = dr["ClassCampus"].ToString();
                str[10] = dr["ExamCampus"].ToString();
                str[0] = dr["No"].ToString();
                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[1]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                item.SubItems.Add(str[5]);
                item.SubItems.Add(str[6]);
                item.SubItems.Add(str[7]);
                item.SubItems.Add(str[8]);
                item.SubItems.Add(str[9]);
                item.SubItems.Add(str[10]);
                listView1.Items.Add(item);
            }
        }
    } 
}
