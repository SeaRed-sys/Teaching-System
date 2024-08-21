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
using 教务系统.窗体设计综括.教学评价.评教界面;

namespace 教务系统
{
    public partial class frm_BookManage : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_BookManage(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_BookManage()
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
            listView1.Columns.Add("学年学期", 80, HorizontalAlignment.Center );
            listView1.Columns.Add("序号", -2, HorizontalAlignment.Center );
            listView1.Columns.Add("课程名称", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("教材名称", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("授课教师", 70, HorizontalAlignment.Center );
            listView1.Columns.Add("ISBN号", 90, HorizontalAlignment.Center );
            listView1.Columns.Add("教材作者", 150, HorizontalAlignment.Center );
            listView1.Columns.Add("出版社", 180, HorizontalAlignment.Center );
            listView1.Columns.Add("订购册数 ", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("操作", -2, HorizontalAlignment.Center );
                  
                                


            listView2.View = View.Details;
            // 整行选中
            listView2.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView2.Columns.Add("学年学期", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("序号", -2, HorizontalAlignment.Center);
            listView2.Columns.Add("课程名称", 120, HorizontalAlignment.Center);
            listView2.Columns.Add("课程性质", 80, HorizontalAlignment.Center);
            listView2.Columns.Add("教材名称", 180, HorizontalAlignment.Center);
            listView2.Columns.Add("ISBN书号", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("作者", 120, HorizontalAlignment.Center);
            listView2.Columns.Add("出版社", 150, HorizontalAlignment.Center);
            listView2.Columns.Add("金额", 50, HorizontalAlignment.Center);
            listView2.Columns.Add("册数 ", -2, HorizontalAlignment.Center);
            //listView2.Columns.Add("日期", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("方式", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("备注", 120, HorizontalAlignment.Center);

            listView3.View = View.Details;
            // 整行选中
            listView3.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView3.Columns.Add("学年学期", 80, HorizontalAlignment.Center);
            listView3.Columns.Add("课程名称", 120, HorizontalAlignment.Center);
            listView3.Columns.Add("教材名称", 180, HorizontalAlignment.Center);
            listView3.Columns.Add("ISBN书号", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("作者", 120, HorizontalAlignment.Center);
            listView3.Columns.Add("出版社", 150, HorizontalAlignment.Center);
            listView3.Columns.Add("金额", 50, HorizontalAlignment.Center);
            listView3.Columns.Add("日期", 90, HorizontalAlignment.Center);
            listView3.Columns.Add("方式", 100, HorizontalAlignment.Center);
            listView3.Columns.Add("备注", 120, HorizontalAlignment.Center);


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
        //学生教材选用
        private void btn_Look_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText=$"select * from tb_BookManage where StuNo='{this._StudentNumber}' order by Term";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["Term"].ToString();
                str[2] = dr["Course"].ToString();
                str[3] = dr["BookName"].ToString();
                str[4] = dr["Faculty"].ToString();
                str[5] = dr["BookIsbn"].ToString();
                str[6] = dr["BookAuthor"].ToString();
                str[7] = dr["BookPress"].ToString();
                str[8] = dr["BookAmount"].ToString();
                str[9] = dr["OrderType"].ToString();
                str[1] = dr["No"].ToString();
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
                listView1.Items.Add(item);
            }
        }
        //教材账目信息
        private void btn_Search_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText = $"select * from tb_BookManage where StuNo='{this._StudentNumber}' order by Term";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["Term"].ToString();
                str[2] = dr["Course"].ToString();
                str[3] = dr["StudyType"].ToString();
                str[4] = dr["BookName"].ToString();
                str[5] = dr["BookIsbn"].ToString();
                str[6] = dr["BookAuthor"].ToString();
                str[7] = dr["BookPress"].ToString();
                str[8] = dr["BookPrice"].ToString();
                str[9] = dr["BookAmount"].ToString();
               // str[10] = dr["BookOrderDate"].ToString();
                str[11] = dr["OrderType"].ToString();
                str[12] = dr["Remark"].ToString();
                str[1] = dr["No"].ToString();
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
                //item.SubItems.Add(str[10]);
                item.SubItems.Add(str[11]);
                item.SubItems.Add(str[12]);
                listView2.Items.Add(item);
            }
        }

        private void frm_BookManage_Load(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickFill("select distinct Term from tb_BookManage", this.cb_Term);
        }

        private void btn_Search2_Click(object sender, EventArgs e)
        {
            listView3.Visible = true;
            listView3.Items.Clear();
            string ConStr = "Data Source = 虹君LENOVO\\MSSQLSERVER01; Database = EduSystem;"
                + "Integrated Security = SSPI";
            // 创建连接
            SqlConnection SqlCon = new SqlConnection(ConStr);
            // 打开数据库
            SqlCon.Open();
            string commandText = $"select * from tb_BookManage where StuNo='{this._StudentNumber}' and Term='{this.cb_Term.Text}' order by Term";
            SqlDataAdapter sqlda = new SqlDataAdapter(commandText, SqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            string[] str = new string[1000];
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str[0] = dr["Term"].ToString();
                str[1] = dr["Course"].ToString();
                str[2] = dr["BookName"].ToString();
                str[3] = dr["BookIsbn"].ToString();
                str[4] = dr["BookAuthor"].ToString();
                str[5] = dr["BookPress"].ToString();
                str[6] = dr["BookPrice"].ToString();
                str[7] = dr["BookOrderDate"].ToString();
                str[8] = dr["OrderType"].ToString();
                str[9] = dr["Remark"].ToString();
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
                listView3.Items.Add(item);
            }
        }
        //进行教材订购
        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView3.SelectedItems[0].SubItems[9].Text == "未订购")
            {
                string Term = this.listView3.SelectedItems[0].SubItems[0].Text;
                string Book = this.listView3.SelectedItems[0].SubItems[2].Text;
                SqlHelper sqlHelper = new SqlHelper();
                string CommandText1 = $@"update tb_BookManage
                     set BookOrderDate=GETDATE()
                     where Term='{Term}'and BookName='{Book}'";
                string CommandText2 = $@"update tb_BookManage
                     set Remark='已成功完成订购'
                     where Term='{Term}'and BookName='{Book}'";
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show($"确定要订购《{Book}》吗?", "教材订购", messButton);
                if (dr == DialogResult.OK)
                {
                    int affectRow = sqlHelper.QuickSubmit(CommandText1);
                    sqlHelper.QuickSubmit(CommandText2);
                    MessageBox.Show($"成功订购{affectRow}本。");
                    btn_Search2_Click(null,null);
                }

            }
        }
    }
}
