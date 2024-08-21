namespace 教务系统.窗体设计综括.用户注册登录
{
    partial class frm_SearchPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SearchPassword));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_SearchPassw = new System.Windows.Forms.Button();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.txt_Birth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-14, -4);
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
            this.pictureBox5.Location = new System.Drawing.Point(-4, 52);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(617, 35);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.txt_Age);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_SearchPassw);
            this.panel1.Controls.Add(this.txt_No);
            this.panel1.Controls.Add(this.txt_Birth);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblNo);
            this.panel1.Location = new System.Drawing.Point(4, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 273);
            this.panel1.TabIndex = 5;
            // 
            // txt_Age
            // 
            this.txt_Age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Age.Location = new System.Drawing.Point(243, 162);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.Size = new System.Drawing.Size(223, 28);
            this.txt_Age.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(57, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 30;
            this.label1.Text = "密保2-年龄：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(470, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "*必须为学号";
            // 
            // btn_SearchPassw
            // 
            this.btn_SearchPassw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SearchPassw.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SearchPassw.Location = new System.Drawing.Point(240, 218);
            this.btn_SearchPassw.Name = "btn_SearchPassw";
            this.btn_SearchPassw.Size = new System.Drawing.Size(226, 39);
            this.btn_SearchPassw.TabIndex = 17;
            this.btn_SearchPassw.Text = "找回密码";
            this.btn_SearchPassw.UseVisualStyleBackColor = false;
            this.btn_SearchPassw.Click += new System.EventHandler(this.btn_SearchPassw_Click);
            // 
            // txt_No
            // 
            this.txt_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_No.Location = new System.Drawing.Point(243, 47);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(223, 28);
            this.txt_No.TabIndex = 7;
            // 
            // txt_Birth
            // 
            this.txt_Birth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Birth.Location = new System.Drawing.Point(243, 107);
            this.txt_Birth.Name = "txt_Birth";
            this.txt_Birth.Size = new System.Drawing.Size(223, 28);
            this.txt_Birth.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(57, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "密保1-籍贯：";
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
            // frm_SearchPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(614, 373);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_SearchPassword";
            this.Text = "找回密码";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_SearchPassw;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.TextBox txt_Birth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.TextBox txt_Age;
        private System.Windows.Forms.Label label1;
    }
}