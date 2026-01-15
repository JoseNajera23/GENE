CREATE DATABASE GenE;
Use GenE

--Creacion Tabla Camiones 
Create Table Camiones(
IDCamion INT PRIMARY KEY IDENTITY(1,1),
Matricula NVARCHAR(100),
TipoCamion NVARCHAR(50),
Modelo INT,
Marca NVARCHAR (50),
Capacidad INT,
Kilometraje DECIMAL(10,2),
Disponibilidad BIT,
UrlFoto NVARCHAR (100),
FechaRegistro DATETIME DEFAULT GETDATE()
)
;
GO
SELECT * FROM Camiones



------Cretacion de Choferes-------
CREATE TABLE Choferes(
IDChoferes INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(100),
ApPaterno NVARCHAR(100),
ApMaterno NVARCHAR(100),
Telefono NVARCHAR(50),
FechaNacimiento DATE,
Licencia NVARCHAR(50),
UrlFoto NVARCHAR(50),
Disponibilidad BIT,
FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

SELECT * FROM Choferes

----Creacion de Tabla Ruta-----
CREATE TABLE Ruta(
IDRuta INT PRIMARY KEY IDENTITY(1,1),
IDChoferes INT,
IDCamion INT,
Origen NVARCHAR(50),
Destino NVARCHAR (50),
FechaSalida DATETIME,
FechaLlegada DATETIME,
ATiempo BIT,
Distancia FLOAT,
FechaRegistro DATETIME DEFAULT GETDATE()

CONSTRAINT  FK_Ruta_Choferes
FOREIGN KEY (IDChoferes) REFERENCES Choferes(IDChoferes),

CONSTRAINT FK_Ruta_Camion
FOREIGN KEY (IDCamion) REFERENCES Camiones (IDCamion) 
);

GO
SELECT * FROM Choferes

--Auditoria Choferes

CREATE TABLE  AuditoriaChoferes(
IDAuditoria INT PRIMARY KEY IDENTITY(1,1),
IDChoferes INT,---Llave Foranea
Accion NVARCHAR (50),
Fecha DATETIME DEFAULT GETDATE(),

CONSTRAINT FK_Auditoria_Choferes
FOREIGN KEY (IDChoferes)REFERENCES Choferes(IDChoferes)
); 
GO

select * from AuditoriaChoferes