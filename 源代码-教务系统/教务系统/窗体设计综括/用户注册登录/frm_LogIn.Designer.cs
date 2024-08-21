namespace 教务系统.窗体设计综括.用户注册登录
{
    partial class frm_LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LogIn));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linlbl_SignUp = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.linkbtn_SearchPassword = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-25, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(404, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox5.Location = new System.Drawing.Point(-4, 57);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(566, 31);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.linkbtn_SearchPassword);
            this.panel1.Controls.Add(this.linlbl_SignUp);
            this.panel1.Controls.Add(this.btn_Login);
            this.panel1.Controls.Add(this.txt_No);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblNo);
            this.panel1.Location = new System.Drawing.Point(-4, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 249);
            this.panel1.TabIndex = 5;
            // 
            // linlbl_SignUp
            // 
            this.linlbl_SignUp.AutoSize = true;
            this.linlbl_SignUp.LinkColor = System.Drawing.Color.DarkGreen;
            this.linlbl_SignUp.Location = new System.Drawing.Point(491, 211);
            this.linlbl_SignUp.Name = "linlbl_SignUp";
            this.linlbl_SignUp.Size = new System.Drawing.Size(62, 18);
            this.linlbl_SignUp.TabIndex = 19;
            this.linlbl_SignUp.TabStop = true;
            this.linlbl_SignUp.Text = "去注册";
            this.linlbl_SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linlbl_SignUp_LinkClicked);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(243, 154);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(223, 39);
            this.btn_Login.TabIndex = 18;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_No
            // 
            this.txt_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_No.Location = new System.Drawing.Point(243, 47);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(223, 28);
            this.txt_No.TabIndex = 7;
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Location = new System.Drawing.Point(243, 107);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(223, 28);
            this.txt_Password.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(141, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "密码：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNo.Location = new System.Drawing.Point(113, 47);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(124, 28);
            this.lblNo.TabIndex = 7;
            this.lblNo.Text = "用户名：";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // linkbtn_SearchPassword
            // 
            this.linkbtn_SearchPassword.AutoSize = true;
            this.linkbtn_SearchPassword.LinkColor = System.Drawing.Color.SlateBlue;
            this.linkbtn_SearchPassword.Location = new System.Drawing.Point(405, 211);
            this.linkbtn_SearchPassword.Name = "linkbtn_SearchPassword";
            this.linkbtn_SearchPassword.Size = new System.Drawing.Size(80, 18);
            this.linkbtn_SearchPassword.TabIndex = 20;
            this.linkbtn_SearchPassword.TabStop = true;
            this.linkbtn_SearchPassword.Text = "忘记密码";
            // 
            // frm_LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(561, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_LogIn";
            this.Text = "登录";
            //this.Load += new System.EventHandler(this.frm_LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.LinkLabel linlbl_SignUp;
        private System.Windows.Forms.LinkLabel linkbtn_SearchPassword;
    }
}