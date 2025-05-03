-- Create Database 
CREATE DATABASE VeracidataDataBase;
GO

USE VeracidataDataBase;
GO

-- Create Customers Table
CREATE TABLE Customers (
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    NickName NVARCHAR(50) NULL,
    Phone VARCHAR(20) NOT NULL,
    BirthDate DATE NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Active BIT NOT NULL DEFAULT 1
);
GO

-- Stored Procedures

-- Insert Customer
CREATE PROCEDURE usp_InsertCustomer
    @Name NVARCHAR(100),
    @NickName NVARCHAR(50),
    @Phone VARCHAR(20),
    @BirthDate DATE,
    @Email NVARCHAR(100),
    @Password NVARCHAR(255),
    @Active BIT
AS
BEGIN
    INSERT INTO Customers (Name, NickName, Phone, BirthDate, Email, Password, Active)
    VALUES (@Name, @NickName, @Phone, @BirthDate, @Email, @Password, @Active);
    
    SELECT SCOPE_IDENTITY() AS Id;
END
GO

-- Update All Columns by Id
CREATE PROCEDURE usp_UpdateCustomer
    @Id BIGINT,
    @Name NVARCHAR(100),
    @NickName NVARCHAR(50),
    @Phone VARCHAR(20),
    @BirthDate DATE,
    @Email NVARCHAR(100),
    @Password NVARCHAR(255),
    @Active BIT
AS
BEGIN
    UPDATE Customers
    SET Name = @Name,
        NickName = @NickName,
        Phone = @Phone,
        BirthDate = @BirthDate,
        Email = @Email,
        Password = @Password,
        Active = @Active
    WHERE Id = @Id;
END
GO

-- Update Active Status by Id
CREATE PROCEDURE usp_UpdateCustomerActiveStatus
    @Id BIGINT,
    @Active BIT
AS
BEGIN
    UPDATE Customers
    SET Active = @Active
    WHERE Id = @Id;
END
GO

-- Delete Customer by Id
CREATE PROCEDURE usp_DeleteCustomer
    @Id BIGINT
AS
BEGIN
    DELETE FROM Customers
    WHERE Id = @Id;
END
GO

-- Insert Admin User (root)
INSERT INTO Customers (Name, NickName, Phone, BirthDate, Email, Password, Active)
VALUES ('root', 'root', '1234567890', '1900-01-01', 'root@root.com', '$2a$11$mkxrU8UkjANGULHFwrR9VeUDaw6OCgN70qiW/ncGt50K.DqMIrHXi', 1);
GO
