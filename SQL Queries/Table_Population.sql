USE MovieRental;

-- Clear existing data (in correct order due to foreign key constraints)
DELETE FROM Queue_up;
DELETE FROM Appears_in;
DELETE FROM Movie_Rating;
DELETE FROM Actor_Rating;
DELETE FROM Ordr;
DELETE FROM Employee;
DELETE FROM Cust_Phone;
DELETE FROM Customer;
DELETE FROM Movie;
DELETE FROM Actor;

-- Populate Employee table
INSERT INTO Employee (EmployeeID, SocialInsuranceNumber, Userpass, LastName, FirstName, StartDate)
VALUES 
    ('001', '111222333', HASHBYTES('SHA2_256', 'password'), 'Smith', 'John', '2024-01-01'),
    ('002', '444555666', HASHBYTES('SHA2_256', 'password'), 'Johnson', 'Sarah', '2024-02-15'),
    ('003', '777888999', HASHBYTES('SHA2_256', 'password'), 'Williams', 'Mike', '2024-03-01');

-- Populate Movie table with various genres and prices
INSERT INTO Movie (MovieName, MovieType, DistributionFee, NumOfCopies, MovieAvailability, Rating)
VALUES 
    ('Die Hard', 'Action', 3.89, 7, 1, 5),
    ('Die Hard 2', 'Action', 3.89, 5, 1, 4),
    ('Die Hard 3', 'Action', 3.89, 4, 1, 4),
    ('The Notebook', 'Romance', 2.99, 0, 0, 4),
    ('Inception', 'Sci-Fi', 4.99, 6, 1, 5),
    ('The Godfather', 'Drama', 4.99, 4, 1, 5),
    ('Toy Story', 'Animation', 2.99, 5, 1, 5),
    ('The Shining', 'Horror', 3.99, 3, 1, 4),
    ('Jurassic Park', 'Action', 4.99, 5, 1, 5),
    ('Titanic', 'Drama', 3.99, 4, 1, 4);

-- Store MovieIDs for reference
DECLARE @DieHard int, @DieHard2 int, @DieHard3 int, @Notebook int, @Inception int;
DECLARE @Godfather int, @ToyStory int, @Shining int, @JurassicPark int, @Titanic int;

SELECT @DieHard = MovieID FROM Movie WHERE MovieName = 'Die Hard';
SELECT @DieHard2 = MovieID FROM Movie WHERE MovieName = 'Die Hard 2';
SELECT @DieHard3 = MovieID FROM Movie WHERE MovieName = 'Die Hard 3';
SELECT @Notebook = MovieID FROM Movie WHERE MovieName = 'The Notebook';
SELECT @Inception = MovieID FROM Movie WHERE MovieName = 'Inception';
SELECT @Godfather = MovieID FROM Movie WHERE MovieName = 'The Godfather';
SELECT @ToyStory = MovieID FROM Movie WHERE MovieName = 'Toy Story';
SELECT @Shining = MovieID FROM Movie WHERE MovieName = 'The Shining';
SELECT @JurassicPark = MovieID FROM Movie WHERE MovieName = 'Jurassic Park';
SELECT @Titanic = MovieID FROM Movie WHERE MovieName = 'Titanic';

-- Populate Customer table
INSERT INTO Customer (LastName, FirstName, Addr, City, Province, PostalCode, EmailAddress, AccountNumber, AccountDateCreation, CreditCardNumber, RentalHistory, Rating)
VALUES 
    ('Doe', 'John', '12345 Main St', 'Edmonton', 'AB', 'T5B1A1', 'john@email.com', '67890', '2024-01-01', '1111222233334444', null, 4),
    ('Smith', 'Jane', '67890 Oak Rd', 'Calgary', 'AB', 'T2P2G3', 'jane@email.com', '12345', '2024-01-15', '2222333344445555', null, 5),
    ('Brown', 'Mike', '13579 Pine Ave', 'Edmonton', 'AB', 'T6C3M2', 'mike@email.com', '24680', '2024-02-01', '3333444455556666', null, 3);

-- Populate Actor table
INSERT INTO Actor (ActorID, LastName, FirstName, Gender, DateOfBirth, Age, Rating)
VALUES
    ('001', 'Willis', 'Bruce', 'M', '1955-03-19', 69, 5),
    ('002', 'Rickman', 'Alan', 'M', '1946-02-21', 69, 5),
    ('003', 'DiCaprio', 'Leonardo', 'M', '1974-11-11', 49, 5),
    ('004', 'Hanks', 'Tom', 'M', '1956-07-09', 67, 5),
    ('005', 'Streep', 'Meryl', 'F', '1949-06-22', 74, 5),
    ('006', 'Roberts', 'Julia', 'F', '1967-10-28', 56, 4);

