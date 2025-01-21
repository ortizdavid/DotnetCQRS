-- DROP AND CREATE DATABASE
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'Dotnet_CQRS')
BEGIN
    ALTER DATABASE Dotnet_CQRS SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Dotnet_CQRS;
END;
GO

CREATE DATABASE Dotnet_CQRS;
GO

USE Dotnet_CQRS;
GO
--

-- Roles
IF OBJECT_ID('Roles', 'U') IS NOT NULL
    DROP TABLE Roles;
GO
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(100) UNIQUE NOT NULL,
    Description VARCHAR(200)
);
GO

-- Users
IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;
GO
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserRole INT NOT NULL, 
    UserName VARCHAR(150) UNIQUE NOT NULL,
    Password VARCHAR(250) NOT NULL,
    Image VARCHAR(100),
    IsActive BIT NOT NULL,
    Token VARCHAR(200) UNIQUE,
    UniqueId UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE(), 
    UpdatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_User_Role FOREIGN KEY (UserRole) REFERENCES Roles(RoleId)
);
GO

-- Suppliers
IF OBJECT_ID('Suppliers', 'U') IS NOT NULL
    DROP TABLE Suppliers;
GO
CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    IdentificationNumber VARCHAR(30) UNIQUE NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    PrimaryPhone VARCHAR(20) UNIQUE NOT NULL,
    SecondaryPhone VARCHAR(20) UNIQUE,
    Address VARCHAR(150),
    UniqueId UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE(), 
    UpdatedAt DATETIME DEFAULT GETDATE(),
);
GO

-- Categories
IF OBJECT_ID('Categories', 'U') IS NOT NULL
    DROP TABLE Categories;
GO
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL,
    Description VARCHAR(150),
    UniqueId UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE(), 
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Products
IF OBJECT_ID('Products', 'U') IS NOT NULL
    DROP TABLE Products;
GO
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,
    ProductName VARCHAR(100) NOT NULL,
    Code VARCHAR(30) UNIQUE NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Description VARCHAR(150),
    UniqueId UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE(), 
    UpdatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT Fk_Categories FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId),
    CONSTRAINT Fk_Suppliers FOREIGN KEY(SupplierId) REFERENCES Suppliers(SupplierId)
);
GO

-- Product Images
IF OBJECT_ID('ProductImages', 'U') IS NOT NULL
    DROP TABLE ProductImages;
GO
CREATE TABLE ProductImages (
    ImageId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    FrontImage VARCHAR(50),
    BackImage VARCHAR(50),
    LeftImage VARCHAR(50),
    RightImage VARCHAR(50),
    UploadDir VARCHAR(50),
    UniqueId UNIQUEIDENTIFIER DEFAULT NEWID(),
    CreatedAt DATETIME DEFAULT GETDATE(), 
    UpdatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT Fk_Products FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
);
GO

-- Views
-- ViewUserData
IF OBJECT_ID('ViewUserData', 'V') IS NOT NULL
    DROP VIEW ViewUserData;
GO
CREATE VIEW ViewUserData AS 
SELECT
    us.UserId, us.UniqueId,
    us.UserName, us.Password,
    us.Image, us.IsActive,
    us.Token, us.CreatedAt,
    us.UpdatedAt,
    ro.RoleId, ro.RoleName
FROM Users us
JOIN Roles ro ON us.UserRole = ro.RoleId;
GO

-- ViewProductData
IF OBJECT_ID('ViewProductData', 'V') IS NOT NULL
    DROP VIEW ViewProductData;
GO
CREATE VIEW ViewProductData AS
SELECT 
    pr.ProductId, pr.UniqueId,
    pr.ProductName, pr.Code,
    pr.UnitPrice, pr.Description,
    pr.CreatedAt, pr.UpdatedAt,
    ca.CategoryId, ca.CategoryName,
    su.SupplierId, su.SupplierName
FROM Products pr
JOIN Categories ca ON ca.CategoryId = pr.CategoryId
JOIN Suppliers su ON su.SupplierId = pr.SupplierId;
GO


-- Inserts
-- Users
INSERT INTO Roles (RoleName, Description) VALUES 
('Administrator', 'Responsible for overall system administration and maintenance.'),
('Customer', 'Regular customer of store.');
GO

