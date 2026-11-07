create database CafeteriaDB;

create table Categories(
CategoryId int primary key,
CategoryName varchar(50) not null,
CategoryDescription varchar(150)


);


create table Suppliers(
SupplierId int primary key,
SupplierName varchar(50) not null,
SupplierEmail varchar(150)not null,
SupplierPhone varchar(50)not null


);



create table Products(
ProductId int primary key,
ProductName varchar(50) not null,
ProductPrice decimal(10,2) not null,
Quantity int not null,
CategoryId int   FOREIGN KEY references Categories,
SupplierId int   FOREIGN KEY references Suppliers


);





create table PurchaseOrders(
PurchaseOrderId int primary key,
OrderDate date not null,
[Status] varchar(50) not null,
 SupplierId int   FOREIGN KEY references Suppliers


);



create table PurchaseOrderItems(
PurchaseOrderItemId int primary key,
 Quantity int not null,
UnitPrice decimal(10,2) not null,
PurchaseOrderId int   FOREIGN KEY references PurchaseOrders,
ProductId int  FOREIGN KEY references Products


);






SELECT * FROM Categories;
SELECT * FROM Suppliers;
SELECT * FROM Products;
SELECT * FROM PurchaseOrders;
SELECT * FROM PurchaseOrderItems;




-- Categories
INSERT INTO Categories
VALUES
(1, 'Drinks', 'Cold and hot drinks'),
(2, 'Food', 'Meals and sandwiches'),
(3, 'Snacks', 'Chips and chocolate');


-- Suppliers
INSERT INTO Suppliers
VALUES
(1, 'Fresh Food', 'fresh@gmail.com', '0791111111'),
(2, 'Happy Drinks', 'happy@gmail.com', '0792222222'),
(3, 'Daily Supplies', 'daily@gmail.com', '0793333333');


-- Products
INSERT INTO Products
VALUES
(1, 'Water', 0.50, 100, 1, 2),
(2, 'Sandwich', 2.00, 50, 2, 1),
(3, 'Chocolate', 1.00, 80, 3, 3);


-- PurchaseOrders
INSERT INTO PurchaseOrders
VALUES
(1, '2026-11-01', 'Pending', 1),
(2, '2026-11-02', 'Completed', 2),
(3, '2026-11-03', 'Pending', 3);


-- PurchaseOrderItems
INSERT INTO PurchaseOrderItems
VALUES
(1, 10, 2.00, 1, 2),
(2, 20, 0.50, 2, 1),
(3, 15, 1.00, 3, 3);




SELECT * FROM Categories;
SELECT * FROM Suppliers;
SELECT * FROM Products;
SELECT * FROM PurchaseOrders;
SELECT * FROM PurchaseOrderItems;