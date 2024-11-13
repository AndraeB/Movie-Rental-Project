-- Populate the table with test data
DELETE Employee;


INSERT INTO Employee (EmployeeID, SocialInsuranceNumber, Userpass, LastName, FirstName, StartDate)
	VALUES ('001','111222333',HASHBYTES('SHA2_256','password'), 'Smith', 'John', '2024-10-29');

SELECT * from Employee;

DELETE Movie;

Insert into Movie (MovieID, MovieName, MovieType, DistributionFee, NumOfCopies, MovieAvailability, Rating)
	Values ('001', 'Die Hard', 'Action', '3.89', '7', '1','5');

Select * from Movie;