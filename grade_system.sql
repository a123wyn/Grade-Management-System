create database grade_system

create table manager
(
mid varchar(20) primary key,
mname varchar(40),
mpwd varchar(20),
mdept varchar(20)
)
insert into manager values('000','超级管理员','123456','全部系')
insert into manager values('001','计算机科学系管理员','123456','计算机科学系')
insert into manager values('002','智能科学与技术系管理员','123456','智能科学与技术系')
insert into manager values('003','体育系管理员','123456','体育系')
insert into manager values('004','中文系管理员','123456','中文系')
select * from manager

create table student
(
sid varchar(20) primary key,
sname varchar(20),
spwd varchar(20),
sdept varchar(20),
scredit int,
sicredit int,
ssex varchar(5),
sage int,
sgrade varchar(10),
stel varchar(20)
)
insert into student values('22920172204226','王雅南','123456','计算机科学系',0,0,'女',20,'2017级','12345678906')
insert into student values('22920172204118','洪虹','123456','计算机科学系',0,0,'女',20,'2017级','12345678907')
insert into student values('22920172204280','曾玥滢','123456','计算机科学系',0,0,'女',20,'2017级','12345678908')
insert into student values('22920172204111','韩李翔','123456','智能科学与技术系',0,0,'男',21,'2017级','12345678909')

create table teacher
(
tid varchar(20) primary key,
tname varchar(20),
tpwd varchar(20),
tdept varchar(20),
tsex varchar(5),
tage int,
ttel varchar(20)
)
insert into teacher values('t001','张三','123456','计算机科学系','男',30,'12345678901')
insert into teacher values('t002','李四','123456','计算机科学系','男',35,'12345678902')
insert into teacher values('t003','王五','123456','智能科学与技术系','女',31,'12345678903')
insert into teacher values('t004','刘六','123456','体育系','男',28,'12345678904')
insert into teacher values('t005','吴七','123456','中文系','女',38,'12345678905')

create table course
(
cid varchar(20) primary key,
cname varchar(20),
tid varchar(20) foreign key references teacher(tid) on delete set null on update cascade,
ccredit int,
ckind varchar(20),
cmax int,
cnum int
)
insert into course values('c001','数据库系统原理','t001',4,'专业必修',40,0)
insert into course values('c002','大数据技术原理','t001',2,'专业选修',30,0)
insert into course values('c003','编译原理','t002',4,'专业必修',50,0)
insert into course values('c004','人工智能基础','t003',2,'专业选修',30,0)
insert into course values('c005','游泳','t004',1,'通识教育',45,0)
insert into course values('c006','大学语文','t005',2,'公共基础',100,0)

create table choice
(
sid varchar(20) foreign key references student(sid) on delete cascade on update cascade,
cid varchar(20) foreign key references course(cid) on delete cascade on update cascade,
grade int,
season varchar(20)
)
go
create trigger t1 on choice for insert as
declare @cid varchar(20)
declare @sid varchar(20)
declare @credit int
declare @grade int
begin
select @cid=cid,@sid=sid,@grade=grade from inserted
select @credit=ccredit from course where course.cid=@cid
update course set cnum=cnum+1 where course.cid=@cid
if @grade>=60
begin
update student set scredit=scredit+@credit where student.sid=@sid
end
end

drop trigger t3
go
create trigger t3 on choice for update as
declare @cid varchar(20)
declare @sid varchar(20)
declare @credit int
declare @newgrade int
declare @oldgrade int
if update(grade)
begin
select @oldgrade=grade from deleted
select @cid=cid,@sid=sid,@newgrade=grade from inserted
select @credit=ccredit from course where course.cid=@cid
if @newgrade>=60
begin
	if @oldgrade<60
	begin
	update student set scredit=scredit+@credit where student.sid=@sid
	end
	if @oldgrade is NULL
	begin
	update student set scredit=scredit+@credit where student.sid=@sid
	end
end
end

insert into choice values('22920172204226','c001',NULL,'2019-2020下')
insert into choice values('22920172204118','c001',NULL,'2018-2019下')
insert into choice values('22920172204280','c005',100,'2018-2019上')
insert into choice values('22920172204280','c002',NULL,'2019-2020下')
insert into choice values('22920172204118','c003',NULL,'2019-2020下')
insert into choice values('22920172204111','c006',100,'2017-2018上')
insert into choice values('22920172204118','c004',100,'2019-2020上')

create table project
(
pid varchar(20) primary key,
pkind varchar(20),
pname varchar(20),
tid varchar(20) foreign key references teacher(tid) on delete set null on update cascade
)

create table report
(
sid varchar(20) foreign key references student(sid) on delete cascade on update cascade,
pid varchar(20) foreign key references project(pid) on delete cascade on update cascade,
rstatus varchar(20),
rcredit int
)
go
create trigger t2 on report for update as
declare @status varchar(20)
declare @sid varchar(20)
declare @credit int
if update(rstatus)
begin
select @status=rstatus,@credit=rcredit,@sid=sid from inserted
if @status='完成'
begin
update student set sicredit=sicredit+@credit where student.sid=@sid
end
end

