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
using 教务系统.窗体设计综括.主桌面.公告留言;
using 教务系统.窗体设计综括.教学评价.评教界面;

namespace 教务系统
{
    public partial class frm_TeachingEvaluation : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_TeachingEvaluation(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_TeachingEvaluation()
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
            listView1.Columns.Add("序号 ", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("学年学期 ", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("评价分类", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("评价批次", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("开始时间", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("结束时间", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("操作", -2, HorizontalAlignment.Center);
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

        private void frm_TeachingEvaluation_Load(object sender, EventArgs e)
        {  
        }
        //双击打开评教界面
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string Term = this.listView1.SelectedItems[0].SubItems[1].Text;
            //公告留言唯一标识
            //string term = this.listView1.SelectedItems["学年学期"].ToString();
            //传参数到另一个窗体
            frm_Evaluate frmContent = new frm_Evaluate(this._StudentNumber, Term);
            //窗体加事件
            frmContent.FormClosed += FrmContent_FormClosed;
            //另一个窗体打开
            frmContent.ShowDialog();
        }
        private void FrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm_TeachingEvaluation_Load(null, null);
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText =
                $"SELECT * FROM tb_StuEvaluate WHERE StuNo='{this._StudentNumber}';";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[1] = dr["Term"].ToString();
                str[2] = dr["Type"].ToString();
                str[3] = dr["GroupName"].ToString();
                str[4] = dr["StartTime"].ToString();
                str[5] = dr["EndTime"].ToString();
                str[6] = dr["Operate"].ToString();
                str[0] = dr["No"].ToString();
                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[1]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                item.SubItems.Add(str[5]);
                item.SubItems.Add(str[6]);
                listView1.Items.Add(item);
            }
        }
    }
}
