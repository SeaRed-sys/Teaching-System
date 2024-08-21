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
    public partial class frm_GraduateProject : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_GraduateProject(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        public frm_GraduateProject()
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
            listView1.Columns.Add("年度", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("设计(论文)题目", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("院系", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("指导老师", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("职称 ", -2, HorizontalAlignment.Center);
            listView1.Columns.Add("限选人数", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("选中人数 ", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("可报人数上限", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("操作", -2, HorizontalAlignment.Center);
                
                      

            // 设置显示模式
            listView2.View = View.Details;
            // 整行选中
            listView2.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            listView2.Columns.Add("届别", -2, HorizontalAlignment.Center);
            listView2.Columns.Add("题目编号", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("设计(论文)题目", 180, HorizontalAlignment.Center);
            listView2.Columns.Add("指导老师", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("开题报告", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("中期检查", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("结题报告", 90, HorizontalAlignment.Center);
            listView2.Columns.Add("操作", -2, HorizontalAlignment.Center);
                      
                      

        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                    ($"暂无。",
                     "消息",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
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
    }
}
