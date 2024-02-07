CREATE FUNCTION ShowWorkersInfo()
RETURNS TABLE
AS 
RETURN
(
    SELECT Worker_name, Age, Speciality.Salary, Speciality.Speciality_name
    FROM Workers
    JOIN Speciality ON Workers.Speciality_ID = Speciality.ID
)

CREATE FUNCTION ShowCompanies()
RETURNS TABLE
AS
RETURN
(
    SELECT Company_name, Base_date, Director_name
    FROM Companies
    JOIN Directors ON Companies.Director_ID = Directors.ID
)

CREATE FUNCTION SpecialistsCount()
RETURNS TABLE
AS 
RETURN 
(
	SELECT Speciality.Speciality_name, COUNT(*) as Specialists_Count
	FROM Workers
	JOIN Speciality ON Speciality.ID = Workers.Speciality_ID
	GROUP BY Speciality.Speciality_name 
)

CREATE FUNCTION WorkersAverageAge()
RETURNS FLOAT
BEGIN
	RETURN (SELECT AVG(Age) FROM Workers)
END;
SELECT dbo.WorkersAverageAge()

CREATE FUNCTION SpecialitiesAverageSalary()
RETURNS FLOAT
BEGIN
	RETURN (SELECT AVG(Salary) FROM Speciality)
END;

CREATE FUNCTION GetWorkersTable()
RETURNS @res TABLE (ID INT PRIMARY KEY, Worker_Name NVARCHAR(50), Age INT)
AS 
BEGIN
	INSERT @res (ID, Worker_Name, Age)
	SELECT ID, Worker_Name, Age FROM Workers
	RETURN
END;


SELECT * FROM ShowWorkersInfo()
SELECT * FROM ShowCompanies()
SELECT * FROM SpecialistsCount()
SELECT dbo.WorkersAverageAge()
SELECT dbo.SpecialitiesAverageSalary()
SELECT * FROM GetWorkersTable()