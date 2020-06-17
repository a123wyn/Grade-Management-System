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
using System.Configuration;

namespace student_system
{
    public partial class Form2 : Form
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
        String pid;
        String pkind;
        String pname;
        String rstatus;
        int rcredit;
        String tid;

        public Form2(string sid, string sname, string spwd, string sdept, int scredit, int sicredit, string ssex, int sage, string sgrade, string stel)
        {
            InitializeComponent();
            id = sid;
            name = sname;
            pwd = spwd;
            dept = sdept;
            credit = scredit;
            icredit = sicredit;
            sex = ssex;
            age = sage;
            grade = sgrade;
            tel = stel;
            label7.Text = name;
            label8.Text = sex;
            label9.Text = grade;
            label10.Text = dept;
            label11.Text = id;
            label12.Text = tel;
            label16.Text = age.ToString();
            label21.Text = credit.ToString();
            label19.Text = icredit.ToString();
            My_Conbobox();
            changeImage();
            get_icredit();
            Project_combobox();
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
            string sid = label11.Text.Trim();
            string sql = "select season from choice where sid = '" + sid +"'" ;
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

        private void Project_combobox()
        {
            comboBox2.Items.Add("学术竞赛");
            comboBox2.Items.Add("大创项目");
            comboBox2.Items.Add("社会实践");
            comboBox2.Items.Add("志愿服务");
            comboBox2.Items.Add("文体活动");

            
        }

        public void changeImage()
        {
            if(sex=="女")
                pictureBox1.Image = Image.FromFile("../../../../image/woman.png");
            else
                pictureBox1.Image = Image.FromFile("../../../../image/man.png");
        }

        private void changepwd_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(id, pwd, 1);
            form5.Owner = this;
            form5.Show();
            this.Hide();
        }


        private void outbutton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void get_icredit()
        {
            string search_icredit;
            search_icredit = "select project.pid 项目编号, pname 项目名称, pkind 项目类型, rstatus 申报状态, rcredit 认证学分, tname 指导老师 from report, project, teacher where report.sid = '" + id + "' and report.pid = project.pid and project.tid = teacher.tid";
            this.icredit_list.DataSource = Query(search_icredit).Tables["list"];
        }

        private void search_grade_Click(object sender, EventArgs e)
        {
            //string sid = label11.Text.Trim();
            string season = comboBox1.Text.Trim();
            string search_grade;
            if (season != "全部")
            {
                search_grade = "select season 学期, choice.cid 课程号, cname 课程名, grade 成绩, ckind 课程类型, tname 授课教师, ccredit 课程学分 from choice,course,teacher where choice.sid = '" + id + "' and season = '" + season + "'and choice.cid = course.cid and course.tid = teacher.tid";
            }

            else
                search_grade = "select season 学期, choice.cid 课程号, cname 课程名, grade 成绩, ckind 课程类型, tname 授课教师, ccredit 课程学分 from choice,course,teacher where choice.sid = '" + id + "'and choice.cid = course.cid and course.tid = teacher.tid";

            this.grade_list.DataSource = Query(search_grade).Tables["list"];
        }

        private void changeinfo_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String oldpwd = textBox1.Text.Trim();
            String newpwd = textBox2.Text.Trim();
            String newpwd1 = textBox3.Text.Trim();
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
            string sql = "update student set spwd='" + newpwd + "'" + "where sid='" + id + "'";
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
            name = sname.Text.Trim();
            sex = ssex.Text.Trim();
            grade = sgrade.Text.Trim();
            dept = sdept.Text.Trim();
            age = int.Parse(sage.Text.Trim());
            tel = stel.Text.Trim();
            label7.Text = name;
            label8.Text = sex;
            label9.Text = grade;
            label10.Text = dept;
            label12.Text = tel;
            label16.Text = age.ToString();
            string sql = "update student set sname='" + name + "',ssex='" + sex + "',sgrade='" + grade + "',sdept='" + dept + "',sage=" + age + ",stel='" + tel + "'where sid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            tabControl1.SelectedTab = tabPage1;

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            string type = comboBox2.Text.Trim();

            if (type == "学术竞赛")
            {
                textBox5.Text = "竞赛类型编号：";
                textBox6.Text = "竞赛名称：";
                textBox11.Text = "指导老师（教工号）：";
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;

            }
            if (type == "大创项目")
            {
                textBox5.Text = "项目编号：";
                textBox6.Text = "项目名称：";
                textBox11.Text = "指导老师（教工号）：";
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                
            }
            if (type == "社会实践")
            {
                textBox5.Text = "细分类型：";
                textBox6.Text = "队伍名称：";
                textBox11.Text = "带队老师（教工号）：";
                comboBox3.Items.Add("社会实践表彰");
                comboBox3.Items.Add("社会实践项目");
                comboBox3.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                
            }
            if (type == "志愿服务")
            {
                textBox5.Text = "表彰编号：";
                textBox6.Text = "表彰名称：";
                textBox11.Text = "指导老师（教工号）：";
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
               

            }
            if (type == "文体活动")
            {
                textBox5.Text = "获奖等级：";
                textBox6.Text = "活动名称：";
                textBox11.Text = "指导老师（教工号）：";
                comboBox4.Items.Add("一等奖");
                comboBox4.Items.Add("二等奖");
                comboBox4.Items.Add("三等奖");
                comboBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string type = comboBox2.Text.Trim();
            if (type == "学术竞赛" || type == "大创项目" || type == "志愿服务")
            {
                pid = textBox8.Text.Trim();
                pname = textBox9.Text.Trim();
                pkind = type;
                rcredit = int.Parse(textBox10.Text);
                rstatus = "审核中";
                tid = textBox12.Text.Trim();
            }
            else if (type == "文体活动")
            {
                pid = textBox14.Text.Trim();
                pname = textBox9.Text.Trim();
                pkind = type + comboBox4.Text.Trim();
                rcredit = int.Parse(textBox10.Text);
                rstatus = "审核中";
                tid = textBox12.Text.Trim();
            }
            else if (type == "社会实践" )
            {
                pid = textBox14.Text.Trim();
                pname = textBox9.Text.Trim();
                pkind = comboBox4.Text.Trim();
                rcredit = int.Parse(textBox10.Text);
                rstatus = "审核中";
                tid = textBox12.Text.Trim();
            }


            string sql1 = "insert into project values('" + pid + "','" + pkind + "','" + pname + "','" + tid + "')";
            string sql2 = "insert into report values('" + id + "','" + pid + "','" + rstatus + "'," + rcredit + ")";
            Form1.ExecuteSql(sql1);
            Form1.ExecuteSql(sql2);
            MessageBox.Show("申请提交成功！");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                textBox1.Text = pwd;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                sname.Text = name;
                ssex.Text = sex;
                sgrade.Text = grade;
                sdept.Text = dept;
                sage.Text = age.ToString();
                stel.Text = tel;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string search_project;
            search_project = "select distinct project.pid 项目编号, pname 项目名称, pkind 项目类型, rcredit 认证学分, rstatus 审核状态 from project,report,teacher where report.sid = '" + id + "'and report.pid = project.pid ";
            this.project_list.DataSource = Query(search_project).Tables["list"];
        }
    }
}
