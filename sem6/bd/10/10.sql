
BEGIN TRANSACTION

INSERT INTO Companies VALUES 
('cool dudes inc.', '1999-12-06', 2)

INSERT INTO WorkersSchema.Workers VALUES
('SEMEN', '1999-05-17', 21, 1)

IF (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Worker_name = 'SEMEN') = 0 
BEGIN
	ROLLBACK TRANSACTION
	PRINT('SEMEN already exists')
END
	ELSE
BEGIN
	COMMIT TRANSACTION
	PRINT('SEMEN SUCCESFULLY ADDED')
END
-------------------------------------
BEGIN TRANSACTION

UPDATE WorkersSchema.Speciality SET Salary = 1000 / (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Speciality_ID = 1) WHERE ID = 1

INSERT INTO WorkersSchema.Workers VALUES
('volodimir', '1999-05-17', 21, 1)


IF (SELECT COUNT(*) FROM WorkersSchema.Workers WHERE Speciality_ID = 1) > 5 --EXISTS (SELECT * FROM WorkersSchema.Workers WHERE Worker_name = 'SEMEN')
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


sqlcmd -S (localdb)\MSSQLLocalDB
select * from buroKadrov.WorkersSchema.Workers
go

sqlcmd -S (localdb)\MSSQLLocalDB -Q "select * from buroKadrov.WorkersSchema.Workers" -o D:\Git\lab\sem6\bd\10\da.txt