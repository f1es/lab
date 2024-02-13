CREATE TRIGGER Speciality_INSERT_UPDATE
ON Speciality
AFTER INSERT, UPDATE
AS 
UPDATE Speciality
SET Salary = Salary + Salary * 0.2
WHERE ID = (SELECT ID FROM inserted)

INSERT INTO Speciality VALUES
('dvornik', 300)

DISABLE TRIGGER Speciality_INSERT_UPDATE ON Speciality
ENABLE TRIGGER Speciality_INSERT_UPDATE ON Speciality

CREATE TRIGGER Workers_INSTEAD_OF_DELETE
ON Workers
INSTEAD OF DELETE
AS 
SELECT Workers.Worker_name FROM Workers 
WHERE Worker_name = ' '

DELETE FROM Workers 
WHERE Workers.ID = 1
