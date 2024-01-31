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

SELECT AVG(Age) AS Average_Workers_Age FROM Workers
SELECT SUM(Salary) AS Sum_Salary FROM Speciality
SELECT MIN(Age) AS Youngest_worker FROM Workers
SELECT MAX(Age) AS Oldest_worker FROM Workers
SELECT COUNT(*) AS Count_of_speciality FROM Speciality
SELECT COUNT(DISTINCT Speciality_ID) AS Count_of_workers_specialities FROM Workers
SELECT ALL Age FROM Workers

SELECT Age, Birthday, Worker_name
FROM Workers
GROUP BY Age, Birthday, Worker_name
HAVING Age > 22

SELECT Age, Birthday, Worker_name
FROM Workers
GROUP BY Age, Birthday, Worker_name WITH ROLLUP

SELECT Age, Birthday, Worker_name
FROM Workers
GROUP BY Age, Birthday, Worker_name WITH CUBE

SELECT Age, Worker_name
FROM Workers
GROUP BY GROUPING SETS(Age, Worker_name)

SELECT Age, Worker_name,
SUM(Age) OVER (PARTITION BY Worker_name) AS s
FROM Workers
