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
    public partial class Form5 : Form
    {
        String id;
        int type;
        public Form5(String iid,String oldpwd,int ttype)
        {
            InitializeComponent();
            id = iid;
            type = ttype;
            originpwd.Text = oldpwd;
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            String oldpwd = originpwd.Text.Trim();
            String pwd = newpwd.Text.Trim();
            String pwd1 = confirmpwd.Text.Trim();
            if(type==1)
            {
                string sql = "update student set spwd='" + pwd + "'" + "where sid='" + id + "'";
                Form1.ExecuteSql(sql);
            }
            else if(type==2)
            {
                string sql = "update teacher set tpwd='" + pwd + "'" + "where tid='" + id + "'";
                Form1.ExecuteSql(sql);
            }
            else
            {
                string sql = "update manager set mpwd='" + pwd + "'" + "where mid='" + id + "'";
                Form1.ExecuteSql(sql);
            }
            this.Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
