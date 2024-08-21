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
    public partial class frm_Evaluating : Form
    {
        //窗体属性
        private string _StudentNumber;
        private string _Term;
        private string _Faculty;

        //构造函数
        public frm_Evaluating(string studentNumber, string term,string faculty) : this()
        {
            this._StudentNumber = studentNumber;
            this._Term = term;
            this._Faculty = faculty;
        }
        public frm_Evaluating()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void frm_Evaluating_Load(object sender, EventArgs e)
        {
            string commandText =
                $"select * from tb_StudentEvaluate WHERE StudentNo='{this._StudentNumber}'and Term='{this._Term}'and FacultyName='{this._Faculty}';";
            SqlHelper sqlHelper = new SqlHelper();
            sqlHelper.QuickRead(commandText);
            if (sqlHelper.HasRecord)
            {
                lblTerm.Text = sqlHelper["Term"].ToString();
                lbl_Faculty.Text = sqlHelper["FacultyName"].ToString();
                lbl_Course.Text = sqlHelper["Course"].ToString();
                lbl_Department.Text = sqlHelper["FacultyDepartment"].ToString();
                lbl_FacultyTitle.Text = sqlHelper["FacultyTitle"].ToString();
            }
        }

        private void btn_Evaluate_Click(object sender, EventArgs e)
        {
            int score = int.Parse(this.txt_Score.Text);
            string updateCommand =$@"update tb_StudentEvaluate
                                     set FacultyRate='{score}'
                                     where StudentNo='{this._StudentNumber}'and Term='{this._Term}'and FacultyName='{this._Faculty}'";
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
