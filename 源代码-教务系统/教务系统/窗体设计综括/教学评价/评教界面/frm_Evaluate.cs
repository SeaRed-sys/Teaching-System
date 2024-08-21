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

namespace 教务系统.窗体设计综括.教学评价.评教界面
{
    public partial class frm_Evaluate : Form
    {
        //窗体属性
        private string _StudentNumber;
        private string _Term;

        //构造函数
        public frm_Evaluate(string studentNumber, string term) : this()
        {
            this._StudentNumber = studentNumber;
            this._Term = term;
        }
        public frm_Evaluate()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_Evaluate_Load(object sender, EventArgs e)
        {
            string commandText =
                $"select Term 学期,FacultyName 教师,FacultyDepartment 所属部门 from tb_StudentEvaluate WHERE StudentNo='{this._StudentNumber}'and Term='{this._Term}';";
            SqlHelper sqlHelper = new SqlHelper();
            //快速填充数据
            sqlHelper.QuickFill(commandText, this.dgv_StudentEvaluate);
            string command =
                $"select * from tb_StuEvaluate WHERE StuNo='{this._StudentNumber}'and Term='{this._Term}';";
            sqlHelper.QuickRead(command);
            if (sqlHelper.HasRecord)
            {
                if (sqlHelper["Operate"].ToString() == "未评教")
                {
                    this.btn_open.Visible = false;
                    this.btn_Evaluate.Visible = true;
                    this.btn_Complete.Visible = true;
                }
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            string Faculty = this.dgv_StudentEvaluate.CurrentRow.Cells["教师"].Value.ToString();
            string commandText =
                $"select * from tb_StudentEvaluate WHERE StudentNo='{this._StudentNumber}'and Term='{this._Term}'and FacultyName='{Faculty}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                string Message = "评教学期：" + sqlHelper["Term"].ToString() +
                                 "\n教师姓名：" + sqlHelper["FacultyName"].ToString() +
                                 "\n教师级别：" + sqlHelper["FacultyTitle"].ToString() +
                                 "\n所属部门：" + sqlHelper["FacultyDepartment"].ToString() +
                                 "\n所授学科：" + sqlHelper["Course"].ToString() +
                                 "\n学生评分：" + sqlHelper["FacultyRate"].ToString();
                MessageBox.Show
                          ($"{Message}",
                           "学生评教",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            }
            
        }

        private void btn_Evaluate_Click(object sender, EventArgs e)
        {
            string Faculty = this.dgv_StudentEvaluate.CurrentRow.Cells["教师"].Value.ToString();
            //传参数到另一个窗体
            frm_Evaluating frmContent = new frm_Evaluating(this._StudentNumber, this._Term,Faculty);
            //窗体加事件
            //frmContent.FormClosed += FrmContent_FormClosed;
            //另一个窗体打开
            frmContent.ShowDialog();
        }
        private void FrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.btn_Evaluate_Click(null, null);
        }

        private void btn_Complete_Click(object sender, EventArgs e)
        {
            string updateCommand = $@"update tb_StuEvaluate set Operate='已评教'where Term='{this._Term}'and StuNo='{this._StudentNumber}'";
            SqlHelper sqlHelper = new SqlHelper();
            int rowAffected = sqlHelper.QuickSubmit(updateCommand);
            MessageBox.Show
                          ($"提交{rowAffected}条数据",
                           "学生评教",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
            this.Close();
        }
    }
}
