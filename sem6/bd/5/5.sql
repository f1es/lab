--NON UPD
CREATE VIEW WorkersSpecialitiesView AS 
SELECT 
Workers.Worker_name AS WorkerName,
Speciality.Speciality_name AS SpecialityName
FROM Workers 
JOIN Speciality ON Workers.Speciality_ID = Speciality.ID

CREATE VIEW CompanyDirectorsView AS
SELECT
Companies.Company_name AS CompanyName,
Directors.Director_name AS DirectorName
FROM Companies
JOIN Directors ON Companies.Director_ID = Directors.ID

CREATE VIEW WorkersEncouragementsView AS
SELECT * 
FROM Workers, Encouragements, Workers_encouragement
WHERE Workers_encouragement.Worker_ID = Workers.ID AND Workers_encouragement.Encouragement_ID = Encouragements.ID


--UPD
CREATE VIEW WorkersAgeView AS
SELECT Workers.Worker_name, Workers.Age, Workers.Birthday
FROM Workers

INSERT INTO WorkersAgeView VALUES
(
	'Daniil',
	23,
	'2000-4-4'
)

CREATE VIEW TelephonesView AS 
SELECT Workers_telephones.Telephone_number, Workers_telephones.Worker_ID 
FROM Workers_telephones

DROP VIEW TelephonesView

ALTER VIEW TelephonesView AS 
SELECT Workers_telephones.Telephone_number
FROM Workers_telephones

INSERT INTO WorkersAgeView VALUES
(
	'+333333',
	5
)

DELETE FROM TelephonesView
WHERE Telephone_number = '+333333'