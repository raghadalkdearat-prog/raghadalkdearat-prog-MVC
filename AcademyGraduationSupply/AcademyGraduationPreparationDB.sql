create database AcademyGraduationPreparationDB;
USE AcademyGraduationPreparationDB;
GO
CREATE TABLE Categories
(
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(100) NOT NULL
);


INSERT INTO Categories (CategoryName)
VALUES
('Graduation Certificates'),
('Hospitality'),
('Graduation Gifts');

SELECT * FROM Categories;


CREATE TABLE Suppliers
(
    SupplierId INT PRIMARY KEY IDENTITY(1,1),
    SupplierName VARCHAR(100) NOT NULL
);


INSERT INTO Suppliers (SupplierName)
VALUES
('Supplier A'),
('Supplier B'),
('Supplier C'),
('Supplier D'),
('Supplier E'),
('Supplier F'),
('Supplier G'),
('Supplier H'),
('Supplier I');


SELECT * FROM Suppliers;




ALTER TABLE Suppliers
ADD CategoryId INT;



UPDATE Suppliers
SET CategoryId = 1
WHERE SupplierId IN (1, 2, 3);

UPDATE Suppliers
SET CategoryId = 2
WHERE SupplierId IN (4, 5, 6);

UPDATE Suppliers
SET CategoryId = 3
WHERE SupplierId IN (7, 8, 9);


SELECT * FROM Suppliers;


ALTER TABLE Suppliers
ADD CONSTRAINT FK_Suppliers_Categories
FOREIGN KEY (CategoryId)
REFERENCES Categories(CategoryId);


CREATE TABLE Offers
(
    OfferId INT PRIMARY KEY IDENTITY(1,1),

    OfferName VARCHAR(150) NOT NULL,

    Quantity INT NOT NULL,

    UnitPrice DECIMAL(10,2) NOT NULL,

    SupplierId INT NOT NULL UNIQUE,

    FOREIGN KEY (SupplierId)
    REFERENCES Suppliers(SupplierId)
);



INSERT INTO Offers
(OfferName, Quantity, UnitPrice, SupplierId)
VALUES
('Premium Certificate Package', 35, 2.00, 1),
('Standard Certificate Package', 35, 1.50, 2),
('Luxury Certificate Package', 35, 2.50, 3),

('Coffee & Drinks Package', 100, 2.00, 4),
('Sandwiches & Snacks Package', 100, 3.00, 5),
('Full Hospitality Package', 100, 4.00, 6),

('Customized Mugs Package', 35, 2.00, 7),
('Graduation Bags Package', 35, 3.00, 8),
('Premium Gift Boxes Package', 35, 4.00, 9);