-- Populate Appears_in table using the stored MovieIDs
INSERT INTO Appears_in (MovieID, ActorID)
VALUES
    (@DieHard, '001'),    -- Bruce Willis in Die Hard
    (@DieHard, '002'),    -- Alan Rickman in Die Hard
    (@DieHard2, '001'),   -- Bruce Willis in Die Hard 2
    (@DieHard3, '001'),   -- Bruce Willis in Die Hard 3
    (@Inception, '003'),  -- DiCaprio in Inception
    (@ToyStory, '004'),   -- Tom Hanks in Toy Story
    (@Titanic, '003'),    -- DiCaprio in Titanic
    (@Titanic, '005');    -- Meryl Streep in Titanic

-- Populate Orders with various dates for time-based analysis
INSERT INTO Ordr (CheckoutDateTime, ReturnDateTime, MovieName, CustomerID, EmployeeID)
VALUES 
    ('2024-01-15', '2024-01-18', 'Die Hard', '10000', '001'),
    ('2024-01-20', '2024-01-23', 'Inception', '10001', '001'),
    ('2024-02-01', '2024-02-04', 'Toy Story', '10002', '002'),
    ('2024-02-15', '2024-02-18', 'Die Hard', '10001', '002'),
    ('2024-03-01', '2024-03-04', 'The Godfather', '10000', '003'),
    ('2024-03-15', '2024-03-18', 'Jurassic Park', '10002', '001'),
    ('2024-03-20', '2024-03-23', 'Die Hard 2', '10000', '002');

-- Store OrderIDs for reference
DECLARE @Order1 int, @Order2 int, @Order3 int, @Order4 int, @Order5 int, @Order6 int, @Order7 int;

SELECT @Order1 = OrderID FROM Ordr WHERE CustomerID = '10000' AND MovieName = 'Die Hard';
SELECT @Order2 = OrderID FROM Ordr WHERE CustomerID = '10001' AND MovieName = 'Inception';
SELECT @Order3 = OrderID FROM Ordr WHERE CustomerID = '10002' AND MovieName = 'Toy Story';
SELECT @Order4 = OrderID FROM Ordr WHERE CustomerID = '10001' AND MovieName = 'Die Hard';
SELECT @Order5 = OrderID FROM Ordr WHERE CustomerID = '10000' AND MovieName = 'The Godfather';
SELECT @Order6 = OrderID FROM Ordr WHERE CustomerID = '10002' AND MovieName = 'Jurassic Park';
SELECT @Order7 = OrderID FROM Ordr WHERE CustomerID = '10000' AND MovieName = 'Die Hard 2';

-- Populate Movie_Rating table using stored OrderIDs and MovieIDs
INSERT INTO Movie_Rating (RatingID, OrderID, MovieID, Rating)
VALUES
    ('MR01', @Order1, @DieHard, 5),      -- Die Hard rating
    ('MR02', @Order2, @Inception, 5),     -- Inception rating
    ('MR03', @Order3, @ToyStory, 4),      -- Toy Story rating
    ('MR04', @Order4, @DieHard, 5),      -- Die Hard rating
    ('MR05', @Order5, @Godfather, 5),     -- Godfather rating
    ('MR06', @Order6, @JurassicPark, 4);  -- Jurassic Park rating

-- Populate Actor_Rating table using stored OrderIDs
INSERT INTO Actor_Rating (RatingID, OrderID, ActorID, Rating)
VALUES
    ('AR01', @Order1, '001', 5),  -- Bruce Willis rating
    ('AR02', @Order2, '003', 5),  -- DiCaprio rating
    ('AR03', @Order3, '004', 5),  -- Tom Hanks rating
    ('AR04', @Order4, '001', 4),  -- Bruce Willis rating
    ('AR05', @Order6, '003', 5);  -- DiCaprio rating

-- Populate Queue_up table using stored MovieIDs
INSERT INTO Queue_up (MovieID, CustomerID, Date_added)
VALUES
    (@Notebook, '10000', '2024-03-25'),     -- Customer waiting for The Notebook
    (@Shining, '10001', '2024-03-24'),      -- Customer waiting for The Shining
    (@Godfather, '10000', '2024-03-25'),     -- Customer waiting for The Godfather
    (@Inception, '10002', '2024-03-23');    -- Customer waiting for Inception

INSERT INTO Cust_Phone (CustomerID, PhoneNumber)
VALUES
	('10000', '1357924680'),
	('10001', '1234567890'),
	('10002', '0987654321');

-- Verify data was inserted properly
SELECT 'Movies' as TableName, COUNT(*) as Count FROM Movie
UNION ALL
SELECT 'Actors', COUNT(*) FROM Actor
UNION ALL
SELECT 'Customers', COUNT(*) FROM Customer
UNION ALL
SELECT 'Orders', COUNT(*) FROM Ordr
UNION ALL
SELECT 'Movie Ratings', COUNT(*) FROM Movie_Rating
UNION ALL
SELECT 'Actor Ratings', COUNT(*) FROM Actor_Rating
UNION ALL
SELECT 'Queue Entries', COUNT(*) FROM Queue_up;