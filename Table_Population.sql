-- Populate the table with test data
DELETE Employee;

INSERT INTO Employee (EmployeeID, SocialInsuranceNumber, Userpass, LastName, FirstName, StartDate)
	VALUES ('001','111222333',HASHBYTES('SHA2_256', 'password'), 'Smith', 'John', '2024-10-29');

SELECT * from Employee;