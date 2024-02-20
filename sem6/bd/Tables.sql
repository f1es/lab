USE IS_Buro_Kadrov

CREATE TABLE Speciality
(
	ID INT NOT NULL IDENTITY,
	Speciality_Name VARCHAR(30) NOT NULL

	CONSTRAINT PK_Speciality_ID PRIMARY KEY (ID)
)

CREATE TABLE Directors
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(30) NOT NULL,
	Last_Name VARCHAR(30) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,

	CONSTRAINT PK_Director_ID PRIMARY KEY (ID)
)

CREATE TABLE Offences
(
	ID INT NOT NULL IDENTITY,
	Offence_Name VARCHAR(30) NOT NULL,
	Punishment VARCHAR(30) NOT NULL 

	CONSTRAINT PK_Offence_ID PRIMARY KEY (ID)
)

CREATE TABLE Encouragements
(
	ID INT NOT NULL IDENTITY,
	Encouragement_Name VARCHAR(30) NOT NULL

	CONSTRAINT PK_Encouragement_ID PRIMARY KEY (ID)
)

CREATE TABLE Workers_State
(
	ID INT NOT NULL IDENTITY,
	State_Name VARCHAR(50)

	CONSTRAINT PK_Workers_State_ID PRIMARY KEY (ID)
)

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

----------------------------------------------

CREATE TABLE Company
(
	ID INT NOT NULL IDENTITY,
	Company_Name VARCHAR(30) NOT NULL,
	Base_Date DATE NOT NULL,
	Director_ID INT NOT NULL UNIQUE,

	CONSTRAINT PK_Company_ID PRIMARY KEY (ID),
	FOREIGN KEY (Director_ID) REFERENCES Directors(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

CREATE TABLE Department
(
	ID INT NOT NULL IDENTITY,
	Department_Name VARCHAR(50) NOT NULL,
	Company_ID INT NOT NULL,

	CONSTRAINT PK_Departmant_ID PRIMARY KEY (ID),
	FOREIGN KEY (Company_ID) REFERENCES Company(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

CREATE TABLE Workers
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(50) NOT NULL,
	Last_Name VARCHAR(50) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	Age INT NOT NULL,
	Speciality_ID INT,
	Department_ID INT NOT NULL

	CONSTRAINT PK_Worker_ID PRIMARY KEY (ID),
	FOREIGN KEY (Speciality_ID) REFERENCES  Speciality(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Department_ID) REFERENCES Department(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,		
)

CREATE TABLE Employee
(
	ID INT NOT NULL IDENTITY,
	First_Name VARCHAR(30) NOT NULL,
	Last_Name VARCHAR(30) NOT NULL,
	Middle_Names VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	Contract_ID INT NOT NULL,
	Qualification_ID INT NOT NULL UNIQUE,

	CONSTRAINT PK_Employee_ID PRIMARY KEY (ID),
	FOREIGN KEY (Contract_ID) REFERENCES Contract(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Qualification_ID) REFERENCES Qualification(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

CREATE TABLE Workers_telephones
(
	ID INT NOT NULL IDENTITY,
	Telephone_Number VARCHAR(30) NOT NULL,
	Telephone_Type VARCHAR(30),
	Worker_ID INT NOT NULL,

	CONSTRAINT PK_Telephone_ID PRIMARY KEY (ID),
	FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

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
	FOREIGN KEY (Employee_ID) REFERENCES Employee(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Company_ID) REFERENCES Company(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

------------------------------------------------------------

CREATE TABLE Workers_encouragement
(
	Encouragement_ID INT NOT NULL,
	Worker_ID INT NOT NULL,
	
	FOREIGN KEY (Encouragement_ID) REFERENCES Encouragements(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

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

CREATE TABLE Workers_Department
(
	Department_ID INT NOT NULL,
	Worker_ID INT NOT NULL,

	FOREIGN KEY (Department_ID) REFERENCES Department(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

CREATE TABLE Proffesions_Vacancy
(
	Vacancy_ID INT NOT NULL,
	Proffesion_ID INT NOT NULL,

	FOREIGN KEY (Vacancy_ID) REFERENCES Job_Vacancy(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	FOREIGN KEY (Proffesion_ID) REFERENCES Proffesion(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)