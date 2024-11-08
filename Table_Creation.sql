-- Create TutorialDB database if it does not already exist
-- IF NOT EXISTS ( SELECT name FROM sys.databases WHERE name = N'MovieRental' ) CREATE DATABASE [MovieRental]; 
-- Go

USE MovieRental;

-- Dropping sequence and tables if they already exist to avoid conflicts
DROP SEQUENCE IF EXISTS MovieIDSeq;

DROP TABLE IF EXISTS Queue_up;
DROP TABLE IF EXISTS Appears_in;
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
    MovieID nchar(4) PRIMARY KEY NOT NULL,
    MovieName varchar(30) NOT NULL,
    MovieType nchar(20) NOT NULL,
    DistributionFee float NOT NULL,
    NumOfCopies int NOT NULL,
    MovieAvailability bit NOT NULL DEFAULT 0,
    Rating int NOT NULL,
);

CREATE SEQUENCE MovieIDSeq START WITH 1000 INCREMENT BY 1;

-- Creating Actor table
CREATE TABLE Actor (
    ActorID nchar(4) PRIMARY KEY NOT NULL,
    LastName varchar(30) NOT NULL,
    FirstName varchar(30) NOT NULL,
    Gender nchar(1) NOT NULL CHECK( Gender='M' or Gender='F' ),
    DateOfBirth date NOT NULL,
    Age int NOT NULL,
    Rating int
);

-- Creating Customer table
CREATE TABLE Customer (
    CustomerID nchar(4) PRIMARY KEY NOT NULL,
    LastName varchar(30) NOT NULL,
    FirstName varchar(30) NOT NULL,
    Addr varchar(50) NOT NULL,
    City varchar(20) NOT NULL,
    Province nchar(2) NOT NULL,
    PostalCode nchar(6) NOT NULL,
    EmailAddress varchar(50),
    AccountNumber nchar(20) NOT NULL,
    AccountDateCreation date NOT NULL,
    CreditCardNumber nchar(16) NOT NULL,
    RentalHistory nchar(50),          -- Should this be a varchar?
    Rating int NOT NULL
);

-- Creating Employee table
CREATE TABLE Employee (
    EmployeeID nchar(4) PRIMARY KEY NOT NULL,
    SocialInsuranceNumber nchar(9) NOT NULL,
	Userpass varbinary(32) NOT NULL,
    LastName varchar(30) NOT NULL,
    FirstName varchar(30) NOT NULL,
    Addr varchar(50),
    City varchar(20),
    Province nchar(2),
    PostalCode nchar(2),
    StartDate date NOT NULL
);

-- Creating Cust_Phone table for customer phone numbers
CREATE TABLE Cust_Phone (
    CustomerID nchar(4) FOREIGN KEY REFERENCES Customer(CustomerID) NOT NULL,
    PhoneNumber nchar(15) NOT NULL,
    PRIMARY KEY (CustomerID, PhoneNumber)
);

-- Creating Emp_Phone table for employee phone numbers
CREATE TABLE Emp_Phone (
    EmployeeID nchar(4) FOREIGN KEY REFERENCES Employee(EmployeeID) NOT NULL,
    PhoneNumber nchar(15) NOT NULL,
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

--Generate for Appears_in
CREATE TABLE Appears_in (
    MovieID nchar(4) FOREIGN KEY REFERENCES Movie(MovieID),
    ActorID nchar(4) FOREIGN KEY REFERENCES Actor(ActorID),
);

CREATE TABLE Queue_up (
    MovieID nchar(4) FOREIGN KEY REFERENCES Movie(MovieID),
    CustomerID nchar(4) FOREIGN KEY REFERENCES Customer(CustomerID),
	Date_added datetime,
);

select * from Queue_up
select * from Appears_in
select * from Actor
select * from Actor_Rating
select * from Cust_Phone
select * from Customer
select * from Emp_Phone
select * from Employee
select * from Movie
select * from Movie_Rating
select * from Ordr
