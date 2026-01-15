-- =========================================================
-- CREAR BASE DE DATOS
-- =========================================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Panaderia')
BEGIN
    CREATE DATABASE Panaderia;
END
GO

USE Panaderia;
GO

-- =====================================================================
-- Author:      Jose Juan Basurto Najera
-- Create date: 06/01/2026
-- Description: Se crea base de datos y tablas para proyecto Panaderia
-- JJBN20250103: Liberación BD
-- =====================================================================


-- =========================================================
-- TABLA PRODUCTOS
-- =========================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Productos')
BEGIN
    CREATE TABLE Productos (
        ProductoID INT PRIMARY KEY IDENTITY(1,1),
        NombreProducto NVARCHAR(50) NOT NULL,
        TipoProducto NVARCHAR(20) NOT NULL
    );
END
GO

-- INSERT PRODUCTOS
INSERT INTO Productos (NombreProducto, TipoProducto)
VALUES ('Bolillo','Pan');
GO


-- =========================================================
-- TABLA PANADERO
-- =========================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Panadero')
BEGIN
    CREATE TABLE Panadero (
        EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
        ProductoID INT FOREIGN KEY REFERENCES Productos(ProductoID),
        Nombre NVARCHAR(100) NOT NULL,
        Ocupacion NVARCHAR(50) NOT NULL,
        TipoPan NVARCHAR(50) NOT NULL,
        Cantidad INT NOT NULL,
        Stock INT NOT NULL
    );
END
GO

-- INSERT PANADERO
INSERT INTO Panadero (ProductoID, Nombre, Ocupacion, TipoPan, Cantidad, Stock)
VALUES (1, 'Jose Perez Leon', 'Panadero', 'Bolillo', 50, 100);
GO


-- =========================================================
-- TABLA GALLETERO
-- =========================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Galletero')
BEGIN
    CREATE TABLE Galletero (
        EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
        ProductoID INT FOREIGN KEY REFERENCES Productos(ProductoID),
        Nombre NVARCHAR(100) NOT NULL,
        Ocupacion NVARCHAR(50) NOT NULL,
        TipoGalleta NVARCHAR(50) NOT NULL,
        Cantidad INT NOT NULL,
        Stock INT NOT NULL
    );
END
GO

-- INSERT GALLETERO
INSERT INTO Galletero (ProductoID, Nombre, Ocupacion, TipoGalleta, Cantidad, Stock)
VALUES (1, 'Luis Hernandez Leon', 'Galletero', 'Marinelas', 50, 100);
GO


-- =========================================================
-- TABLA VENTAS
-- =========================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Ventas')
BEGIN
    CREATE TABLE Ventas (
        VentaID INT PRIMARY KEY IDENTITY(1,1),
        ProductoID INT FOREIGN KEY REFERENCES Productos(ProductoID),
        Cantidad INT NOT NULL,
        Precio DECIMAL(10,2) NOT NULL,
        Fecha DATETIME DEFAULT GETDATE()
    );
END
GO

-- INSERT VENTAS
INSERT INTO Ventas (ProductoID, Cantidad, Precio)
VALUES (1, 20, 10.00);
GO


-- =========================================================
-- TABLA VENTAS DIARIAS
-- =========================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ventasDiarias')
BEGIN
    CREATE TABLE ventasDiarias (
        VentaDiariaID INT PRIMARY KEY IDENTITY(1,1),
        VentaID INT FOREIGN KEY REFERENCES Ventas(VentaID),
        Fecha DATE NOT NULL,
        Total DECIMAL(10,2) NOT NULL
    );
END
GO


-- =========================================================
-- CONSULTAS
-- =========================================================
SELECT * FROM Productos;
SELECT * FROM Panadero;
SELECT * FROM Galletero;
SELECT * FROM Ventas;
SELECT * FROM ventasDiarias;
GO

CREATE VIEW VistaPanaderia_LeftJoin AS
SELECT
    p.ProductoID,
    p.NombreProducto,
    p.TipoProducto,

    pa.Nombre AS NombrePanadero,
    pa.TipoPan,

    ga.Nombre AS NombreGalletero,
    ga.TipoGalleta,

    COUNT(v.VentaID) AS TotalVentas,
    ISNULL(SUM(v.Cantidad),0) AS CantidadVendida,
    ISNULL(SUM(v.Cantidad * v.Precio),0) AS MontoTotal,
    MAX(v.Fecha) AS UltimaVenta

FROM Productos p
LEFT JOIN Panadero pa 
    ON p.ProductoID = pa.ProductoID
LEFT JOIN Galletero ga 
    ON p.ProductoID = ga.ProductoID
LEFT JOIN Ventas v 
    ON p.ProductoID = v.ProductoID

GROUP BY
    p.ProductoID,
    p.NombreProducto,
    p.TipoProducto,
    pa.Nombre,
    pa.TipoPan,
    ga.Nombre,
    ga.TipoGalleta;
GO


--Procedure

