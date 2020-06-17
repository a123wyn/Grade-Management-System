namespace student_system
{
    partial class Form6
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.okbutton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.tname = new System.Windows.Forms.TextBox();
            this.tsex = new System.Windows.Forms.TextBox();
            this.tdept = new System.Windows.Forms.TextBox();
            this.tage = new System.Windows.Forms.TextBox();
            this.ttel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(100, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(100, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "性别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(100, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "系别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(100, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "年龄：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(100, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "联系方式：";
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(103, 287);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(85, 30);
            this.okbutton.TabIndex = 5;
            this.okbutton.Text = "确认";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(273, 287);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(85, 30);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // tname
            // 
            this.tname.Location = new System.Drawing.Point(183, 68);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(131, 21);
            this.tname.TabIndex = 7;
            // 
            // tsex
            // 
            this.tsex.Location = new System.Drawing.Point(183, 104);
            this.tsex.Name = "tsex";
            this.tsex.Size = new System.Drawing.Size(131, 21);
            this.tsex.TabIndex = 8;
            // 
            // tdept
            // 
            this.tdept.Location = new System.Drawing.Point(183, 138);
            this.tdept.Name = "tdept";
            this.tdept.Size = new System.Drawing.Size(131, 21);
            this.tdept.TabIndex = 9;
            // 
            // tage
            // 
            this.tage.Location = new System.Drawing.Point(184, 173);
            this.tage.Name = "tage";
            this.tage.Size = new System.Drawing.Size(130, 21);
            this.tage.TabIndex = 10;
            // 
            // ttel
            // 
            this.ttel.Location = new System.Drawing.Point(183, 207);
            this.ttel.Name = "ttel";
            this.ttel.Size = new System.Drawing.Size(131, 21);
            this.ttel.TabIndex = 11;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 375);
            this.Controls.Add(this.ttel);
            this.Controls.Add(this.tage);
            this.Controls.Add(this.tdept);
            this.Controls.Add(this.tsex);
            this.Controls.Add(this.tname);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            this.Text = "教师修改个人信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox tname;
        private System.Windows.Forms.TextBox tsex;
        private System.Windows.Forms.TextBox tdept;
        private System.Windows.Forms.TextBox tage;
        private System.Windows.Forms.TextBox ttel;
    }
}