
SELECT *,
(SELECT Salary From Speciality WHERE Speciality.ID = Workers.Speciality_ID) AS Salary
FROM Workers

SELECT * 
FROM Speciality
WHERE ID NOT IN (SELECT Speciality_ID FROM Workers)

SELECT * FROM Speciality
WHERE Salary < ANY(SELECT Salary FROM Speciality WHERE Salary > 200)

SELECT * 
FROM Workers
WHERE Age < ALL(SELECT MAX(Age) FROM Workers WHERE Speciality_ID='1')

SELECT *
FROM Workers
WHERE EXISTS (SELECT Telephone_type FROM Workers_telephones WHERE Workers.ID = Workers_telephones.Worker_ID)

DELETE FROM Workers
WHERE Speciality_ID=(SELECT ID FROM Speciality WHERE Speciality_name='clown')

INSERT INTO Workers VALUES
(
    (SELECT Employee_name FROM Employees WHERE ID = 1),
    (SELECT Birthday FROM Employees WHERE ID = 1),
    YEAR(GETDATE()) - YEAR((SELECT Birthday FROM Employees WHERE ID = 1)),
    1
)

UPDATE Workers
SET Speciality_ID = (SELECT ID FROM Speciality WHERE Speciality_name='clown')
WHERE Speciality_ID = (SELECT ID FROM Speciality WHERE Speciality_name='youtuber')

INSERT INTO Workers VALUES
(
    (SELECT Employee_name FROM Employees WHERE ID = (SELECT ID FROM Employees WHERE ID = 2)),
    (SELECT Birthday FROM Employees WHERE ID = (SELECT ID FROM Employees WHERE ID = 2)),
    YEAR(GETDATE()) - YEAR((SELECT Birthday FROM Employees WHERE ID = (SELECT ID FROM Employees WHERE ID = 2))),
    2
)

------------------------------------------
SELECT * FROM Workers
WHERE 
DAY(Workers.Birthday) = DAY(GETDATE()) AND 
MONTH(Workers.Birthday) = MONTH(GETDATE())