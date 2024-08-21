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

namespace 教务系统.窗体设计综括.主桌面.公告留言
{
    public partial class frm_MContent : Form
    {
        //窗体属性
        private string _StudentNumber;
        private string _MessageNumber;

        //构造函数
        public frm_MContent(string studentNumber, string messageNumber) : this()
        {
            this._StudentNumber = studentNumber;
            this._MessageNumber = messageNumber;
        }
        //初始化
        public frm_MContent()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //加载页面时的操作
        private void frm_MContent_Load_1(object sender, EventArgs e)
        {
            string commandText =
                $"SELECT * FROM tb_Personal WHERE StuNo='{this._StudentNumber}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.lbl_MainName.Text = sqlHelper["Name"].ToString() + "(" + sqlHelper["StuNo"].ToString() + ")";
            }
            //查找表中tb_Content中的内容
             commandText =
                $"select M.Text" +
                $"  from tb_Message as M" +
                $"  where M.No={this._MessageNumber} and M.StuNo='{this._StudentNumber}';";
            //SqlHelper sqlHelper = new SqlHelper();
            //显示内容
            string content = sqlHelper.QuickReturn<string>(commandText);
            this.txt_Content.Text = content;
            commandText =
                $"select *" +
            //查找表填tb_StudentReadMessage中的所有内容
                $"  from tb_MessageOperate as SM" +
                $"  where StuNo='{this._StudentNumber}'" +
                $"      and SM.OperateNo='{this._MessageNumber}'";
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                this.txt_Reply.Text = sqlHelper["Text"] == null ? "" : sqlHelper["Text"].ToString();
            }
            else
            {
                commandText =
                    $"insert tb_MessageOperate(StuNo,OperateNo)" +
                    $"  values('{this._StudentNumber}','{this._MessageNumber}');";
                //受影响行数
                sqlHelper.QuickSubmit(commandText);
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //更新数据库中tb_StudentReadMessage的Reply属性内容
            string commandText =
                $"update tb_MessageOperate" +
                $"  set Text='{this.txt_Reply.Text.Trim()}'" +
                $"  where StuNo='{this._StudentNumber}' " +
                $"      and OperateNo='{this._MessageNumber}';";
            //新建的sqlHelper类
            SqlHelper sqlHelper = new SqlHelper();
            //传回影响条数，回复更新表中数据成功
            int rowAffected = sqlHelper.QuickSubmit(commandText);
            MessageBox.Show($"成功提交{rowAffected}条回复");
            this.Close();
        }


    }
}
