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
using 教务系统.窗体设计综括.主桌面.公告留言;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 教务系统
{
    public partial class frm_AnMessage : Form
    {
        //窗体的属性
        private string _StudentNumber;

        //窗体的构造函数
        public frm_AnMessage(string studentNumber) : this()
        {
            this._StudentNumber = studentNumber;
        }
        //窗体的初始值
        public frm_AnMessage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frm_HomePage form = new frm_HomePage(_StudentNumber);
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            frm_HomePage form = new frm_HomePage(_StudentNumber);
            form.Show();
        }

        private void btn_aLoad_Click(object sender, EventArgs e)
        {
            string commandeText =
                 //第一种情况tb_StudentMessage中有记录,则状态为“已读”
                 $"select M.No 序号, M.Title 标题,M.Type 类别,M.Sender 发送人,M.SendTime 发送时间,'已读' as 状态 " +
                 $"  from tb_Bulletin as M " +
                 $"  where M.StuNo='{this._StudentNumber}'and M.No in " +
                 $"      (select SM.OperateNo " +
                 $"          from tb_BulletinOperate as SM " +
                 $"          where SM.StuNo='{this._StudentNumber}')" +
                 //第二种情况tb_StudentMessage中无记录,则状态为“未读”
                 $"union all " +
                 $"select M.No 序号, M.Title 标题,M.Type 类别,M.Sender 发送人,M.SendTime 发送时间,'未读' as 状态 " +
                 $"  from tb_Bulletin as M " +
                 $"  where M.StuNo='{this._StudentNumber}'and M.No not in " +
                 $"      (select SM.OperateNo " +
                 $"          from tb_BulletinOperate as SM " +
                 $"          where SM.StuNo='{this._StudentNumber}');";
            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill(commandeText, this.dgv_Announce);
        }      

        private void btn_mLoad_Click(object sender, EventArgs e)
        {
            string commandeText =
                 //第一种情况tb_StudentMessage中有记录,则状态为“已读”
                 $"select M.No 序号, M.Title 标题,M.Type 类别,M.Sender 发送人,M.SendTime 发送时间,'已读' as 状态 " +
                 $"  from tb_Message as M " +
                 $"  where M.StuNo='{this._StudentNumber}'and M.No in " +
                 $"      (select SM.OperateNo " +
                 $"          from tb_MessageOperate as SM " +
                 $"          where SM.StuNo='{this._StudentNumber}')" +
                 //第二种情况tb_StudentMessage中无记录,则状态为“未读”
                 $"union all " +
                 $"select M.No 序号, M.Title 标题,M.Type 类别,M.Sender 发送人,M.SendTime 发送时间,'未读' as 状态 " +
                 $"  from tb_Message as M " +
                 $"  where M.StuNo='{this._StudentNumber}'and M.No not in " +
                 $"      (select SM.OperateNo " +
                 $"          from tb_MessageOperate as SM " +
                 $"          where SM.StuNo='{this._StudentNumber}');";
            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill(commandeText, this.dataGridView1);

        }

        //打开公告内容
        private void btn_open_Click(object sender, EventArgs e)
        {
            //公告留言唯一标识
            string messageNumber = this.dgv_Announce.CurrentRow.Cells["序号"].Value.ToString();
            //传参数到另一个窗体
            frm_AContent frmContent = new frm_AContent(this._StudentNumber, messageNumber);
            //窗体加事件
            frmContent.FormClosed += aFrmContent_FormClosed;
            //另一个窗体打开
            frmContent.ShowDialog();
        }
        private void aFrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btn_aLoad_Click(null,null);
        }
        //打开留言内容
        private void txt_MOpen_Click(object sender, EventArgs e)
        {
            //公告留言唯一标识
            string messageNumber = this.dataGridView1.CurrentRow.Cells["序号"].Value.ToString();
            //传参数到另一个窗体
            frm_MContent frmContent = new frm_MContent(this._StudentNumber, messageNumber);
            //窗体加事件
            frmContent.FormClosed += mFrmContent_FormClosed;
            //另一个窗体打开
            frmContent.ShowDialog();
        }
        private void mFrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btn_mLoad_Click(null, null);
        }

        private void frm_AnMessage_Load(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNumber}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";
            }
        }

        private void dgv_Message_DrawItem(object sender, DrawItemEventArgs e)
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
