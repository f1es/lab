CREATE TRIGGER Speciality_INSERT_UPDATE ----
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

CREATE TRIGGER Workers_INSTEAD_OF_DELETE ----
ON Workers
INSTEAD OF DELETE
AS 
SELECT Workers.Worker_name FROM Workers 
WHERE Worker_name = ' '

DELETE FROM Workers 
WHERE Workers.ID = 1

CREATE TABLE WorkersHistory
(
	ID INT NOT NULL,
	Worker_name VARCHAR(50),
	Speciality_ID INT NOT NULL,
	Process VARCHAR(20)

    FOREIGN KEY (Speciality_ID) REFERENCES  Speciality(ID)
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
)

USE buroKadrov
GO
CREATE TRIGGER Workers_INSERT ----
ON Workers
AFTER INSERT
AS
INSERT INTO WorkersHistory(ID, Worker_name, Speciality_ID, Process)
SELECT ID, Worker_name, Speciality_ID, 'inserted'
FROM inserted

USE buroKadrov
GO
CREATE TRIGGER Workers_UPDATE ----
ON Workers
AFTER UPDATE
AS
INSERT INTO WorkersHistory(ID, Worker_name, Speciality_ID, Process)
SELECT ID, Worker_name, Speciality_ID, 'updated'
FROM inserted

UPDATE Workers SET Speciality_ID = 3
WHERE Workers.ID = 3009

USE buroKadrov
GO
CREATE TRIGGER Workers_DELETE ----
ON Workers
AFTER DELETE
AS
INSERT INTO WorkersHistory(ID, Worker_name, Speciality_ID, Process)
SELECT ID, Worker_name, Speciality_ID, 'deleted'
FROM deleted

USE buroKadrov
DELETE FROM Workers
WHERE ID = 3009