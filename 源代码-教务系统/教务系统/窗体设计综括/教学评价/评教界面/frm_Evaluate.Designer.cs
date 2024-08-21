namespace 教务系统.窗体设计综括.教学评价.评教界面
{
    partial class frm_Evaluate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Evaluate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Evaluate = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.lbl_Term = new System.Windows.Forms.Label();
            this.dgv_StudentEvaluate = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.我的桌面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学籍成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.培养管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考试服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实践环节ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.教学体验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Complete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StudentEvaluate)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-59, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(493, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox5.Location = new System.Drawing.Point(-244, 57);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1181, 41);
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.btn_Complete);
            this.panel1.Controls.Add(this.btn_Evaluate);
            this.panel1.Controls.Add(this.btn_open);
            this.panel1.Controls.Add(this.lbl_Term);
            this.panel1.Controls.Add(this.dgv_StudentEvaluate);
            this.panel1.Location = new System.Drawing.Point(1, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 477);
            this.panel1.TabIndex = 17;
            // 
            // btn_Evaluate
            // 
            this.btn_Evaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Evaluate.BackColor = System.Drawing.Color.Bisque;
            this.btn_Evaluate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Evaluate.Location = new System.Drawing.Point(600, 72);
            this.btn_Evaluate.Name = "btn_Evaluate";
            this.btn_Evaluate.Size = new System.Drawing.Size(91, 39);
            this.btn_Evaluate.TabIndex = 31;
            this.btn_Evaluate.Text = "评教";
            this.btn_Evaluate.UseVisualStyleBackColor = false;
            this.btn_Evaluate.Visible = false;
            this.btn_Evaluate.Click += new System.EventHandler(this.btn_Evaluate_Click);
            // 
            // btn_open
            // 
            this.btn_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_open.BackColor = System.Drawing.Color.Bisque;
            this.btn_open.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_open.Location = new System.Drawing.Point(581, 72);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(91, 39);
            this.btn_open.TabIndex = 30;
            this.btn_open.Text = "查看";
            this.btn_open.UseVisualStyleBackColor = false;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // lbl_Term
            // 
            this.lbl_Term.AutoSize = true;
            this.lbl_Term.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Term.Location = new System.Drawing.Point(220, 22);
            this.lbl_Term.Name = "lbl_Term";
            this.lbl_Term.Size = new System.Drawing.Size(110, 31);
            this.lbl_Term.TabIndex = 20;
            this.lbl_Term.Text = "学生评教";
            // 
            // dgv_StudentEvaluate
            // 
            this.dgv_StudentEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_StudentEvaluate.BackgroundColor = System.Drawing.Color.Pink;
            this.dgv_StudentEvaluate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StudentEvaluate.Location = new System.Drawing.Point(11, 72);
            this.dgv_StudentEvaluate.Name = "dgv_StudentEvaluate";
            this.dgv_StudentEvaluate.RowHeadersWidth = 62;
            this.dgv_StudentEvaluate.RowTemplate.Height = 30;
            this.dgv_StudentEvaluate.Size = new System.Drawing.Size(543, 397);
            this.dgv_StudentEvaluate.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我的桌面ToolStripMenuItem,
            this.学籍成绩ToolStripMenuItem,
            this.培养管理ToolStripMenuItem,
            this.考试服务ToolStripMenuItem,
            this.实践环节ToolStripMenuItem,
            this.教学体验ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 57);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(596, 32);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 我的桌面ToolStripMenuItem
            // 
            this.我的桌面ToolStripMenuItem.Name = "我的桌面ToolStripMenuItem";
            this.我的桌面ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.我的桌面ToolStripMenuItem.Text = "我的桌面";
            // 
            // 学籍成绩ToolStripMenuItem
            // 
            this.学籍成绩ToolStripMenuItem.Name = "学籍成绩ToolStripMenuItem";
            this.学籍成绩ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.学籍成绩ToolStripMenuItem.Text = "学籍成绩";
            // 
            // 培养管理ToolStripMenuItem
            // 
            this.培养管理ToolStripMenuItem.Name = "培养管理ToolStripMenuItem";
            this.培养管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.培养管理ToolStripMenuItem.Text = "培养管理";
            // 
            // 考试服务ToolStripMenuItem
            // 
            this.考试服务ToolStripMenuItem.Name = "考试服务ToolStripMenuItem";
            this.考试服务ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.考试服务ToolStripMenuItem.Text = "考试服务";
            // 
            // 实践环节ToolStripMenuItem
            // 
            this.实践环节ToolStripMenuItem.Name = "实践环节ToolStripMenuItem";
            this.实践环节ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.实践环节ToolStripMenuItem.Text = "实践环节";
            // 
            // 教学体验ToolStripMenuItem
            // 
            this.教学体验ToolStripMenuItem.Name = "教学体验ToolStripMenuItem";
            this.教学体验ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.教学体验ToolStripMenuItem.Text = "教学体验";
            // 
            // btn_Complete
            // 
            this.btn_Complete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Complete.BackColor = System.Drawing.Color.MistyRose;
            this.btn_Complete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Complete.Location = new System.Drawing.Point(581, 134);
            this.btn_Complete.Name = "btn_Complete";
            this.btn_Complete.Size = new System.Drawing.Size(110, 47);
            this.btn_Complete.TabIndex = 32;
            this.btn_Complete.Text = "完成评教";
            this.btn_Complete.UseVisualStyleBackColor = false;
            this.btn_Complete.Visible = false;
            this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
            // 
            // frm_Evaluate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(704, 585);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Evaluate";
            this.Text = "学生评教";
            this.Load += new System.EventHandler(this.frm_Evaluate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StudentEvaluate)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 我的桌面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学籍成绩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 培养管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考试服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实践环节ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 教学体验ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_StudentEvaluate;
        private System.Windows.Forms.Label lbl_Term;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_Evaluate;
        private System.Windows.Forms.Button btn_Complete;
    }
}