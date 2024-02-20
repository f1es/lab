USE buroKadrov;

CREATE TABLE Speciality
(
	ID INT NOT NULL IDENTITY,
	Speciality_Name VARCHAR(30) NOT NULL,
	Salary SMALLMONEY NOT NULL

	CONSTRAINT PK_Speciality_ID PRIMARY KEY (ID)
)

INSERT INTO Speciality VALUES
('slesar', 600),
('mehanik', 250),
('programmer', 300),
('youtuber', 500),
('plotnik', 400)

CREATE TABLE Workers
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(50) NOT NULL,
	Last_Name VARCHAR(50) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday VARCHAR(10) NOT NULL,
	Age INT NOT NULL,
	Speciality_ID INT,
	Department_ID INT NOT NULL

	CONSTRAINT PK_Worker_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Worker_Speciality FOREIGN KEY (Speciality_ID) REFERENCES  Speciality(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Worker_Speciality FOREIGN KEY (Speciality_ID) REFERENCES  Speciality(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,		
)

INSERT INTO Workers VALUES
('Владимир', 'Давыдов', 'Дмитриев','2000-12-12' , 24, 1, 1)

CREATE TABLE Directors
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(30) NOT NULL,
	Last_Name VARCHAR(30) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,

	CONSTRAINT PK_Director_ID PRIMARY KEY (ID)
)

INSERT INTO Directors VALUES
('Valera', '2002-8-13'),
('Ivan', '2002-8-13'),
('John', '2002-7-17'),
('Aleksandr', '2002-9-16'),
('Sergey', '2002-11-15')

