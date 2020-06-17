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
    public partial class Form7 : Form
    {
        string id;
        public Form7(string iid,string name,string dept)
        {
            InitializeComponent();
            mname.Text = name;
            mdept.Text = dept;
            id = iid;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            string name = mname.Text.Trim();
            string dept = mdept.Text.Trim();
            string sql = "update manager set mname='" + name + "',mdept='" + dept + "'where mid='" + id + "'";
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
