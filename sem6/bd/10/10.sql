BEGIN TRANSACTION

INSERT INTO Companies VALUES 
('cool dudes inc.', '1999-12-06', 2)

INSERT INTO WorkersSchema.Workers VALUES
('SEMEN', '1999-05-17', 21, 1)

IF (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Worker_name = 'SEMEN') <= 1
BEGIN
	COMMIT TRANSACTION
	PRINT('SEMEN SUCCESFULLY ADDED')
END
	ELSE
BEGIN
	ROLLBACK TRANSACTION
	PRINT('SEMEN already exists')
END
-------------------------------------
BEGIN TRANSACTION

UPDATE WorkersSchema.Speciality SET Salary = 1000 / (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Speciality_ID = 1) WHERE ID = 1
INSERT INTO WorkersSchema.Workers VALUES
('volodimir', '1999-05-17', 21, 1)


IF (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Speciality_ID = 1) > 5
BEGIN
	ROLLBACK TRANSACTION
	PRINT('slesarei bolshe 5')
END
	ELSE
BEGIN
	COMMIT TRANSACTION
	PRINT('Slesar dobavlen')
END
--------------------------------------
BEGIN TRANSACTION

UPDATE WorkersSchema.Speciality SET Salary = Salary * 1.2 WHERE Speciality_name = 'programmer'
UPDATE WorkersSchema.Speciality SET Salary = Salary * 1.1 WHERE Speciality_name = 'plotnik'
UPDATE WorkersSchema.Speciality SET Salary = Salary * 1.3 WHERE Speciality_name = 'youtuber'

IF (SELECT Salary FROM WorkersSchema.Speciality WHERE ID = 3) > 1000
BEGIN
	ROLLBACK TRANSACTION
	PRINT('y programista slishkom big salary')
END
	ELSE
BEGIN
	COMMIT TRANSACTION
	PRINT('zarplati yvelicheni')
END
--------------------------------------
BEGIN TRANSACTION

UPDATE WorkersSchema.Workers SET Age = Age + 1 WHERE MONTH(Birthday) = 11 AND DAY(Birthday) = 12
DELETE WorkersSchema.Workers WHERE Age > 30

IF (SELECT COUNT(*) FROM WorkersSchema.Workers) < 8
BEGIN
	ROLLBACK TRANSACTION
	PRINT('rabotnikov slishkom malo')
END
	ELSE
BEGIN
	COMMIT TRANSACTION
	PRINT('vozrast obnavlen, dedi yvoleni')
END

SELECT * FROM WorkersSchema.Workers
--------------------------------------
BEGIN TRANSACTION

UPDATE Employees SET Contract_number = '22' + CAST(ROUND(RAND() * 1000, 0) AS VARCHAR) WHERE ID = 2
UPDATE Employees SET Contract_number = '43' + CAST(ROUND(RAND() * 1000, 0) AS VARCHAR) WHERE ID = 3
UPDATE Employees SET Contract_number = '47' + CAST(ROUND(RAND() * 1000, 0) AS VARCHAR) WHERE ID = 4

COMMIT TRANSACTION
	PRINT('contrakti obnovleni')
--------------------------------------

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET TRANSACTION ISOLATION LEVEL READ COMMITTED 
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ 
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE 

sqlcmd -S (localdb)\MSSQLLocalDB
select * from buroKadrov.WorkersSchema.Workers
go

sqlcmd -S (localdb)\MSSQLLocalDB -Q "select * from buroKadrov.WorkersSchema.Workers" -o D:\Git\lab\sem6\bd\10\da.txt