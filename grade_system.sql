create database grade_system

create table manager
(
mid varchar(20) primary key,
mname varchar(40),
mpwd varchar(20),
mdept varchar(20)
)
insert into manager values('000','��������Ա','123456','ȫ��ϵ')
insert into manager values('001','�������ѧϵ����Ա','123456','�������ѧϵ')
insert into manager values('002','���ܿ�ѧ�뼼��ϵ����Ա','123456','���ܿ�ѧ�뼼��ϵ')
insert into manager values('003','����ϵ����Ա','123456','����ϵ')
insert into manager values('004','����ϵ����Ա','123456','����ϵ')
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
insert into student values('22920172204226','������','123456','�������ѧϵ',0,0,'Ů',20,'2017��','12345678906')
insert into student values('22920172204118','���','123456','�������ѧϵ',0,0,'Ů',20,'2017��','12345678907')
insert into student values('22920172204280','���h��','123456','�������ѧϵ',0,0,'Ů',20,'2017��','12345678908')
insert into student values('22920172204111','������','123456','���ܿ�ѧ�뼼��ϵ',0,0,'��',21,'2017��','12345678909')

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
insert into teacher values('t001','����','123456','�������ѧϵ','��',30,'12345678901')
insert into teacher values('t002','����','123456','�������ѧϵ','��',35,'12345678902')
insert into teacher values('t003','����','123456','���ܿ�ѧ�뼼��ϵ','Ů',31,'12345678903')
insert into teacher values('t004','����','123456','����ϵ','��',28,'12345678904')
insert into teacher values('t005','����','123456','����ϵ','Ů',38,'12345678905')

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
insert into course values('c001','���ݿ�ϵͳԭ��','t001',4,'רҵ����',40,0)
insert into course values('c002','�����ݼ���ԭ��','t001',2,'רҵѡ��',30,0)
insert into course values('c003','����ԭ��','t002',4,'רҵ����',50,0)
insert into course values('c004','�˹����ܻ���','t003',2,'רҵѡ��',30,0)
insert into course values('c005','��Ӿ','t004',1,'ͨʶ����',45,0)
insert into course values('c006','��ѧ����','t005',2,'��������',100,0)

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

insert into choice values('22920172204226','c001',NULL,'2019-2020��')
insert into choice values('22920172204118','c001',NULL,'2018-2019��')
insert into choice values('22920172204280','c005',100,'2018-2019��')
insert into choice values('22920172204280','c002',NULL,'2019-2020��')
insert into choice values('22920172204118','c003',NULL,'2019-2020��')
insert into choice values('22920172204111','c006',100,'2017-2018��')
insert into choice values('22920172204118','c004',100,'2019-2020��')

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
if @status='���'
begin
update student set sicredit=sicredit+@credit where student.sid=@sid
end
end

