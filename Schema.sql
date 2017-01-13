
CREATE DATABASE UMSDB
use UMSDB
CREATE TABLE Department(
Id int IDENTITY(1,1) NOT NULL,
Code varchar(10) NOT NULL,
Name varchar(100) NOT NULL,
PRIMARY KEY(Id)
)

CREATE TABLE Course(
Id int IDENTITY(1,1) NOT NULL,
Code varchar(10) NOT NULL,
Title varchar(100) NOT NULL,
Credit decimal(18,2) NOT NULL
PRIMARY KEY(Id)
)

CREATE TABLE Student(
Id int IDENTITY(1,1) NOT NULL,
Name varchar(50) NOT NULL,
RegNo varchar(15) NOT NULL UNIQUE,
PhoneNo varchar(15) NOT NULL UNIQUE,
Address varchar(max) NOT NULL,
DepartmentId int NOT NULL,
PRIMARY KEY(Id),
CONSTRAINT fk_Student_Dept FOREIGN KEY(DepartmentId) REFERENCES Department(Id)
)

CREATE TABLE StudentCourse(
StudentId int NOT NULL,
CourseId int NOT NULL,
EnrollDate date NOT NULL,
CONSTRAINT fk_StudentCourse_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
CONSTRAINT fk_StudentCourse_Course FOREIGN KEY(CourseId) REFERENCES Course(Id)
)
 