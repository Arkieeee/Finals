CREATE DATABASE NSDAP_APPAREL_dB

USE NSDAP_APPAREL_db

CREATE TABLE NSDAP_user
(
Customer_ID int IDENTITY(1011,1) PRIMARY KEY,
Name nvarchar(50) NOT NULL,
Email nvarchar(50)NOT NULL,
Username nvarchar(50)NOT NULL,
Contact_Number int NOT NULL,
Address nvarchar(50) NOT NULL,
Password nvarchar(50) NOT NULL,
)
SELECT * FROM NSDAP_user

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
	Quantity int NOT NULL,
    Description NVARCHAR(100) NOT NULL,
	Size nvarchar(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
);

CREATE TABLE Orders (
    OrderID int IDENTITY(3011,1) PRIMARY KEY,
    Customer_ID INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES NSDAP_user(Customer_ID)
);


CREATE TABLE Transactions (
    TransactionID INT IDENTITY(7001,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductName NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL,
    Size NVARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    PurchaseDate DATETIME NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);



