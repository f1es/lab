USE eight;

CREATE TABLE Human
(
	ID INT NOT NULL IDENTITY,
	Human_name VARCHAR(30) NOT NULL,
	Human_surname VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	Birthday DATE NOT NULL,
	Human_weight int NOT NULL,
	Email VARCHAR(30) NOT NULL

	CONSTRAINT PK_Human_ID PRIMARY KEY (ID)
)


INSERT INTO Human VALUES
('VOLODIMIR', 'ALEKSEEV', 22, '2001-12-12' , 70, 'volodimiraleseey@gmail.com'),
('ALEKSANDR', 'ALEKSEEV', 19, '2002-12-12' , 60, 'alexsanya2002@gmail.com'),
('PETR', 'IVOANOV', 33, '1999-12-12' , 61, 'Petro2002@gmail.com'),
('VASILIY', 'SERGEEY', 23, '2003-12-12' , 62, 'vasyacooldude@gmail.com'),
('SEMEN', 'BORISOV', 20, '2002-12-12' , 65, 'sembor2020@gmail.com'),
('ALEKSANDR', 'KOVALEV', 22, '1998-12-22' , 77, 'koval11133@gmail.com'),
('SEMEN', 'PUPKOV', 40, '1988-12-10' , 81, 'semyaaa20@gmail.com'),
('KIRILLL', 'DUBKOV', 32, '1998-12-11' , 70, 'koval11133@gmail.com'),
('ANATOLIY', 'SEMOFOROV', 42, '1989-12-12' , 70, 'tohasefor@gmail.com'),
('KATYA', 'MYTEXTOVA', 24, '2000-10-15', 60, 'mutexkat@gmail.com')

SELECT * FROM Human WHERE Age > 20 AND AGE < 40

SELECT * FROM Human
ORDER BY ID
	OFFSET 5 ROWS
	FETCH NEXT 3 ROWS ONLY

SELECT * FROM Human ORDER BY Human_weight

UPDATE Human SET Age = 10
WHERE Human_weight = 70

DELETE Human
WHERE Age >= 30