DROP TABLE Orders
DROP TABLE Stores
DROP TABLE Customers
DROP TABLE OrderDetail
DROP TABLE Inventory
DROP TABLE Products


CREATE TABLE [Customers] (
  [CustomerId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [FirstName] nvarchar(100) NOT NULL,
  [LastName] nvarchar(100) NOT NULL
)
GO

CREATE TABLE [Orders] (
  [CustomerId] int NOT NULL,
  [OrderId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [OrderDate] datetime2 NOT NULL DEFAULT GETDATE(),
  [Total] money NOT NULL,
  [StoreId] int NOT NULL

)
GO

CREATE TABLE [OrderDetail] (
  [OrderDetailId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [ProductId] int NOT NULL,
  [ProductQuant] int NOT NULL,
  [OrderId] int NOT NULL
)
GO

CREATE TABLE [Products] (
  [Name] nvarchar(160) NOT NULL,
  [ProductId] int PRIMARY KEY NOT NULL IDENTITY(1001, 1),
  [Price] money NOT NULL
)
GO

CREATE TABLE [Stores] (
  [StoreId] int PRIMARY KEY NOT NULL IDENTITY(101, 1),
  [City] nvarchar(100) NOT NULL
)
GO

CREATE TABLE [Inventory] (
  [InventoryId] int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [ProductId] int NOT NULL,
  [Quantity] int NOT NULL,
  [StoreId] int NOT NULL
)
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([StoreId]) REFERENCES [Stores] ([StoreId])
GO

ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([StoreId]) REFERENCES [Stores] ([StoreId])
GO
 
ALTER TABLE [OrderDetail] ADD FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId])
GO

