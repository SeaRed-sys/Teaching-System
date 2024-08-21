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

namespace 教务系统.窗体设计综括.实践环节.实验预约
{
    
    public partial class frm_ExprimentReservertion : Form
    {
        //窗体的属性
        private string _StudentNumber;
        private string _StudentName;
        private string _StudentTerm;

        //窗体的构造函数
        public frm_ExprimentReservertion(string studentNumber,string studentName,string studentTerm) : this()
        {
            this._StudentNumber = studentNumber;
            this._StudentName = studentName;
            this._StudentTerm = studentTerm;
        }
        public frm_ExprimentReservertion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            string commandText = $@"insert tb_Expriment(StuNo,Term,ClassRoom,Faculty,ReservTime,Timespan,OperateTime) values
                                     ('{_StudentNumber}','{txt_Term.Text}','{cb_ClassRoom.Text}','{cb_Faculty.Text}','{txt_ExpriementTime.Text}','{txt_TimeSpan.Text}',getdate())";
            
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show($"确认预约消息无误吗?", "实验预约", messButton);
            if (dr == DialogResult.OK)
            {
                int rowAffected = sqlHelper.QuickSubmit(commandText);
                MessageBox.Show($"成功完成{rowAffected}条实验预约。");
            }
            this.Close();
        }

        private void frm_ExprimentReservertion_Load(object sender, EventArgs e)
        {
            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill("select * from tb_ClassRoom", cb_ClassRoom);
            sqlHelper.QuickFill("select * from tb_Faculty", cb_Faculty);
            txt_Term.Text = _StudentTerm;
        }
    }
}
