using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace student_system
{
    public partial class Form10 : Form
    {
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        String id;
        String name;
        String pwd;
        String dept;
        int credit;
        int icredit;
        String sex;
        int age;
        String grade;
        String tel;
        public Form10(string sid)
        {
            InitializeComponent();
            id = sid;
            My_Conbobox();
        }
        public static DataSet Query(String sql)
        {

            SqlConnection con = new SqlConnection(connectionString);//创建数据库连接
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);//创建DataSet和sqlserver之间的桥接器 用于操作
            DataSet ds = new DataSet();//创建数据集
            try
            {
                con.Open();//打开连接
                sda.Fill(ds, "list");//往窗体里students表中填充数据集ds
                return ds;
            }
            finally
            {
                sda.Dispose();//sda处理，以便空间回收
                con.Close();//连接关闭

            }
        }
        public void My_Conbobox()
        {
            SqlConnection con = new SqlConnection(connectionString);//创建数据库连接
            string sql = "select season from choice where sid = '" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                string season = reader["season"].ToString();
                comboBox1.Items.Add(season);//添加选择项
            }
            comboBox1.Items.Add("全部");//添加选择项

            cmd.Dispose(); // sda处理，以便空间回收
            con.Close(); // 连接关闭
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string season = comboBox1.Text.Trim();
            string search_grade;
            if (season != "全部")
            {
                search_grade = "select season 学期, choice.cid 课程号, cname 课程名, grade 成绩, ckind 课程类型, tname 授课教师, ccredit 课程学分 from choice,course,teacher where choice.sid = '" + id + "' and season = '" + season + "'and choice.cid = course.cid and course.tid = teacher.tid";
            }

            else
                search_grade = "select season 学期, choice.cid 课程号, cname 课程名, grade 成绩, ckind 课程类型, tname 授课教师, ccredit 课程学分 from choice,course,teacher where choice.sid = '" + id + "'and choice.cid = course.cid and course.tid = teacher.tid";

            this.show.DataSource = Query(search_grade).Tables["list"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
