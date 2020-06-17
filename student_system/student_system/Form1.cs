using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace student_system
{
    public partial class Form1 : Form
    {
        // 从app.config配置文件中读取connectionString字段的value
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("../../../../image/login.png");
        }
        // 增删改数据
        public static int ExecuteSql(String sql)
        {
            SqlConnection con = new SqlConnection(connectionString); // 创建一个数据库连接
            SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作
            //try
            //{
                con.Open();
                int rows = cmd.ExecuteNonQuery(); // rows接受sql执行后返回的行数
                return rows;

            //}
            //catch (SqlException e)
            //{
               // throw new Exception(e.Message); // 抛出异常
            //}
            //finally
            //{
            //}
        }
        private void login_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString); // 创建一个数据库连接
            if (s_radioButton.Checked)
            {
                string sql = "select * from student where sid='" + id.Text + "'" + "and spwd='" + pwd.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    String sid = reader["sid"].ToString();
                    String sname = reader["sname"].ToString();
                    String spwd = reader["spwd"].ToString();
                    String sdept = reader["sdept"].ToString();
                    int scredit = (int)reader["scredit"];
                    int sicredit = (int)reader["sicredit"];
                    String ssex = reader["ssex"].ToString();
                    int sage = (int)reader["sage"];
                    String sgrade = reader["sgrade"].ToString();
                    String stel = reader["stel"].ToString();
                    MessageBox.Show("登录成功！");
                    Form2 childrenForm = new Form2(sid, sname, spwd, sdept, scredit, sicredit, ssex, sage, sgrade, stel);
                    childrenForm.Owner = this;
                    childrenForm.Show();
                }
                else
                {
                    MessageBox.Show("登录失败，用户名或密码错误！");
                    return;
                }

                cmd.Dispose(); // sda处理，以便空间回收
                con.Close(); // 连接关闭
                this.Hide();
            }
      
            else if(t_radioButton.Checked)
            {
                string sql = "select * from teacher where tid='" + id.Text + "'" + "and tpwd='" + pwd.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    String tid = reader["tid"].ToString();
                    String tname = reader["tname"].ToString();
                    String tpwd = reader["tpwd"].ToString();
                    String tdept = reader["tdept"].ToString();
                    String tsex = reader["tsex"].ToString();
                    int tage = (int)reader["tage"];
                    String ttel = reader["ttel"].ToString();
                    MessageBox.Show("登录成功！");
                    Form3 childrenForm = new Form3(tid,tname,tpwd,tdept,tsex,tage,ttel);
                    childrenForm.Owner = this;
                    childrenForm.Show();
                }
                else
                {
                    MessageBox.Show("登录失败，用户名或密码错误！");
                    return;
                }
                cmd.Dispose(); // sda处理，以便空间回收
                con.Close(); // 连接关闭
                this.Hide();
            }
            else if(a_radioButton.Checked)
            {
                string sql = "select * from manager where mid='" + id.Text + "'" + "and mpwd='" + pwd.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        String mid = reader["mid"].ToString();
                        String mname = reader["mname"].ToString();
                        String mpwd = reader["mpwd"].ToString(); 
                        String mdept = reader["mdept"].ToString();
                        MessageBox.Show("登录成功！");
                        Form4 childrenForm = new Form4(mid,mname,mpwd,mdept);
                        childrenForm.Owner = this;
                        childrenForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("登录失败，用户名或密码错误！");
                    return;
                    }
                    cmd.Dispose(); // sda处理，以便空间回收
                    con.Close(); // 连接关闭
                this.Hide();
            }
            else
            {
                MessageBox.Show("请选择用户身份类型！");
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void pwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void outbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
