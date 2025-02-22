USE master
---建库---------------------------------------------------------------------------------------------
GO
CREATE DATABASE EduSystem
 CONTAINMENT = NONE
 ON  PRIMARY 
(	NAME = 'EduSystem', 
	FILENAME = N'D:\DATA\EduSystem.mdf'  
)
 LOG ON 
(	NAME = 'EduSystem_log', 
	FILENAME = 'D:\DATA\EduSystem_log.ldf' 
 )
 GO
 USE EduSystem 
 ---1-------------------------------------------------------------------------------------------------
--建表-登录表（学号，教师工号，姓名，密码）
IF OBJECT_ID('tb_LogIn')IS NOT NULL
DROP TABLE tb_LogIn
CREATE TABLE tb_LogIn
(StuNO CHAR(10) NOT NULL CONSTRAINT pk_LogIn_StuNo	PRIMARY KEY(StuNo) CONSTRAINT 
	ck_LogIn_StuNo CHECK(StuNO LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
,TeaNo VARCHAR(10) NOT NULL
,Name VARCHAR(20) NOT NULL
,Password VARCHAR(100)NOT NULL
)
--插入数据-登录表
INSERT INTO tb_LogIn
(StuNO,	TeaNo,Name,Password)
 VALUES('3220707051','','曾海红',HASHBYTES('MD5','3220707051'))
GO
---2--------------------------------------------------------------------------------------------------
--建表-个人密保表（学号，教师工号，姓名，密保1，答案1，密保2，答案2）
IF OBJECT_ID('tb_ChangeInformation')IS NOT NULL
DROP TABLE tb_ChangeInformation
CREATE TABLE tb_ChangeInformation(
	StuNO char(10) PRIMARY KEY NOT NULL,
	TeaNO varchar(10) NOT NULL,
	Name varchar(20) NOT NULL,
	PasswordQuestional1 varchar(100) NULL,
	Answer1 varchar(100) NULL,
	PasswordQuestional2 varchar(100) NULL,
	Answer2 varchar(100) NULL
) 
--增加数据-个人密保表
INSERT tb_ChangeInformation
(StuNO,TeaNO,Name,PasswordQuestional1,Answer1 ,PasswordQuestional2,Answer2)
VALUES
('3220707051','','曾海红','籍贯','江西赣州','年龄','20')
GO
--------设置密保-------------------------------------------
IF ASYMKEY_ID('ak_EduBase_ForSymKeyCrypto')IS NOT NULL
	DROP ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto
GO
CREATE ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto
WITH
ALGORITHM=RSA_2048
ENCRYPTION BY PASSWORD='1qaz@WSX';

IF KEY_ID('sk_EduBase_ForSymKeyCrypto')IS NOT NULL
	DROP SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto
GO
CREATE SYMMETRIC KEY sk_EduBase_ForSymKeyCrypto
WITH
ALGORITHM=AES_128
ENCRYPTION BY  ASYMMETRIC KEY ak_EduBase_ForSymKeyCrypto;
GO
---3--------------------------------------------------------------------------------------------------
--建表-个人信息表（学号，姓名，性别，班级，特长）
IF OBJECT_ID('tb_Personal')IS NOT NULL
DROP TABLE tb_Personal
CREATE TABLE tb_Personal(
	StuNo char(10) PRIMARY KEY NOT NULL,
	Name varchar(100) NOT NULL,
	Gender bit NOT NULL,
	BirthDate date NOT NULL,
	Class varchar(200) NOT NULL,
	Specialty varchar(300) NOT NULL,
)
--增加数据-个人信息表
INSERT tb_Personal
      (StuNo,Name,Gender,BirthDate,Class,Specialty)
	  VALUES('3220707051','曾海红','0','2003/2/15','22信管','学习');
GO
---4--------------------------------------------------------------------------------------------------
--建表-公告表(学号，序号，标题，发送人，发送时间，内容)
IF OBJECT_ID('tb_Bulletin')IS NOT NULL
DROP TABLE tb_Bulletin
CREATE TABLE tb_Bulletin(
	StuNo char(20) NOT NULL,
	No varchar(20) PRIMARY KEY NOT NULL,
	Title varchar(100) NULL,
	Type varchar(100) NULL,
	Sender varchar(20) NULL,
	SendTime varchar(40) NULL,
	Text varchar(150) NULL
) 
--增加数据--公告表
INSERT INTO tb_Bulletin
      (StuNo,No,Title,Type,Sender,SendTime)
	  VALUES
	  ('3220707051','1','全国大学生英语四级考试通知','公告','林立','2023/10/1')
	  ,('3220707051','2','全国大学生英语六级考试通知','公告','陈林','2023/10/11')
	  ,('3220707051','3','福建省计算机一级考试通知','公告','张翠萍','2023/10/21')
	  ,('3220707051','4','福建省计算机二级考试通知','公告','林立','2023/10/12')
	  ,('3220707051','5','福建省普通话等级考试通知','公告','陈林','2023/10/24');
GO
---5--------------------------------------------------------------------------------------------------
--公告操作表（学号，公告序号，回复）
IF OBJECT_ID('tb_BulletinOperate')IS NOT NULL
DROP TABLE tb_BulletinOperate
CREATE TABLE tb_BulletinOperate(
	StuNo  char(20) PRIMARY KEY NOT NULL,
	OperateNo varchar(20)  NOT NULL,
	Text varchar(50) NULL
)
GO
---6--------------------------------------------------------------------------------------------------
--建表-留言表（学号，序号，标题，类别，发送人，发送时间，内容）
IF OBJECT_ID('tb_Message')IS NOT NULL
DROP TABLE tb_Message
CREATE TABLE tb_Message(
	StuNo char(20) PRIMARY KEY NOT NULL,
	No varchar(20) NOT NULL,
	Title varchar(100) NULL,
	Type varchar(100) NULL,
	Sender varchar(20) NULL,
	SendTime varchar(40) NULL,
	Text varchar(100) NULL
)
--增加数据-留言表
INSERT INTO tb_Message
      (StuNo,No,Title,Type,Sender,SendTime,Text)
	  VALUES
	  ('3220707051','1','Web程序设计考试通知','留言','陈林','2023/10/1','')
	  ,('3220707051','2','数据库原理考试通知','留言','林立','2023/10/11','')
	  ,('3220707051','3','15号楼今天15：00-22:00停水通知','留言','林巧美','2023/10/21','')
	  ,('3220707051','4','15号楼今天一天都停电通知','留言','林巧美','2023/10/12,','')
	  ,('3220707051','5','22信管期末考通知','留言','林巧美','2023/11/24','');
GO
---7--------------------------------------------------------------------------------------------------
--建表-留言操作表（学号，留言号，回复）
IF OBJECT_ID('tb_MessageOperate')IS NOT NULL
DROP TABLE tb_MessageOperate
CREATE TABLE tb_MessageOperate(
	StuNo char(10) PRIMARY KEY NOT NULL,
	OperateNo varchar(20) NOT NULL,
	Text varchar(50) NULL
) 
GO
---8--------------------------------------------------------------------------------------------------
--建表-学生学籍表（学号，学院，专业，学长，班级，姓名，籍贯，民族，政治面貌，手机号码，生日，性别）
IF OBJECT_ID('tb_StudentIDCard')IS NOT NULL
DROP TABLE tb_StudentIDCard
CREATE TABLE tb_StudentIDCard(
	StuNo char(10)PRIMARY KEY NOT NULL,
	Department varchar(40) NULL,
	Major varchar(40) NOT NULL,
	StudyLength varchar(10) NOT NULL,
	Class char(10) NOT NULL,
	Name varchar(10) NOT NULL,
	NativePlace varchar(100) NULL,
	Nation varchar(100) NOT NULL,
	Political varchar(10) NOT NULL,
	Phone varchar(20) NOT NULL,
	BirthDate date NOT NULL,
	Sex varchar(2) NULL
) 
--增加数据-学生学籍表
INSERT tb_StudentIDCard
      (StuNo,Department,Major,StudyLength,Class,Name,NativePlace,Nation,Political,Phone,BirthDate)
	  VALUES
	  ('3220707051','人文与管理学院','信息管理与信息系统','4','22信管','曾海红','江西赣州','汉族','共青团员','19835781000','20030215')	 
GO
---9--------------------------------------------------------------------------------------------------
--建表-教材订购表（学号，学期，课程，课程类别，书本名称，书本编号，书本作者，出版社，订购时期，订购数量，订购方式，操作）
IF OBJECT_ID('tb_BookManage')IS NOT NULL
DROP TABLE tb_BookManage
CREATE TABLE tb_BookManage(
	StuNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Course varchar(50) NOT NULL,
	StudyType varchar(20) NOT NULL,
	BookName varchar(100) NOT NULL,
	BookIsbn varchar(13) NOT NULL,
	BookAuthor varchar(100) NULL,
	BookPress varchar(100) NULL,
	BookPrice money NOT NULL,
	BookOrderDate date NULL,
	BookAmount int NULL,
	OrderType varchar(15) NULL,
	Remark varchar(100) NULL,
	No int NULL,
	Faculty varchar(15) NULL
) 
--增加数据--建表-教材订购表
INSERT tb_BookManage (StuNo, Term, Course, StudyType, BookName, BookIsbn, BookAuthor, BookPress, BookPrice, BookOrderDate, BookAmount, OrderType, Remark, No, Faculty) 
VALUES
('3220707051', '2022-2023-1', '计算机导论', '学科基础课', '计算机导论', '9787302179641', '黄国兴', N'清华大学出版社', 38.5000, CAST(N'2022-08-17' AS Date), 1, N'线上订购', N'已成功完成订购', 1, N'杜建')
,('3220707051', '2022-2023-1', 'C语言程序设计', '学科基础课', 'C程序设计（第三版）', N'9787302108535', N'谭浩强', N'清华大学出版社', 28.6000, CAST(N'2022-08-17' AS Date), 1, N'线上订购', N'已成功完成订购', 2, N'林丹红')
,('3220707051', '2022-2023-1', '英语1', '通识教育课', '新视野大学英语视听说教程（第一册）（第三版）', N'9787513508605', N'徐钟', N'外研社', 35.9000, CAST(N'2022-08-17' AS Date), 1, N'线上订购', N'已成功完成订购', 3, N'陈伊')
,('3220707051', '2022-2023-2', '计算机网络', '专业教育课', '计算机网络（第3版）', '9787302271284', N'吴功宜', N'清华大学出版社', 43.4500, CAST(N'2023-02-01' AS Date), 1, N'线上订购', N'已成功完成订购', 1, N'刘闽碧')
,('3220707051', '2022-2023-2', '面向对象程序设计', '学科基础课', 'C#程序设计案例教程', '9787302485643', N'向燕飞、魏菊霞、彭之军 ', N'清华大学出版社', 54.7800, CAST(N'2023-02-01' AS Date), 1, N'线上订购', N'已成功完成订购', 2, N'金浪')
GO
---10--------------------------------------------------------------------------------------------------
--建表-校区表（编号，校区名称）
IF OBJECT_ID('tb_Campus')IS NOT NULL
DROP TABLE tb_Campus
CREATE TABLE tb_Campus(
	No int PRIMARY KEY NOT NULL,
	Name varchar(10) NOT NULL
) 
GO
---11--------------------------------------------------------------------------------------------------
--建表-选课信息表（课程号，课程名称，开课单位 ，学分，课程类型，考试类型，教师，学生，开课时间，结课时间，选课时间，成绩）
IF OBJECT_ID('tb_ChooseCourse')IS NOT NULL
DROP TABLE tb_ChooseCourse
CREATE TABLE tb_ChooseCourse(
	CourseNo char(4) PRIMARY KEY NOT NULL,
	CourseName varchar(50) NOT NULL,
	CourseDepartment varchar(50) NOT NULL,
	Credit decimal(3, 1) NOT NULL,
	StudyType varchar(20) NOT NULL,
	ExamType varchar(20) NOT NULL,
	FacultyName varchar(20) NOT NULL,
	StuNo varchar(15) NULL,
	StartTime date NULL,
	EndTime date NULL,
	Term varchar(15) NULL,
	ChoseTime date NULL,
	Score float NULL,
	No int NULL,
	Status varchar(20) NULL
) 
--增加数据-选课信息表
INSERT tb_ChooseCourse (CourseNo, CourseName, CourseDepartment, Credit, StudyType, ExamType, FacultyName, StuNo, StartTime, EndTime, Term, ChoseTime, Score, No, Status) 
VALUES 
('A010', '福建省历史和革命文物探索', '人文与管理学院', 2.0, '线上选修课', '考试', '林立', '3220707051', '2023-09-15',N'2023-12-01', '2022-2023-1', '2022-09-03' , 86, 2, N'已选')
,('A011', '创新创业', '人文与管理学院', 2.0, '线上选修课', '考试', '陈林', '3220707051', '2023-03-05', '2023-06-01' , '2022-2023-2', '2023-03-01' , 90, 3, N'已选')
GO
---12--------------------------------------------------------------------------------------------------
--建表-班级表（序号，年份，专业，行政班，是否毕业，校区）
IF OBJECT_ID('tb_Class')IS NOT NULL
DROP TABLE tb_Class
CREATE TABLE tb_Class(
	No int PRIMARY KEY NOT NULL,
	Year smallint NOT NULL,
	MajorNo int NOT NULL,
	AdministrationClass varchar(20) NULL,
	HasGraduated bit NOT NULL,
	CampusNo int NOT NULL
) 
GO
---13--------------------------------------------------------------------------------------------------
--建表-教室表（序号，教师名称，校区，教学楼）
IF OBJECT_ID('tb_ClassRoom')IS NOT NULL
DROP TABLE tb_ClassRoom
CREATE TABLE tb_ClassRoom(
	No int PRIMARY KEY NOT NULL,
	Name varchar(10) NULL,
	Campus varchar(10) NULL,
	Building varchar(10) NULL
)
--增加数据-教室表
INSERT tb_ClassRoom (No, Name, Campus, Building) 
VALUES
(1, '教室1101', '旗山校区', '自强楼')
,(2, '教室1203', '旗山校区', '自强楼')
,(3, '教室1301', '旗山校区', '自强楼')
,(4, '教室1405', '旗山校区', '自强楼')
,(5, '教室1211', '旗山校区', '自强楼')
,(6, '教室2101', '旗山校区', '厚德楼')
,(7, '教室2102', '旗山校区', '厚德楼')
GO
---14--------------------------------------------------------------------------------------------------
--建表-上课安排表（学号，时间，午别）
IF OBJECT_ID('tb_ClassTime')IS NOT NULL
DROP TABLE tb_ClassTime
CREATE TABLE tb_ClassTime(
	No int PRIMARY KEY NOT NULL,
	Name varchar(20) NULL,
	Noon varchar(5) NULL
)
--增加数据-上课安排表
INSERT tb_ClassTime (No, Name, Noon)
VALUES
 (1, N'8:00-10:00', N'上午')
,(2, N'10:30-12:30', N'上午')
,(3, N'14:30-16:30 ', N'下午')
,(4, N'16:30-18:30', N'下午')
GO
---15--------------------------------------------------------------------------------------------------
--建表-必修课表（学期，午别，星期一，星期二，星期三，星期四，星期五，星期六，星期日）
IF OBJECT_ID('tb_ClassTime1')IS NOT NULL
DROP TABLE tb_ClassTime1
CREATE TABLE tb_ClassTime1(
	Term varchar(20)PRIMARY KEY NOT NULL,
	Noon varchar(5) NULL,
	ClassTimeName varchar(20) NULL,
	星期一 varchar(95) NULL,
	星期二 varchar(95) NULL,
	星期三 varchar(95) NULL,
	星期四 varchar(95) NULL,
	星期五 varchar(95) NULL,
	星期六 varchar(95) NULL,
	星期日 varchar(95) NULL
) 
GO
---16--------------------------------------------------------------------------------------------------
--建表-选修课表（学期，午别，星期一，星期二，星期三，星期四，星期五，星期六，星期日）
IF OBJECT_ID('tb_ClassTime2')IS NOT NULL
DROP TABLE tb_ClassTime2
CREATE TABLE tb_ClassTime2(
	Term varchar(20) PRIMARY KEY NOT NULL,
	Noon varchar(5) NULL,
	ClassTimeName varchar(20) NULL,
	星期一 varchar(95) NULL,
	星期二 varchar(95) NULL,
	星期三 varchar(95) NULL,
	星期四 varchar(95) NULL,
	星期五 varchar(95) NULL,
	星期六 varchar(95) NULL,
	星期日 varchar(95) NULL
)
GO
---17--------------------------------------------------------------------------------------------------
--建表-课程表（学号，学期，开课单位，课程，序号，上课时间，教室，周次，星期，教室）
IF OBJECT_ID('tb_ClassTimeTable')IS NOT NULL
DROP TABLE tb_ClassTimeTable
CREATE TABLE tb_ClassTimeTable(
	StudentNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Department varchar(50) NOT NULL,
	Course varchar(50) NOT NULL,
	No varchar(10) NULL,
	ClassDate date NULL,
	ClassRoomNo int NULL,
	ClassTimeNo int NULL,
	WeekNo int NULL,
	WeekTime varchar(10) NULL,
	Faculty varchar(20) NOT NULL,
	Number int NULL,
	ClassNumber int NULL
) 
GO
---18--------------------------------------------------------------------------------------------------
--建表-课程（课程号，课程名称，学分，课程类型，考试类型，教师，教师职称，开课单位，学期）
IF OBJECT_ID('tb_Course')IS NOT NULL
DROP TABLE tb_Course
CREATE TABLE tb_Course(
	CourseNo char(4) PRIMARY KEY NOT NULL,
	CourseName varchar(50) NOT NULL,
	CourseCredit decimal(3, 1) NOT NULL,
	StudyType varchar(20) NOT NULL,
	ExamType varchar(20) NOT NULL,
	Faculty varchar(20) NOT NULL,
	FacultyTitle varchar(20) NULL,
	Department varchar(50) NOT NULL,
	Term varchar(15) NULL,
	TermName varchar(20) NOT NULL
)
--增加数据-课程
INSERT tb_Course (CourseNo, CourseName, CourseCredit, StudyType, ExamType, Faculty, FacultyTitle, Department, Term, TermName) 
VALUES
('A001', '计算机导论', 3.0, '学科基础课', '考查', '林立', '讲师', '人文与管理学院', '1', '2022-2023-1')
,('A002', 'C语言程序设计',4.5, '学科基础课', '考查', '张翠萍', '教授', '人文与管理学院', '1', '2022-2023-1')
,('A003', 'VB语言程序设计', 4.0, '学科基础课', '考查', '刘闽碧', '讲师', '人文与管理学院', '5', '2024-2025-1')
,('A005', 'SPSS统计分析', 3.0, '学科基础课', '考查', '陈桂芬', '副教授', '人文与管理学院', '4', '2023-2024-2')
,('A009', '面向对象程序设计', 4.5, '学科基础课', '考查', '林立', '讲师', '人文与管理学院', '2', '2022-2023-2')
GO
---19--------------------------------------------------------------------------------------------------
--建表-课程表（学号，学期，开课单位，课程，序号，上课时间，教室，周次，星期，校区，教学楼，教室）
IF OBJECT_ID('tb_Curriculum')IS NOT NULL
DROP TABLE tb_Curriculum
CREATE TABLE tb_Curriculum(
	StudentNo char(10)PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Week varchar(10) NULL,
	WeekTime varchar(10) NULL,
	Course varchar(50) NOT NULL,
	StudyType varchar(20) NOT NULL,
	Department varchar(50) NOT NULL,
	Faculty varchar(20) NOT NULL,
	FacultyTitle varchar(20) NULL,
	ClassDate date NULL,
	Noon varchar(5) NULL,
	ClassTimeName varchar(20) NULL,
	Campus varchar(10) NULL,
	Building varchar(10) NULL,
	Name varchar(10) NULL
)
GO
---20--------------------------------------------------------------------------------------------------
--建表-学位表（序号，名称）
IF OBJECT_ID('tb_Degree')IS NOT NULL
DROP TABLE tb_Degree
CREATE TABLE tb_Degree(
	No int PRIMARY KEY NOT NULL,
	Name varchar(10) NOT NULL
)
--增加数据-学位表
INSERT tb_Degree (No, Name)
VALUES 
(3, '工学')
, (4, '管理学')
,(2, '理学')
,(1, '医学')
GO
---21--------------------------------------------------------------------------------------------------
--建表-学院表（序号，名称）
IF OBJECT_ID('tb_Department')IS NOT NULL
DROP TABLE tb_Department
CREATE TABLE tb_Department(
	No int PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL
)
--增加数据-学院表
INSERT tb_Department (No, Name)
VALUES (7, '马克思主义学院')
,(6, '人文与管理学院')
,(9, '体育部')
,(16, '研究生院')
,(3, '药学院')
,(5, '针灸学院')
,(2, '中西医结合学院')
,(1, '中医学院')
GO
---22--------------------------------------------------------------------------------------------------
--建表-考试申请表（学号，学期，课程，申请类别，申请时间，状态，申请原因）
IF OBJECT_ID('tb_ExamApply')IS NOT NULL
DROP TABLE tb_ExamApply
CREATE TABLE tb_ExamApply(
	StudentNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Course varchar(50) NOT NULL,
	ApplyType varchar(10) NULL,
	ApplyTime date NULL,
	State varchar(15) NULL,
	ApplyReason varchar(1000) NULL
)
--增加数据-考试申请表
INSERT tb_ExamApply (StudentNo, Term, Course, ApplyType, ApplyTime, State, ApplyReason) 
VALUES 
('3220707051', '2022-2023-1', '计算机导论', '缓考', CAST('2022-12-22' AS Date), '已通过', NULL)
,('3220707051', '2022-2023-1', '体育1', '免考','2022-10-01', '已通过', NULL)
,('3220707051', '2023-2024-1', '', '免考','2023-12-30' , NULL, '')
GO
---23--------------------------------------------------------------------------------------------------
--建表-期末考考试表（学号，学期，开课单位，课程，序号，考试类型，周次，午别，开始时间，考试校区，考试教室）
IF OBJECT_ID('tb_ExamEndPlaning')IS NOT NULL
DROP TABLE tb_ExamEndPlaning
CREATE TABLE tb_ExamEndPlaning(
	StudentNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Department varchar(50) NOT NULL,
	Course varchar(50) NOT NULL,
	No int NULL,
	ExamType varchar(15) NULL,
	ExamForm varchar(10) NULL,
	WeekTime varchar(10) NULL,
	ExamTime date NULL,
	Noon varchar(5) NULL,
	StartEndTime varchar(20) NULL,
	ClassCampus varchar(10) NULL,
	ExamCampus varchar(10) NULL,
	ClassRoom varchar(10) NULL
) 
--增加数据-期末考考试表
INSERT tb_ExamEndPlaning (StudentNo, Term, Department, Course, No , ExamType, ExamForm, WeekTime, ExamTime, Noon, StartEndTime, ClassCampus, ExamCampus, ClassRoom) 
VALUES 
('3220707051', '2022-2023-1', '人文与管理学院', '计算机导论', 1, '课程结束考', '闭卷考试', '第17周', CAST('2022-12-18' AS Date), '上午', '9:00-11:00', '旗山校区', '旗山校区', '教室2110')
,('3220707051', '2022-2023-1', '人文与管理学院', 'C语言程序设计', 2, '课程结束考', '闭卷考试', '第18周', CAST('2022-12-23' AS Date), '下午', '15:00-17:00', '旗山校区', '旗山校区', '教室2101')
GO
---24--------------------------------------------------------------------------------------------------
--建表-半期考考试表（学号，学期，开课单位，课程，序号，考试类型，周次，午别，开始时间，考试校区，考试教室）
IF OBJECT_ID('tb_ExamMediumPlaning')IS NOT NULL
DROP TABLE tb_ExamMediumPlaning
CREATE TABLE tb_ExamMediumPlaning(
	StudentNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	Department varchar(50) NOT NULL,
	Course varchar(50) NOT NULL,
	No int NULL,
	ExamType varchar(15) NULL,
	ExamForm varchar(10) NULL,
	WeekTime varchar(10) NULL,
	ExamTime date NULL,
	Noon varchar(5) NULL,
	StartEndTime varchar(20) NULL,
	ClassCampus varchar(10) NULL,
	ExamCampus varchar(10) NULL,
	ClassRoom varchar(10) NULL
) 
--增加数据-半期考考试表
INSERT tb_ExamMediumPlaning (StudentNo, Term, Department, Course, No, ExamType, ExamForm, WeekTime, ExamTime, Noon, StartEndTime, ClassCampus, ExamCampus, ClassRoom) 
VALUES 
('3220707051', '2022-2023-1', '人文与管理学院', '计算机导论', 1, '课程半期考', '闭卷考试', '第9周', '2022-11-12' , '早上', '9:00-11:00', '旗山校区', '旗山校区', '教室2110')
,('3220707051', '2022-2023-1', '人文与管理学院', 'C语言程序设计', 2, '课程半期考', '闭卷考试', '第9周', '2022-11-19' , '下午', '15:00-17:00', '旗山校区', '旗山校区', '教室2101')
GO
---25--------------------------------------------------------------------------------------------------
--建表-考试类别表（序号，名称）
IF OBJECT_ID('tb_ExamType')IS NOT NULL
DROP TABLE tb_ExamType
CREATE TABLE tb_ExamType(
	No int PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL
)
GO
--增加数据-考试类别表
INSERT tb_ExamType (No, Name) 
VALUES 
(1, '考查')
,(2, '考试')
---26--------------------------------------------------------------------------------------------------
--建表-实验预约表（学号，学期，教室，教师，预约时间，预约内容，时长，操作时间）
IF OBJECT_ID('tb_Expriment')IS NOT NULL
DROP TABLE tb_Expriment
CREATE TABLE tb_Expriment(
	StuNo varchar(20) PRIMARY KEY NOT NULL,
	Term varchar(20) NULL,
	ClassRoom varchar(15) NULL,
	Faculty varchar(15) NULL,
	Content varchar(50) NULL,
	ReservTime date NULL,
	Timespan varchar(15) NULL,
	OperateTime date NULL
)
GO
---27--------------------------------------------------------------------------------------------------
--建表-教师表（工号，姓名，性别，生日，任职时间，手机号，职称，所属学院）
IF OBJECT_ID('tb_Faculty')IS NOT NULL
DROP TABLE tb_Faculty
CREATE TABLE tb_Faculty(
	No char(7) PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	Gender bit NOT NULL,
	BirthDate date NULL,
	AdmitDate date NULL,
	Phone varchar(20) NULL,
	TitleNo int NOT NULL,
	DepartmentNo int NOT NULL
)
--增加数据-教师表
INSERT tb_Faculty (No, Name, Gender, BirthDate, AdmitDate, Phone, TitleNo, DepartmentNo) 
VALUES 
('1988012', '陈炜', 0, CAST('1964-04-19' AS Date), CAST('1988-07-06' AS Date), '13075940686', 3, 6)
 ,('1989008', '刘闽碧', 0, CAST('1965-08-25' AS Date), CAST('1989-08-20' AS Date), '13706969310', 3, 6)
,('1994001', '金浪', 1, CAST('1967-04-26' AS Date), CAST('1994-08-19' AS Date), '0591-87239823', 5, 6)
,('1996012', '李胜旭', 1, CAST('1973-02-07' AS Date), CAST('1996-08-18' AS Date), '18905011828', 12, 6)
GO
---28--------------------------------------------------------------------------------------------------
--建表-教师职称表（序号，名称，级别）
IF OBJECT_ID('tb_FacultyTitle')IS NOT NULL
DROP TABLE tb_FacultyTitle
CREATE TABLE tb_FacultyTitle(
	No int PRIMARY KEY NOT NULL,
	Name varchar(20) NULL,
	LevelFlag tinyint NULL
) 
--增加数据-教师职称表
INSERT tb_FacultyTitle (No, Name, LevelFlag)
VALUES
(1, '见习助教', 0)
,(2, '助教', 1)
,(3, '讲师', 2)
,(4, '副教授', 3)
,(5, '教授', 4)
GO
---29--------------------------------------------------------------------------------------------------
--建表-等级考试表（学号，序号，考试内容，分数，等级）
IF OBJECT_ID('tb_GradeExam')IS NOT NULL
DROP TABLE tb_GradeExam
CREATE TABLE tb_GradeExam(
	StuNo char(10) PRIMARY KEY NOT NULL,
	No varchar(10) NOT NULL,
	ExamCount varchar(50) NOT NULL,
	Scores varchar(10) NOT NULL,
	Grades varchar(10) NOT NULL,
	ExamTime date NOT NULL,
	Name varchar(10) NULL,
	Rank varchar(15) NULL
) 
--增加数据-等级考试表
INSERT tb_GradeExam (StuNo, No, ExamCount, Scores, Grades, ExamTime, Name, Rank) 
VALUES 
('3220707053', '001', '全国大学生英语四级考试', '420', 'D', CAST('2023-06-11' AS Date), nULL, nULL)
,('3220707051', '001', '全国大学生英语四级考试', '445', 'C', CAST('2023-06-13' AS Date), '曾海红', '已过')
,('3220707051', '002', '全国大学生普通话考试', '85', 'B', CAST('2023-10-25' AS Date), '曾海红', '二级甲等')
GO
---30--------------------------------------------------------------------------------------------------
--建表-专业表（序号，名称，简称，学位，时长，学院）
IF OBJECT_ID('tb_Major')IS NOT NULL
DROP TABLE tb_Major
CREATE TABLE tb_Major(
	No int PRIMARY KEY NOT NULL,
	Name varchar(50) NOT NULL,
	ShortName varchar(20) NULL,
	DegreeNo int NOT NULL,
	Length tinyint NOT NULL,
	DepartmentNo int NOT NULL,
	IsEnrolling bit NOT NULL
) 
GO
---31--------------------------------------------------------------------------------------------------
--建表-实习表（序号，学期，医院，医院单位，分组，周次，时间，学号）
IF OBJECT_ID('tb_Practice')IS NOT NULL
DROP TABLE tb_Practice
CREATE TABLE tb_Practice(
	No varchar(5) PRIMARY KEY NOT NULL,
	Term varchar(20) NULL,
	Hospital varchar(30) NULL,
	HospitalDepart varchar(20) NULL,
	GroupNo varchar(5) NULL,
	Week varchar(5) NULL,
	Time date NULL,
	StuNo varchar(20) NULL
)
--增加数据-实习表
INSERT tb_Practice (No, Term, Hospital, HospitalDepart, GroupNo, Week, Time, StuNo)
VALUES 
('001', '2025-2026-1', '福建中医药大学附属医院', '信息科', '1', '16', CAST('2025-12-25' AS Date), '3220707051')
GO
---32--------------------------------------------------------------------------------------------------
--建表-课程成绩表（学号，学期，课程，学分，课程类别，考试类型，平时成绩，期末成绩，总成绩）
IF OBJECT_ID('tb_SelectStuScores')IS NOT NULL
DROP TABLE tb_SelectStuScores
CREATE TABLE tb_SelectStuScores(
	学号 char(10) PRIMARY KEY NOT NULL,
	学期 varchar(20) NOT NULL,
	课程 varchar(50) NOT NULL,
	学分 decimal(3, 1) NOT NULL,
	课程类型 varchar(20) NOT NULL,
	考试类型 varchar(20) NOT NULL,
	平时成绩 decimal(4, 1) NULL,
	期末成绩 decimal(4, 1) NULL,
	总成绩 numeric(7, 2) NULL
)
--增加数据-课程成绩表
INSERT tb_SelectStuScores (学号, 学期, 课程, 学分, 课程类型, 考试类型, 平时成绩, 期末成绩, 总成绩) 
VALUES 
('3220707051', '2022-2023-1', '计算机导论', CAST(3.0 AS Decimal(3, 1)), '学科基础课', '考试', CAST(91.0 AS Decimal(4, 1)), CAST(90.1 AS Decimal(4, 1)), CAST(90.37 AS numeric(7, 2)))
,('3220707051', '2022-2023-1', 'C语言程序设计', CAST(4.5 AS Decimal(3, 1)), '学科基础课', '考试', CAST(96.0 AS Decimal(4, 1)), CAST(81.8 AS Decimal(4, 1)), CAST(83.06 AS numeric(7, 2)))
,('3220707051', '2022-2023-1', '英语1', CAST(4.0 AS Decimal(3, 1)), '通识教育课', '考试', CAST(86.0 AS Decimal(4, 1)), CAST(86.0 AS Decimal(4, 1)), CAST(96.00 AS numeric(7, 2)))
,('3220707051', '2022-2023-2', '计算机网络', CAST(4.0 AS Decimal(3, 1)), '专业教育课', '考试', CAST(87.0 AS Decimal(4, 1)), CAST(96.6 AS Decimal(4, 1)), CAST(86.72 AS numeric(7, 2)))
GO
---33--------------------------------------------------------------------------------------------------
--建表-课程类别表（序号，名称）
IF OBJECT_ID('tb_StudyType')IS NOT NULL
DROP TABLE tb_StudyType
CREATE TABLE tb_StudyType(
	No int PRIMARY KEY NOT NULL,
	Name varchar(20) NOT NULL,
	HourComputation varchar(100) NULL
) 
--增加数据-课程类别表
INSERT tb_StudyType (No, Name, HourComputation) 
VALUES 
(1, '通识教育课', '@Credit*(@Factor-2)')
, (2, '学科基础课', '@Credit*@Factor')
,(3, '专业教育课', '@Credit*(@Factor+2)')
,(4, '专业选修课', '@Credit*@Factor-10')
GO
---34--------------------------------------------------------------------------------------------------
--建表-学生评教表（学号，学期，教师，开课单位，教师职称，所授课程，评分）
IF OBJECT_ID('tb_StudentEvaluate')IS NOT NULL
DROP TABLE tb_StudentEvaluate
CREATE TABLE tb_StudentEvaluate(
	StudentNo char(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NOT NULL,
	FacultyName varchar(20) NOT NULL,
	FacultyDepartment varchar(50) NOT NULL,
	FacultyTitle varchar(20) NULL,
	Course varchar(50) NOT NULL,
	FacultyRate decimal(4, 1) NULL
)
--增加数据-学生评教表
INSERT tb_StudentEvaluate (StudentNo, Term, FacultyName, FacultyDepartment, FacultyTitle, Course, FacultyRate)
VALUES 
('3220707051', '2022-2023-1', '刘闽碧', '人文与管理学院', '讲师', '计算机导论', CAST(65.0 AS Decimal(4, 1)))
,('3220707051', '2022-2023-1', '张翠萍', '人文与管理学院', '教授', 'C语言程序设计', CAST(65.0 AS Decimal(4, 1)))
,('3220707051', '2022-2023-1', '林翰', '人文与管理学院', '助教', '英语1', CAST(86.0 AS Decimal(4, 1)))
,('3220707051', '2022-2023-2', '陈林', '人文与管理学院', '讲师', '计算机网络', CAST(72.0 AS Decimal(4, 1)))
GO
---35--------------------------------------------------------------------------------------------------
--建表-学期学生评教表（序号，学期，分组，开始评价时间，结束评价时间，学号，操作状态）
IF OBJECT_ID('tb_StuEvaluate')IS NOT NULL
DROP TABLE tb_StuEvaluate
CREATE TABLE tb_StuEvaluate(
	No varchar(10) PRIMARY KEY NOT NULL,
	Term varchar(20) NULL,
	GroupName varchar(30) NULL,
	StartTime date NULL,
	EndTime date NULL,
	Operate varchar(15) NULL,
	StuNo varchar(15) NULL,
	Type varchar(15) NULL
)
--增加数据-学期学生评教表
INSERT tb_StuEvaluate (No, Term, GroupName, StartTime, EndTime, Operate, StuNo, Type) 
VALUES 
('001', '2022-2023-1', '2022-2023-1学生评教', CAST('2022-12-25' AS Date), CAST('2023-02-01' AS Date), '已评教', '3220707051', '学生评教')
,('002', '2022-2023-2', '2022-2023-2学生评教', CAST('2023-06-19' AS Date), CAST('2023-09-01' AS Date), '已评教', '3220707051', '学生评教')
,('003', '2023-2024-1', '2023-2024-1学生评教', CAST('2023-12-25' AS Date), CAST('2024-02-01' AS Date), '已评教', '3220707051', '学生评教')
GO
---36--------------------------------------------------------------------------------------------------
--建表-学期表（序号，名称）
IF OBJECT_ID('tb_Term')IS NOT NULL
DROP TABLE tb_Term
CREATE TABLE tb_Term(
	No int PRIMARY KEY  NOT NULL,
	Name varchar(20) NOT NULL
) 
--增加数据-学期表
INSERT tb_Term (No, name) 
VALUES 
(1, '2022-2023-1')
,(2, '2022-2023-2')
,(3, '2023-2024-1')
,(4, '2023-2024-2')
,(5, '2024-2025-1')
GO
---37--------------------------------------------------------------------------------------------------
--建表-星期表（序号，名称）
IF OBJECT_ID('tb_Week')IS NOT NULL
DROP TABLE tb_Week
CREATE TABLE tb_Week(
	No int  PRIMARY KEY NOT NULL,
	Name varchar(10) NULL
)
--增加数据-星期表
INSERT tb_Week (No, Name) 
VALUES 
(1, '第1周')
,(2, '第2周')
,(3, '第3周')
,(4, '第4周')
,(5, '第5周')
GO
---38--------------------------------------------------------------------------------------------------
--建表-教学周历表（日期，学期，周次，星期，任务）
IF OBJECT_ID('tb_TeachingCalender')IS NOT NULL
DROP TABLE tb_TeachingCalender
CREATE TABLE tb_TeachingCalender(
	Date date PRIMARY KEY NOT NULL,
	TermPart char(1) NOT NULL,
	TeachingWeek smallint NOT NULL,
	WeekDay tinyint NOT NULL,
	Remark varchar(100) NULL,
	TermName varchar(20) NULL
)
GO
---39--------------------------------------------------------------------------------------------------
--建表-教学任务表（序号，学期，课程号，课程名称，开课单位，课程学分，考试类别，课程类别，是否考试）
IF OBJECT_ID('tb_TeachingTask')IS NOT NULL
DROP TABLE tb_TeachingTask
CREATE TABLE tb_TeachingTask(
	No varchar(30) PRIMARY KEY NOT NULL,
	Term varchar(30) NOT NULL,
	CourseNo varchar(50) NOT NULL,
	CourseName varchar(50) NOT NULL,
	Unit varchar(50) NOT NULL,
	CourseCredit int NOT NULL,
	CourseHour int NOT NULL,
	ExamType varchar(10) NOT NULL,
	CourseType varchar(10) NOT NULL,
	isExam varchar(10) NOT NULL
)

