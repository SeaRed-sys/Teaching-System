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
    public partial class frm_StuRollManage : Form
    {
        public frm_StuRollManage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private string _StudentNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">学号</param>
        public frm_StuRollManage(string studentNo) : this()
        {
            this._StudentNo = studentNo;
        }
        //打印学籍卡片
        private void button14_Click(object sender, EventArgs e)
        {
            string message = $@"学号：{this.txt_Number.Text}, 姓名：{this.txt_Name.Text},班级：{this.txt_Class.Text}
            籍贯：{this.txt_BirDifang.Text}  
            民族：{this.txt_Minzu.Text}
            性别：{this.txt_Sex.Text}           
            出生日期：{this.txt_Birth.Text}
            学院：{this.txt_Department.Text} 
            专业：{this.txt_Major.Text}
            学制：{this.txt_Length.Text}年                                          
            政治面貌：{this.txt_Zhenzhi.Text}  
            联系方式：{this.txt_Phone.Text}";
            MessageBox.Show
                    (message,
                     "学籍信息",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                   ("暂不能增加数据。",
                    "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                   ("申请成功。",
                    "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void frm_StuRollManage_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT *FROM tb_StudentIDCard WHERE StuNo='{this._StudentNo}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";
                this.txt_Name.Text = sqlHelper["Name"].ToString();
                this.txt_Number.Text = sqlHelper["StuNo"].ToString();
                this.txt_Class.Text = sqlHelper["Class"].ToString();
                this.txt_Sex.Text = sqlHelper["Sex"].ToString();
                this.txt_Department.Text = sqlHelper["Department"].ToString();
                this.txt_Length.Text = sqlHelper["StudyLength"].ToString();
                this.txt_Major.Text = sqlHelper["Major"].ToString();
                this.txt_Minzu.Text = sqlHelper["Nation"].ToString();
                this.txt_Phone.Text = sqlHelper["Phone"].ToString();
                this.txt_Zhenzhi.Text = sqlHelper["Political"].ToString();
                this.txt_BirDifang.Text = sqlHelper["NativePlace"].ToString();
                this.txt_Birth.Text = ((DateTime)sqlHelper["BirthDate"]).ToString();
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
    }
}
