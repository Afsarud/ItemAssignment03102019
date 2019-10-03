
CREATE DATABASE CoffeeShopAssignmentUI

CREATE TABLE Items(
ID INT IDENTITY(1,1) ,
Name VARCHAR(50),
Price FLOAT
)

INSERT INTO Items (Name, Price) Values ('Black', 120)
INSERT INTO Items (Name, Price) Values ('Regular', 80)
INSERT INTO Items (Name, Price) Values ('Cold', 100)
INSERT INTO Items (Name, Price) Values ('Hot', 90)

CREATE TABLE Customers
(
Id INT IDENTITY(1,1),
Name VARCHAR(50),
[Address] VARCHAR(200),
Contact VARCHAR(50),
)

INSERT INTO Customers VALUES ('Ali', 'Dhaka' ,'01311369369')
INSERT INTO Customers VALUES ('Hasan', 'Sylhet' ,'01711369369')
INSERT INTO Customers VALUES ('Rafi', 'BNorisal' ,'01811369369')

SELECT * FROM Items
SELECT * FROM Customers

CREATE TABLE Orders
(
Id INT IDENTITY(1,1),
CustomerId INT,
ItemId INT ,
Quantity INT,
TotalPrice FLOAT
)

INSERT INTO Orders VALUES (1, 1 , 5, 600)
INSERT INTO Orders VALUES (1, 2 , 3, 240)
INSERT INTO Orders VALUES (1, 3 , 2, 200)

INSERT INTO Orders VALUES (2, 2 , 2, 160)
INSERT INTO Orders VALUES (2, 3 , 3, 300)
INSERT INTO Orders VALUES (2, 4 , 4, 400)

SELECT c.Name as Customer ,i.Name as Item, Quantity,TotalPrice FROM
o. Orders AS 