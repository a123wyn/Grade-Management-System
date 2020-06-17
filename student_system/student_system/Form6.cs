using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_system
{
    public partial class Form6 : Form
    {
        String id; 
        public Form6(string iid,string name,string sex,string dept,int age,string tel)
        {
            InitializeComponent();
            tname.Text = name;
            tsex.Text = sex;
            tdept.Text = dept;
            tage.Text = age.ToString();
            ttel.Text = tel;
            id = iid;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            string name = tname.Text.Trim();
            string sex = tsex.Text.Trim();
            string dept = tdept.Text.Trim();
            int age = int.Parse(tage.Text.Trim());
            string tel = ttel.Text.Trim();
            string sql = "update teacher set tname='" + name + "',tsex='" + sex + "',tdept='" + dept + "',tage=" + age + ",ttel='" + tel + "'where tid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            this.Owner.Show();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