CREATE TABLE Companies
(
	ID INT NOT NULL IDENTITY,
	Company_Name VARCHAR(30) NOT NULL,
	Base_Date DATE NOT NULL,
	Director_ID INT NOT NULL UNIQUE,
	--Department_ID INT NOT NULL

	CONSTRAINT PK_Company_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Companys_Director FOREIGN KEY (Director_ID) REFERENCES Directors(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)
 
INSERT INTO Companies VALUES
('plotina inc', '2000-12-20', 1),
('VKYSNO I TOCHKA', '2000-12-20', 2),
('NEVKYSNO I TOCHKA', '1999-12-20', 3),
('AWESOME COMPANY', '2002-12-20', 4),
('MCDONALDS', '2001-12-20', 5)

CREATE TABLE Employees
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(30) NOT NULL,
	Last_Name VARCHAR(30) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	Contract_ID INT NOT NULL,
	Qualification_ID INT NOT NULL UNIQUE,

	CONSTRAINT PK_Employee_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Contract_ID FOREIGN KEY (Contract_ID) REFERENCES Contract(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Contract_ID FOREIGN KEY (Contract_ID) REFERENCES Contract(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Qualification_ID FOREIGN KEY (Qualification_ID) REFERENCES Qualification(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Employees VALUES
('Serega', '1999-11-12', 67),
('Grigoriy', '1999-11-12', 77),
('Semen', '1999-11-12', 61),
('Ilya', '1999-11-12', 17),
('Kirill', '1999-11-12', 167)

CREATE TABLE Offences
(
	ID INT NOT NULL IDENTITY,
	Offence_Name VARCHAR(30) NOT NULL,
	Punishment VARCHAR(30) NOT NULL 

	CONSTRAINT PK_Offence_ID PRIMARY KEY (ID)
)

INSERT INTO Offences VALUES
('Progyl', 'Shtraf'),
('Porcha imyshestva', 'Shtraf'),
('Ygyl', 'Shtraf'),
('Neispolnenie obazannostei', 'Yvolnenie'),
('Opozdanie', 'Shtraf')

CREATE TABLE Encouragements
(
	ID INT NOT NULL IDENTITY,
	Encouragement_Name VARCHAR(30) NOT NULL

	CONSTRAINT PK_Encouragement_ID PRIMARY KEY (ID)
)

INSERT INTO Encouragements VALUES
('Povishenie'),
('Premiya'),
('Otpysk'),
('Ponijenie'),
('Vihodnoi')

CREATE TABLE Workers_telephones
(
	ID INT NOT NULL IDENTITY,
	Telephone_Number VARCHAR(30) NOT NULL,
	Telephone_Type VARCHAR(30),
	Worker_ID INT NOT NULL,

	CONSTRAINT PK_Telephone_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Worker_Telephone FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Workers_telephones VALUES
('+333333', 'Domashniy', 1),
('+333344', 'Domashniy', 2),
('+333355', 'Rabochiyu', 2),
('+333356', 'Domashniy', 3),
('+334444', 'Domashniy', 4)

CREATE TABLE Workers_encouragement
(
	Encouragement_ID INT NOT NULL,
	Worker_ID INT NOT NULL,
	
	CONSTRAINT FK_Encouragement_ID FOREIGN KEY (Encouragement_ID) REFERENCES Encouragements(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Workers_encouragement_ID FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Workers_encouragement VALUES
(1, 1),
(1, 2),
(2, 1),
(2, 3),
(2, 2)

CREATE TABLE Workers_offences
(
	Offence_ID INT NOT NULL,
	Worker_ID INT NOT NULL,

	FOREIGN KEY (Offence_ID) REFERENCES Offences(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Workers_offences VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 1),
(3, 1)

CREATE TABLE Workers_Department
(
	Department_ID INT NOT NULL,
	Worker_ID INT NOT NULL,

	CONSTRAINT FK_Department_ID FOREIGN KEY (Department_ID) REFERENCES Department(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Workers_company_ID FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

-- INSERT INTO Workers_Department VALUES
-- (1, 1),
-- (1, 2),
-- (2, 1),
-- (2, 3),
-- (3, 1)

CREATE TABLE Job_Vacancy
(
	ID INT NOT NULL IDENTITY,
	Receipt_Date DATE NOT NULL,
	Worker_ID INT,
	Employee_ID INT,
	Company_ID INT NOT NULL

	CONSTRAINT PK_JobVacancy_ID PRIMARY KEY (ID)
	CONSTRAINT FK_Worker_ID FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Employee_ID FOREIGN KEY (Employee_ID) REFERENCES Employees(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Company_ID FOREIGN KEY (Company_ID) REFERENCES Companies(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

CREATE TABLE Workers_State
(
	ID INT NOT NULL IDENTITY,
	State_Name VARCHAR(50)

	CONSTRAINT PK_Workers_State_ID PRIMARY KEY (ID)
)

INSERT INTO Workers_State VALUES
('работает'),
('уволен'),
('на больничном'),
('на пенсии'),
('в отпуске'),
('в дикретном отпуске')

CREATE TABLE Proffesion
(
	ID INT NOT NULL IDENTITY,
	Proffesion_Name VARCHAR(50) NOT NULL,
	Salary SMALLMONEY NOT NULL

	CONSTRAINT PK_Proffesion_ID PRIMARY KEY (ID)
)

CREATE TABLE Qualification
(
	ID INT NOT NULL IDENTITY,
	Education VARCHAR(50),
	Work_Expirience INT,
	
	CONSTRAINT PK_Qualification_ID PRIMARY KEY (ID)
)

CREATE TABLE Contract 
(
	ID INT NOT NULL IDENTITY,
	Contract_Number INT NOT NULL,
	Start_Date DATE NOT NULL,
	End_Date DATE NOT NULL,

	CONSTRAINT PK_Contract_ID PRIMARY KEY (ID)
)

CREATE TABLE Department
(
	ID INT NOT NULL IDENTITY,
	Department_Name VARCHAR(50) NOT NULL,
	Company_ID INT NOT NULL,

	CONSTRAINT PK_Departmant_ID PRIMARY KEY (ID)

	CONSTRAINT FK_Company_ID FOREIGN KEY (Company_ID) REFERENCES Companies(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)
