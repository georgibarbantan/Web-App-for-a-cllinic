create database HealthTech
use HealthTech
go 
create table ApplicationUser(
	UserId int IDENTITY PRIMARY KEY,
	UserName varchar(150),
	FirstName varchar(50),
	LastName varchar(50),
	CNP int,
	Password varchar(50),
	Email varchar(100),
	);

create table Speciality(
	SpecialityId int PRIMARY KEY,
	SpecialityName varchar(100),
	SpecialityDescription varchar(200));

create table Doctor(
	UserId int IDENTITY PRIMARY KEY,
	SpecialityId int,
	Constraint FK_User_Doctor FOREIGN KEY (UserId) references ApplicationUser(UserId)
	ON DELETE NO ACTION,
	Constraint FK_User_Speciality FOREIGN KEY (SpecialityId) references Speciality(SpecialityId)
	ON DELETE NO ACTION
	);
	drop table Doctor
	alter table Doctor
	add BusinessIntervalId int
	alter table Doctor
	add constraint FK_Doctor_BusinessInterval FOREIGN KEY (BusinessIntervalId) references BusinessInterval(BusinessIntervalId) 


create table Patient(
	UserId int IDENTITY PRIMARY KEY,
	Constraint FK_User_Patient FOREIGN KEY (UserId) references ApplicationUser(UserId));

create table BusinessInterval(
	BusinessIntervalId int PRIMARY KEY,
	StartTime time,
	EndTime time
)
alter table BusinessInterval
add Day int

create table Appointment(
	AppointmentId int PRIMARY KEY,
	PatientId int,
	DoctorId int,
	AppointmentDate datetime,
	Constraint FK_Appointment_Patient FOREIGN KEY (PatientId) references Patient(UserId),
	Constraint FK_Appointment_Doctor FOREIGN KEY (DoctorId) references Doctor(UserId));

alter table Appointment
add AppointmentDate datetime

alter table Appointment
add AppointmentDescription varchar(200)
