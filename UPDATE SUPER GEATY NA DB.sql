Use NSDAP_APPAREL_dB

CREATE TABLE NSDAP_user
(
Customer_ID INT IDENTITY (20163881, 1) NOT NULL,
Name NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Username NVARCHAR(50) PRIMARY KEY NOT NULL,
Contact_Number NVARCHAR(20) NOT NULL,
Address NVARCHAR(100) NOT NULL,
Password NVARCHAR(50) NOT NULL
)

CREATE TABLE Products
(
Product_ID INT IDENTITY(101, 1) PRIMARY KEY NOT NULL,
Name NVARCHAR(50) NOT NULL,
Quantity INT NOT NULL,
Category NVARCHAR(20) NOT NULL,
Size NVARCHAR(5) NOT NULL,
Price DECIMAL(10, 2) NOT NULL,
Image_apparel VARBINARY(MAX)
)

CREATE TABLE Cart
(
Username NVARCHAR(50) FOREIGN KEY REFERENCES NSDAP_user(Username)NOT NULL,
Product_ID INT FOREIGN KEY REFERENCES Products(Product_ID),
Name NVARCHAR(50) NOT NULL,
Quantity INT NOT NULL,
Price DECIMAL(10, 2) NOT NULL
)

CREATE TABLE Orders
(
Order_ID INT IDENTITY(10001, 1) PRIMARY KEY NOT NULL,
Username NVARCHAR(50) FOREIGN KEY REFERENCES NSDAP_user(Username),
Name NVARCHAR(50) NOT NULL,
Quantity INT NOT NULL,
Price DECIMAL(10, 2),
Date_Purchased Datetime
)

