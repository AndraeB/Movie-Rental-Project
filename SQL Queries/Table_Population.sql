-- Populate the table with test data
DELETE Employee;

INSERT INTO Employee (EmployeeID, SocialInsuranceNumber, Userpass, LastName, FirstName, StartDate)
	VALUES ('001','111222333',HASHBYTES('SHA2_256', 'password'), 'Smith', 'John', '2024-10-29');

SELECT * from Employee;

DELETE Movie;

Insert into Movie (MovieName, MovieType, DistributionFee, NumOfCopies, MovieAvailability, Rating)
	Values ('Die Hard', 'Action', '3.89', '7', '1','5');

Insert into Movie (MovieName, MovieType, DistributionFee, NumOfCopies, MovieAvailability, Rating)
	Values ('Die Hard2', 'Action', '3.89', '7', '1','5');

Insert into Movie (MovieName, MovieType, DistributionFee, NumOfCopies, MovieAvailability, Rating)
	Values ('Die Hard3', 'Action', '3.89', '7', '1','5');

Select * from Movie;

DELETE Ordr;
DELETE Customer;

INSERT INTO Customer (CustomerID, LastName, FirstName, Addr, City, Province, PostalCode, EmailAddress, AccountNumber, AccountDateCreation, CreditCardNumber, RentalHistory, Rating)
	VALUES ('0001','Doe', 'John', '12345', 'Edmonton', 'AB', 'T5B1A1', null, '67890', '2024-10-29', '13579', null, '1');

SELECT * from Customer;
SELECT * from Ordr;