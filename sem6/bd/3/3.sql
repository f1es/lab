
SELECT Workers.Worker_name, Speciality.Speciality_name
FROM Workers
JOIN Speciality ON Speciality.ID = Workers.Speciality_ID

SELECT * FROM Workers
FULL JOIN Speciality ON Workers.Speciality_ID = Speciality.ID

SELECT * FROM Workers
RIGHT JOIN Speciality ON Workers.Speciality_ID = Speciality.ID

SELECT * FROM Workers
LEFT JOIN Speciality ON Workers.Speciality_ID = Speciality.ID

SELECT * FROM Workers
CROSS JOIN Speciality

SELECT Worker_name
FROM Workers
UNION 
SELECT Employee_name
FROM Employees

SELECT Worker_name
FROM Workers
EXCEPT 
SELECT Employee_name
FROM Employees

SELECT Worker_name
FROM Workers
INTERSECT
SELECT Employee_name
FROM Employees

SELECT Workers.Worker_name, Speciality.Speciality_name, Companies.Company_name FROM Workers
JOIN Speciality ON Speciality.ID = Workers.Speciality_ID
JOIN Workers_company ON Workers_company.Worker_ID = Workers.ID
JOIN Companies ON Companies.ID = Workers_company.Company_ID