create database TrainingStudent 
go
use TrainingStudent 
create table CourseCategory(
	CategoryID int IDENTITY(1,1) primary key,
	CategoryName nvarchar(100),
	Description nvarchar(100)
)
go
create table Course(
	CourseID int IDENTITY(1,1) primary key,
	CourseName nvarchar(100),
	CategoryID int references CourseCategory(CategoryID),
	Description nvarchar(100)
)
go
create table Trainer(
	TrainerID int IDENTITY(1,1) primary key,
	TrainerName nvarchar(100),
	Type nvarchar(100),
	WorkPlace nvarchar(100),
	Phone int,
	Email nvarchar(100),
	CourseID int references Course(CourseID)
)
go
create table Topic(
	TopicID int  IDENTITY(1,1) primary key,
	TopicName nvarchar(100),
	CourseID int references Course(CourseID),
	TrainerID int references Trainer(TrainerID),
	Description nvarchar(100)
)
go
create table Trainee(
	TraineeID int IDENTITY(1,1) primary key,
	TraineeName nvarchar(100),
	Account nvarchar(100),
	Majors nvarchar(100),
	Classroom nvarchar(100),
	CourseID int references Course(CourseID),
	Location nvarchar(100)
)
go
create table Staff(
	StaffID int IDENTITY(1,1) primary key,
	StaffName nvarchar(100),
	StaffPhone nvarchar(100),
	StaffEmail nvarchar(100),
	[Address] nvarchar(100)
)
go


