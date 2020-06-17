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
    public partial class Form4 : Form
    {
        static string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
        string id;
        string name;
        string pwd;
        string dept;
        public Form4(string mid,string mname,string mpwd,string mdept)
        {
            InitializeComponent();
            id = mid;
            name = mname;
            pwd = mpwd;
            dept = mdept;
            label7.Text = name;
            label8.Text = id;
            label10.Text = dept;
            this.mname.Text = name;
            this.mdept.Text = dept;
            this.mid.Text = id;
            if(id=="000")
            {
                this.mname.ReadOnly = false;
                this.mid.ReadOnly = false;
                this.mdept.ReadOnly = false;
                groupBox2.Text = "修改其他管理员信息";
            }
            else
            {
                this.mname.ReadOnly = false;
                this.mdept.ReadOnly = true;
                this.mid.ReadOnly = true;
                this.mdept.BackColor = Color.LightGray;
                this.mid.BackColor = Color.LightGray;
                groupBox2.Text = "修改个人信息";
            }
            textBox1.Text = pwd;
            comboBox1.Items.Add("专业必修");//添加选择项
            comboBox1.Items.Add("专业选修");
            comboBox1.Items.Add("通识教育");
            comboBox1.Items.Add("公共基础");
            comboBox2.Items.Add("男");
            comboBox2.Items.Add("女");
            comboBox3.Items.Add("男");
            comboBox3.Items.Add("女");
            comboBox4.Items.Add("审核中");
            comboBox4.Items.Add("完成");
            comboBox4.Items.Add("未通过");
            comboBox4.Items.Add("全部");
            textBox12.Text = dept;
            textBox17.Text = dept;
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
        private void changepwd_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(id, pwd, 3);
            form5.Owner = this;
            form5.Show();
            this.Hide();
        }

        private void changeinfo_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(id, name, dept);
            form7.Owner = this;
            form7.Show();
            this.Hide();
        }

        private void outbutton_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mname = this.mname.Text.Trim();
            string mdept = this.mdept.Text.Trim();
            string mid = this.mid.Text.Trim();
            if(id=="000")
            {
                if (mid == "000")
                {
                    label7.Text = mname;
                    label10.Text = mdept;
                }
            }
            else
            {
                label7.Text = mname;
            }
            string sql = "update manager set mname='" + mname + "',mdept='" + mdept + "'where mid='" + mid + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
        }

        private void button2_Click(object sender, EventArgs e)
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
            string sql = "update manager set mpwd='" + newpwd + "'" + "where mid='" + id + "'";
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
            this.Owner.Show();
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        //查询课程
        private void button3_Click(object sender, EventArgs e)
        {
            string cid = textBox4.Text;
            string cname = textBox5.Text;
            string tid = textBox6.Text;
            string ccredit = textBox7.Text;
            string cmax = textBox8.Text;
            string ckind = comboBox1.Text;
            string search_course;
            if(dept=="全部系")
            {
                search_course = string.Format(@"select cid 课程编号,cname 课程名称, course.tid 教工号, teacher.tname 教师姓名, ccredit 课程学分,ckind 课程类别, cmax 课程最大人数,cnum 课程已选人数
                                        from course,teacher where cid like '%{0}%' and cname like '%{1}%' and course.tid like '%{2}%' 
                                        and ccredit like '%{3}%' and ckind like '%{4}%' and cmax like '%{5}%' and course.tid=teacher.tid 
                                        ", cid, cname, tid, ccredit, ckind, cmax);
            }
            else
            {
                search_course = string.Format(@"select cid 课程编号,cname 课程名称, course.tid 教工号, teacher.tname 教师姓名, ccredit 课程学分,ckind 课程类别, cmax 课程最大人数,cnum 课程已选人数
                                        from course,teacher where cid like '%{0}%' and cname like '%{1}%' and course.tid like '%{2}%' 
                                        and ccredit like '%{3}%' and ckind like '%{4}%' and cmax like '%{5}%' and course.tid=teacher.tid 
                                        and teacher.tdept='{6}'", cid, cname, tid, ccredit, ckind, cmax, dept);
            }
            this.course_list.DataSource = Query(search_course).Tables["list"];
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            comboBox1.Text = null;
        }
        //添加课程
        private void button4_Click(object sender, EventArgs e)
        {
            string cid = textBox4.Text;
            string cname = textBox5.Text;
            string tid = textBox6.Text;
            string ccredit = textBox7.Text;
            string cmax = textBox8.Text;
            string ckind = comboBox1.Text;
            string sql = string.Format(@"insert into course values('{0}','{1}','{2}',{3},'{4}',{5},0)",cid,cname,tid,ccredit,ckind,int.Parse(cmax));
            Form1.ExecuteSql(sql);
            MessageBox.Show("添加成功！");
        }
        //删除课程
        private void button5_Click(object sender, EventArgs e)
        {
            int a = course_list.CurrentRow.Index;
            string cid = course_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sql1 = string.Format(@"update student set scredit=scredit-course.ccredit from student,choice,course
                                       where student.sid=choice.sid and choice.cid=course.cid and choice.grade>=60 
                                       and choice.cid='{0}'", cid);
            string sql2 = string.Format("delete from course where cid='{0}'",cid);
            Form1.ExecuteSql(sql1);
            Form1.ExecuteSql(sql2);
            MessageBox.Show("删除成功！");
        }
        //修改课程
        private void course_list_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int a = course_list.CurrentRow.Index; // 获取当前选中行
            string cid = course_list.Rows[a].Cells[0].Value.ToString().Trim();
            string cname = course_list.Rows[a].Cells[1].Value.ToString().Trim();
            string tid = course_list.Rows[a].Cells[2].Value.ToString().Trim();
            string tname = course_list.Rows[a].Cells[3].Value.ToString().Trim();
            string ccredit = course_list.Rows[a].Cells[4].Value.ToString().Trim();
            string ckind = course_list.Rows[a].Cells[5].Value.ToString().Trim();
            string cmax = course_list.Rows[a].Cells[6].Value.ToString().Trim();
            string cnum = course_list.Rows[a].Cells[7].Value.ToString().Trim();
            string sql = string.Format("update course set cname='{0}',tid='{1}',ccredit={2},ckind='{3}',cmax={4},cnum={5} where cid='{6}'",cname,tid,ccredit,ckind,cmax,cnum,cid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox13.Text = null;
            comboBox2.Text = null;
        }
        // 查询老师
        private void button6_Click(object sender, EventArgs e)
        {
            string tid = textBox13.Text;
            string tname = textBox11.Text;
            string tsex = comboBox2.Text;
            string tage = textBox10.Text;
            string ttel = textBox9.Text;
            string search_teacher;
            if(dept=="全部系")
            {
                search_teacher = string.Format(@"select tid 教工号,tname 姓名, tdept 系别, tsex 性别,tage 年龄, ttel 联系方式 
                                        from teacher where tid like '%{0}%' and tname like '%{1}%'  
                                        and tsex like '%{2}%' and tage like '%{3}%' and ttel like '%{4}%' 
                                        ", tid, tname, tsex, tage, ttel);
            }
            else
            {
                search_teacher = string.Format(@"select tid 教工号,tname 姓名, tdept 系别, tsex 性别,tage 年龄, ttel 联系方式 
                                        from teacher where tid like '%{0}%' and tname like '%{1}%'  
                                        and tsex like '%{2}%' and tage like '%{3}%' and ttel like '%{4}%' and teacher.tdept='{5}'
                                        ", tid, tname, tsex, tage, ttel, dept);
            }
            
            this.teacher_list.DataSource = Query(search_teacher).Tables["list"];
        }
        //添加老师
        private void button7_Click(object sender, EventArgs e)
        {
            string tid = textBox13.Text;
            string tname = textBox11.Text;
            string tsex = comboBox2.Text;
            string tage = textBox10.Text;
            string ttel = textBox9.Text;
            string sql = string.Format(@"insert into teacher values('{0}','{1}','123456','{2}','{3}',{4},'{5}')", tid, tname, dept, tsex, int.Parse(tage), ttel);
            Form1.ExecuteSql(sql);
            MessageBox.Show("添加成功！");
        }
        //删除老师
        private void button8_Click(object sender, EventArgs e)
        {
            int a = teacher_list.CurrentRow.Index;
            string tid = teacher_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sql = string.Format("delete from teacher where tid='{0}'", tid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("删除成功！");
        }
        //修改老师信息
        private void teacher_list_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int a = teacher_list.CurrentRow.Index; // 获取当前选中行
            string tid = teacher_list.Rows[a].Cells[0].Value.ToString().Trim();
            string tname = teacher_list.Rows[a].Cells[1].Value.ToString().Trim();
            string tdept = teacher_list.Rows[a].Cells[2].Value.ToString().Trim();
            string tsex = teacher_list.Rows[a].Cells[3].Value.ToString().Trim();
            string tage = teacher_list.Rows[a].Cells[4].Value.ToString().Trim();
            string ttel = teacher_list.Rows[a].Cells[5].Value.ToString().Trim();
            string sql = string.Format(@"update teacher set tname='{0}',tdept='{1}',tsex='{2}',tage={3},ttel='{4}' where tid='{5}'", tname, tdept, tsex, int.Parse(tage), ttel, tid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
        }
        //查询学生
        private void button9_Click(object sender, EventArgs e)
        {
            string sid = textBox18.Text;
            string sname = textBox16.Text;
            string ssex = comboBox3.Text;
            string sage = textBox15.Text;
            string stel = textBox14.Text;
            string sgrade = textBox19.Text;
            string search_student;
            if (dept=="全部系")
            {
                search_student = string.Format(@"select sid 学号,sname 姓名, sdept 系别, scredit 已修课程学分,sicredit 已修创新学分, ssex 性别,
                                        sage 年龄,sgrade 年级, stel 联系方式 from student where sid like '%{0}%' and sname like '%{1}%'  
                                        and ssex like '%{2}%' and sage like '%{3}%' and sgrade like '%{4}%' and stel like '%{5}%' 
                                        ", sid, sname, ssex, sage, sgrade, stel);
            }
            else
            {
                search_student = string.Format(@"select sid 学号,sname 姓名, sdept 系别, scredit 已修课程学分,sicredit 已修创新学分, ssex 性别,
                                        sage 年龄,sgrade 年级, stel 联系方式 from student where sid like '%{0}%' and sname like '%{1}%'  
                                        and ssex like '%{2}%' and sage like '%{3}%' and sgrade like '%{4}%' and stel like '%{5}%' and student.sdept='{6}'
                                        ", sid, sname, ssex, sage, sgrade, stel,dept);
            }
            
            this.student_list.DataSource = Query(search_student).Tables["list"];

            SqlConnection con = new SqlConnection(connectionString);//创建数据库连接
            string sql;
            if(dept=="全部系")
            {
                sql = string.Format(@"select scredit,sicredit from student where sid like '%{0}%' and sname like '%{1}%'  
                                        and ssex like '%{2}%' and sage like '%{3}%' and sgrade like '%{4}%' and stel like '%{5}%' 
                                        ", sid, sname, ssex, sage, sgrade, stel);
            }
            else
            {
                sql = string.Format(@"select scredit,sicredit from student where sid like '%{0}%' and sname like '%{1}%'  
                                        and ssex like '%{2}%' and sage like '%{3}%' and sgrade like '%{4}%' and stel like '%{5}%' and student.sdept = '{6}'
                                        ", sid, sname, ssex, sage, sgrade, stel, dept);
            }
            SqlCommand cmd = new SqlCommand(sql, con); // 创建一个SqlCommand，用于对数据库进行操作

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string credit = reader["scredit"].ToString();
                string icredit = reader["sicredit"].ToString();
                label36.Text = credit;
                label37.Text = icredit;
            }
            cmd.Dispose(); // sda处理，以便空间回收
            con.Close(); // 连接关闭
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox14.Text = null;
            textBox15.Text = null;
            textBox16.Text = null;
            textBox18.Text = null;
            textBox19.Text = null;
            comboBox3.Text = null;
            label36.Text = null;
            label37.Text = null;
        }
        //添加学生
        private void button11_Click(object sender, EventArgs e)
        {
            string sid = textBox18.Text;
            string sname = textBox16.Text;
            string ssex = comboBox3.Text;
            string sage = textBox15.Text;
            string stel = textBox14.Text;
            string sgrade = textBox19.Text;
            string sql = string.Format(@"insert into student values('{0}','{1}','123456','{2}',0,0,'{3}',{4},'{5}','{6}')", sid, sname, dept, ssex, int.Parse(sage), sgrade,stel);
            Form1.ExecuteSql(sql);
            MessageBox.Show("添加成功！");
        }
        //删除学生
        private void button12_Click(object sender, EventArgs e)
        {
            int a = student_list.CurrentRow.Index;
            string sid = student_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sql1 = string.Format(@"update course set cnum=cnum-1 from choice,student where student.sid=choice.sid and choice.cid=course.cid and choice.sid='{0}'",sid);
            string sql2 = string.Format("delete from student where sid='{0}'", sid);
            Form1.ExecuteSql(sql1);
            Form1.ExecuteSql(sql2);
            MessageBox.Show("删除成功！");
        }
        //修改学生
        private void student_list_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int a = student_list.CurrentRow.Index; // 获取当前选中行
            string sid = student_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sname = student_list.Rows[a].Cells[1].Value.ToString().Trim();
            string sdept = student_list.Rows[a].Cells[2].Value.ToString().Trim();
            string scredit = student_list.Rows[a].Cells[3].Value.ToString().Trim();
            string sicredit = student_list.Rows[a].Cells[4].Value.ToString().Trim();
            string ssex = student_list.Rows[a].Cells[5].Value.ToString().Trim();
            string sage = student_list.Rows[a].Cells[6].Value.ToString().Trim();
            string sgrade = student_list.Rows[a].Cells[7].Value.ToString().Trim();
            string stel = student_list.Rows[a].Cells[8].Value.ToString().Trim();
            string sql = string.Format(@"update student set sname='{0}',sdept='{1}',scredit={2},sicredit={3},ssex='{4}',sage={5},sgrade='{6}',stel='{7}' where sid='{8}'", sname, sdept, int.Parse(scredit),int.Parse(sicredit),ssex, int.Parse(sage), sgrade,stel,sid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("修改成功！");
        }
        //查询学生成绩
        private void button15_Click(object sender, EventArgs e)
        {
            int a = student_list.CurrentRow.Index;
            string sid = student_list.Rows[a].Cells[0].Value.ToString().Trim();
            string sname = student_list.Rows[a].Cells[1].Value.ToString().Trim();
            string sdept = student_list.Rows[a].Cells[2].Value.ToString().Trim();
            string scredit = student_list.Rows[a].Cells[3].Value.ToString().Trim();
            string sicredit = student_list.Rows[a].Cells[4].Value.ToString().Trim();
            string ssex = student_list.Rows[a].Cells[5].Value.ToString().Trim();
            string sage = student_list.Rows[a].Cells[6].Value.ToString().Trim();
            string sgrade = student_list.Rows[a].Cells[7].Value.ToString().Trim();
            string stel = student_list.Rows[a].Cells[8].Value.ToString().Trim();
            Form10 form10 = new Form10(sid);
            form10.Owner = this;
            form10.Show();
        }

        private void report_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = report_list.CurrentRow.Index;
            string show_project;
            string pid = report_list.Rows[a].Cells[4].Value.ToString().Trim();
            show_project = string.Format(@"select pid 项目编号,pkind 项目类型, pname 项目名称, teacher.tid 指导老师教工号, tname 指导老师
                                          from project,teacher where pid='{0}' and project.tid=teacher.tid ",pid);
            this.project_list.DataSource = Query(show_project).Tables["list"];
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int a = report_list.CurrentRow.Index;
            string pid = report_list.Rows[a].Cells[4].Value.ToString().Trim();
            string sql = string.Format("update report set rstatus='完成' where pid='{0}'",pid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("审批完成！");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int a = report_list.CurrentRow.Index;
            string pid = report_list.Rows[a].Cells[4].Value.ToString().Trim();
            string sql = string.Format("update report set rstatus='未通过' where pid='{0}'",pid);
            Form1.ExecuteSql(sql);
            MessageBox.Show("审批完成！");
        }
        //查看项目申报记录
        private void button18_Click(object sender, EventArgs e)
        {
            string rstatus = comboBox4.Text;
            string search_project;
            if (dept == "全部系")
            {
                search_project = string.Format(@"select student.sid 学号,sname 姓名, sdept 系别, sgrade 年级,pid 项目编号,rstatus 申报状态, rcredit 申请学分
                                        from student,report where rstatus= '{0}' and student.sid=report.sid", rstatus);
            }
            else
            {
                search_project = string.Format(@"select student.sid 学号,sname 姓名, sdept 系别, sgrade 年级,pid 项目编号,rstatus 申报状态, rcredit 申请学分
                                        from student,report where rstatus= '{0}' and student.sdept = '{1}' and student.sid=report.sid", rstatus, dept);
            }
            this.report_list.DataSource = Query(search_project).Tables["list"];
        }
    }
}
