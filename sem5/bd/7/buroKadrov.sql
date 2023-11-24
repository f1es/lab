USE buroKadrov;

CREATE TABLE Speciality
(
	ID INT NOT NULL IDENTITY,
	Speciality_name VARCHAR(30) NOT NULL,
	Salary SMALLMONEY NOT NULL

	CONSTRAINT PK_Speciality_ID PRIMARY KEY (ID)
)

INSERT INTO Speciality VALUES
('slesar', 122),
('mehanik', 125),
('programmer', 333),
('youtuber', 555),
('clown', 444)

CREATE TABLE Workers
(
	ID INT NOT NULL IDENTITY,
	Worker_name VARCHAR(50) NOT NULL,
	Birthday VARCHAR(10) NOT NULL,
	Age INT NOT NULL,
	Speciality_ID INT NOT NULL,

	CONSTRAINT PK_Worker_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Worker_Speciality FOREIGN KEY (Speciality_ID) REFERENCES  Speciality(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Workers VALUES
('Volodimir','1999-12-12' , 25, 1),
('Oleksei','1999-11-11', 22, 2),
('Oleksii','1998-12-30', 21, 2),
('Mihail','1999-12-12', 24, 1),
('Sergio','1999-12-12', 25, 3)

CREATE TABLE Directors
(
	ID INT NOT NULL IDENTITY,
	Director_name VARCHAR(30) NOT NULL,
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
	Company_name VARCHAR(30) NOT NULL,
	Base_date DATE NOT NULL,
	Director_ID INT NOT NULL,

	CONSTRAINT PK_Company_ID PRIMARY KEY (ID),
	CONSTRAINT FK_Companys_Director FOREIGN KEY (Director_ID) REFERENCES Directors(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)
 
INSERT INTO Companies VALUES
('Clowns inc', '2000-12-20', 1),
('VKYSNO I TOCHKA', '2000-12-20', 2),
('NEVKYSNO I TOCHKA', '1999-12-20', 3),
('AWESOME COMPANY', '2002-12-20', 4),
('MCDONALDS', '2001-12-20', 5)

CREATE TABLE Employees
(
	ID INT NOT NULL IDENTITY,
	Employee_name VARCHAR(30) NOT NULL,
	Birthday DATE NOT NULL,
	Contract_number INT NOT NULL,

	CONSTRAINT PK_Employee_ID PRIMARY KEY (ID)
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
	Offence_name VARCHAR(30) NOT NULL,
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
	Encouragement_name VARCHAR(30) NOT NULL

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
	Telephone_number VARCHAR(30) NOT NULL,
	Telephone_type VARCHAR(30),
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
		CONSTRAINT PK_Workers_offences PRIMARY KEY ()
)

INSERT INTO Workers_offences VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 1),
(3, 1)

CREATE TABLE Workers_company
(
	Company_ID INT NOT NULL,
	Worker_ID INT NOT NULL,

	CONSTRAINT FK_Company_ID FOREIGN KEY (Company_ID) REFERENCES Companies(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT FK_Workers_company_ID FOREIGN KEY (Worker_ID) REFERENCES Workers(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

INSERT INTO Workers_company VALUES
(1, 1),
(1, 2),
(2, 1),
(2, 3),
(3, 1)