select * from stores

--creating all our stores
INSERT INTO Stores (City)
Values ('Phoenix'),
		('Los Angeles'),
		('New York City'),
		('Houston'),
		('Denver')


SELECT * FROM Products

--creating all our products
INSERT INTO Products(Name, Price)
Values ('Red Shirt', 5), 
		('White Shirt', 3),
		('Blue Shirt', 5)



SELECT * FROM Inventory

--creating our inventory for Store# 101
INSERT INTO Inventory(StoreId, ProductId, Quantity)
VALUES (101, 1001, 10),
		(101, 1002, 10),
		(101, 1003, 10)

--creating inventory for Store# 102
INSERT INTO Inventory(StoreId, ProductId, Quantity)
VALUES (102, 1001, 10),
		(102, 1002, 10),
		(102, 1003, 10)

--creating inventory for Store# 103
INSERT INTO Inventory(StoreId, ProductId, Quantity)
VALUES (103, 1001, 10),
		(103, 1002, 10),
		(103, 1003, 10)

--creating inventory for Store# 104
INSERT INTO Inventory(StoreId, ProductId, Quantity)
VALUES (104, 1001, 10),
		(104, 1002, 10),
		(104, 1003, 10)

--creating inventory for Store# 105
INSERT INTO Inventory(StoreId, ProductId, Quantity)
VALUES (105, 1001, 10),
		(105, 1002, 10),
		(105, 1003, 10)


--creating a new customer
INSERT INTO Customers(FirstName, LastName)
VALUES ('Victoria', 'de la Guardia'), ('Gee', 'Sus'), ('John', 'Smith')
	
select * from customers


