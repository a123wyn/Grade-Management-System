namespace student_system
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outbutton = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.a_radioButton = new System.Windows.Forms.RadioButton();
            this.s_radioButton = new System.Windows.Forms.RadioButton();
            this.t_radioButton = new System.Windows.Forms.RadioButton();
            this.pwd = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 85);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(684, 329);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outbutton);
            this.groupBox1.Controls.Add(this.login_button);
            this.groupBox1.Controls.Add(this.a_radioButton);
            this.groupBox1.Controls.Add(this.s_radioButton);
            this.groupBox1.Controls.Add(this.t_radioButton);
            this.groupBox1.Controls.Add(this.pwd);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(708, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(343, 355);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户登录";
            // 
            // outbutton
            // 
            this.outbutton.Location = new System.Drawing.Point(203, 300);
            this.outbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outbutton.Name = "outbutton";
            this.outbutton.Size = new System.Drawing.Size(100, 29);
            this.outbutton.TabIndex = 8;
            this.outbutton.Text = "退出";
            this.outbutton.UseVisualStyleBackColor = true;
            this.outbutton.Click += new System.EventHandler(this.outbutton_Click);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(48, 300);
            this.login_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(100, 29);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "登录";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // a_radioButton
            // 
            this.a_radioButton.AutoSize = true;
            this.a_radioButton.Location = new System.Drawing.Point(224, 239);
            this.a_radioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.a_radioButton.Name = "a_radioButton";
            this.a_radioButton.Size = new System.Drawing.Size(73, 19);
            this.a_radioButton.TabIndex = 6;
            this.a_radioButton.TabStop = true;
            this.a_radioButton.Text = "管理员";
            this.a_radioButton.UseVisualStyleBackColor = true;
            // 
            // s_radioButton
            // 
            this.s_radioButton.AutoSize = true;
            this.s_radioButton.Location = new System.Drawing.Point(131, 239);
            this.s_radioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.s_radioButton.Name = "s_radioButton";
            this.s_radioButton.Size = new System.Drawing.Size(58, 19);
            this.s_radioButton.TabIndex = 5;
            this.s_radioButton.TabStop = true;
            this.s_radioButton.Text = "学生";
            this.s_radioButton.UseVisualStyleBackColor = true;
            // 
            // t_radioButton
            // 
            this.t_radioButton.AutoSize = true;
            this.t_radioButton.Location = new System.Drawing.Point(36, 239);
            this.t_radioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.t_radioButton.Name = "t_radioButton";
            this.t_radioButton.Size = new System.Drawing.Size(58, 19);
            this.t_radioButton.TabIndex = 4;
            this.t_radioButton.TabStop = true;
            this.t_radioButton.Text = "教师";
            this.t_radioButton.UseVisualStyleBackColor = true;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(107, 160);
            this.pwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwd.Name = "pwd";
            this.pwd.PasswordChar = '*';
            this.pwd.Size = new System.Drawing.Size(195, 25);
            this.pwd.TabIndex = 3;
            this.pwd.TextChanged += new System.EventHandler(this.pwd_TextChanged);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(107, 101);
            this.id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(195, 25);
            this.id.TabIndex = 2;
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "登录界面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.RadioButton a_radioButton;
        private System.Windows.Forms.RadioButton s_radioButton;
        private System.Windows.Forms.RadioButton t_radioButton;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button outbutton;
    }
}

