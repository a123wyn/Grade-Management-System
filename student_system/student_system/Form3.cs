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
    public partial class Form3 : Form
    {
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        String id;
        String name;
        String pwd;
        String dept;
        String sex;
        int age;
        String tel;
        String season;
        public Form3(string tid, string tname, string tpwd, string tdept, string tsex, int tage, string ttel)
        {
            InitializeComponent();
            id = tid;
            name = tname;
            pwd = tpwd;
            dept = tdept;
            sex = tsex;
            age = tage;
            tel = ttel;
            label7.Text = name;
            label8.Text = dept;
            label10.Text = id;
            label11.Text = sex;
            label16.Text = age.ToString();
            label12.Text = tel;
            My_Conbobox();
            changeImage();
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
        /*  添加下拉列表的选项，年级选择列表 */
        public void My_Conbobox()
        {
            SqlConnection con = new SqlConnection(connectionString);//创建数据库连接
            string sql = "select distinct season from course,choice where course.tid = '" + id + "'and course.cid = choice.cid" ;
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
        public void changeImage()
        {
            if (sex == "女")
                pictureBox1.Image = Image.FromFile("../../../../image/woman.png");
            else
                pictureBox1.Image = Image.FromFile("../../../../image/man.png");
        }
        private void changepwd_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(id, pwd, 2);
            form5.Owner = this;
            form5.Show();
            this.Hide();
        }

        private void outbutton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void changeinfo_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(id,name,sex,dept,age,tel);
            form6.Owner = this;
            form6.Show();
            this.Hide();
        }

        private void course_search_Click(object sender, EventArgs e)
        {
            season = comboBox1.Text.Trim();
            string search_course;
            if (season != "全部")
            {
                search_course = "select course.cid 课程号, cname 课程名, ccredit 课程学分, ckind 课程类型, cnum 课程当前人数, cmax 课程人数上限 from choice,course where season = '" + season + "'and choice.cid = course.cid and course.tid ='" + id + "'";
            }

            else
                search_course = "select course.cid 课程号, cname 课程名, ccredit 课程学分, ckind 课程类型, cnum 课程当前人数, cmax 课程人数上限 from choice,course where choice.cid = course.cid and course.tid ='" + id + "'";

            this.course_list.DataSource = Query(search_course).Tables["list"];
        }

        private void course_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = course_list.CurrentRow.Index; // 获取当前选中行
            textBox1.Text = course_list.Rows[a].Cells[0].Value.ToString().Trim();
            textBox3.Text = season;
        }

        private void grade_search_Click(object sender, EventArgs e)
        {
            string search_grade;
            if (textBox2.Text != null)
            {
                search_grade = "select student.sid 学号, sname 姓名, choice.grade 成绩, sdept 系别, ssex 性别, sage 年龄, sgrade 年级 from choice,student where student.sid=choice.sid and choice.sid like '%" + textBox2.Text + "%' and choice.cid='" + textBox1.Text + "'and choice.season ='" + textBox3.Text + "'";
            }
            else
            {
                search_grade = "select student.sid 学号, sname 姓名, choice.grade 成绩, sdept 系别, ssex 性别, sage 年龄, sgrade 年级 from choice,student where student.sid=choice.sid and choice.cid='" + textBox1.Text + "'and choice.season ='" + textBox3.Text + "'";
            }
            this.grade_list.DataSource = Query(search_grade).Tables["list"];
        }

        private void grade_update_Click(object sender, EventArgs e)
        {
            int a = grade_list.CurrentRow.Index; // 获取当前选中行
            string sid = grade_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sgrade = grade_list.Rows[a].Cells[2].Value.ToString().Trim();
            Form9 form9 = new Form9(sid,sgrade,textBox1.Text,textBox3.Text);
            form9.Owner = this;
            form9.Show();
            this.Hide();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                textBox6.Text = pwd;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                tname.Text = name;
                tsex.Text = sex;
                tdept.Text = dept;
                tage.Text = age.ToString();
                ttel.Text = tel;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oldpwd = textBox6.Text.Trim();
            String newpwd = textBox5.Text.Trim();
            String newpwd1 = textBox4.Text.Trim();
            if (newpwd == oldpwd)
            {
                MessageBox.Show("新密码不可与旧密码一致！");
                return;
            }
            else if (newpwd != newpwd1)
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            string sql = "update teacher set tpwd='" + newpwd + "'" + "where tid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            this.Owner.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            name = tname.Text.Trim();
            sex = tsex.Text.Trim();
            dept = tdept.Text.Trim();
            age = int.Parse(tage.Text.Trim());
            tel = ttel.Text.Trim();
            label7.Text = name;
            label8.Text = dept;
            label11.Text = sex;
            label12.Text = tel;
            label16.Text = age.ToString();
            string sql = "update teacher set tname='" + name + "',tsex='" + sex + "',tdept='" + dept + "',tage=" + age + ",ttel='" + tel + "'where tid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            tabControl1.SelectedTab = tabPage1;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void grade_list_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int a = grade_list.CurrentRow.Index; // 获取当前选中行
            string sid = grade_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sgrade = grade_list.Rows[a].Cells[2].Value.ToString().Trim();
            string sql = "update choice set grade=" + int.Parse(sgrade) + "where cid='" + textBox1.Text + "'and season='" + textBox3.Text + "'and sid='" + sid + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
        }
    }
}
