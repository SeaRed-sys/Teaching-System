using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 教务系统.窗体设计综括.实践环节.实验预约;

namespace 教务系统
{
    public partial class frm_ExprimentManage : Form
    {
        //窗体的属性
        private string _StudentNumber;
        private string _StudentName;

        //窗体的构造函数
        public frm_ExprimentManage(string studentNumber,string studentName) : this()
        {
            this._StudentNumber = studentNumber;
            this._StudentName = studentName;
        }
        public frm_ExprimentManage()
        {
            InitializeComponent();
       
        }


        private void button5_Click(object sender, EventArgs e)
        {
            frm_ExprimentReservertion exprimentReservertion = new frm_ExprimentReservertion(_StudentNumber,_StudentName,cb_Term1.Text);
            exprimentReservertion.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                  ("目前暂无预约内容，请再次预约。",
                   "消息",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
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
    }
}
