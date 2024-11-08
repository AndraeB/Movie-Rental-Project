-- create TutorialDB database it not exist
-- IF NOT EXISTS ( SELECT name FROM sys.databases WHERE name = N'MovieRental' ) CREATE DATABASE [MovieRental]; 
-- Go

USE MovieRental;

-- Dropping tables if they already exist to avoid conflicts
DROP TABLE IF EXISTS Cust_Phone;
DROP TABLE IF EXISTS Emp_Phone;
DROP TABLE IF EXISTS Movie_Rating;
DROP TABLE IF EXISTS Actor_Rating;
DROP TABLE IF EXISTS Ordr;
DROP TABLE IF EXISTS Movie;
DROP TABLE IF EXISTS Actor;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Employee;

-- Creating Movie table
CREATE TABLE Movie (
    MovieID nchar(4) PRIMARY KEY,
    MovieName nchar(30),
    MovieType nchar(20),
    DistributionFee int,
    NumOfCopies int,
    Rating int,
);

-- Creating Actor table
CREATE TABLE Actor (
    ActorID nchar(4) PRIMARY KEY,
    LastName nchar(30),
    FirstName nchar(30),
    Gender nchar(10),
    DateOfBirth date,
    Age int,
    Rating int
);

-- Creating Customer table
CREATE TABLE Customer (
    CustomerID nchar(4) PRIMARY KEY,
    LastName nchar(30),
    FirstName nchar(30),
    Address nchar(50),
    City nchar(20),
    State nchar(2),
    ZipCode nchar(10),
    EmailAddress nchar(50),
    AccountNumber nchar(20),
    AccountDateCreation date,
    CreditCardNumber nchar(16),
    RentalHistory nchar(50),
    Rating int
);

-- Creating Employee table
CREATE TABLE Employee (
    EmployeeID nchar(4) PRIMARY KEY,
    SocialSecurityNumber nchar(11),
    LastName nchar(30),
    FirstName nchar(30),
    Address nchar(50),
    City nchar(20),
    State nchar(2),
    ZipCode nchar(10),
    StartDate date
);

-- Creating Cust_Phone table for customer phone numbers
CREATE TABLE Cust_Phone (
    CustomerID nchar(4) FOREIGN KEY REFERENCES Customer(CustomerID),
    PhoneNumber nchar(15),
    PRIMARY KEY (CustomerID, PhoneNumber)
);

-- Creating Emp_Phone table for employee phone numbers
CREATE TABLE Emp_Phone (
    EmployeeID nchar(4) FOREIGN KEY REFERENCES Employee(EmployeeID),
    PhoneNumber nchar(15),
    PRIMARY KEY (EmployeeID, PhoneNumber)
);

-- Creating Order table
CREATE TABLE Ordr (
    OrderID nchar(4) PRIMARY KEY,
    CheckoutDateTime datetime,
    ReturnDateTime datetime,
    CustomerID nchar(4) FOREIGN KEY REFERENCES Customer(CustomerID),
    EmployeeID nchar(4) FOREIGN KEY REFERENCES Employee(EmployeeID)
);

-- Creating Movie_Rating table to rate movies by customers
CREATE TABLE Movie_Rating (
    RatingID nchar(4) PRIMARY KEY,
    OrderID nchar(4) FOREIGN KEY REFERENCES Ordr(OrderID),
    MovieID nchar(4) FOREIGN KEY REFERENCES Movie(MovieID),
    Rating int
);

-- Creating Actor_Rating table to rate actors by customers
CREATE TABLE Actor_Rating (
    RatingID nchar(4) PRIMARY KEY,
    OrderID nchar(4) FOREIGN KEY REFERENCES Ordr(OrderID),
    ActorID nchar(4) FOREIGN KEY REFERENCES Actor(ActorID),
    Rating int
);

select * from Actor
select * from Actor_Rating
select * from Cust_Phone
select * from Customer
select * from Emp_Phone
select * from Employee
select * from Movie
select * from Movie_Rating
select * from Ordr