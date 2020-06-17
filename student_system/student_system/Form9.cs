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
    public partial class Form9 : Form
    {
        string id;
        string ccid;
        string s;
        public Form9(string sid,string sgrade,string cid,string season)
        {
            InitializeComponent();
            textBox1.Text = sgrade;
            id = sid;
            s = season;
            ccid = cid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update choice set grade=" + int.Parse(textBox2.Text) + "where cid='" + ccid + "'and season='" + s + "'and sid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            this.Owner.Show();
            this.Close();
        }
    }
}
