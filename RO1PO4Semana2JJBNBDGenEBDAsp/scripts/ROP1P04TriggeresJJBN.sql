use GenE
--Auditoria Choferes

CREATE TABLE  AuditoriaChoferes(
IDAuditoria INT PRIMARY KEY IDENTITY,
IDChoferes INT,---Llave Foranea
Accion NVARCHAR (50),
Fecha DATETIME DEFAULT GETDATE()
); 
GO

-------Insert Triggres--------
CREATE TRIGGER trg_afterInsert_Choferes
ON Choferes 
AFTER INSERT 
AS BEGIN 
INSERT INTO AuditoriaChoferes(IDChoferes,Accion)
SELECT IDChoferes,'Insertado'
from inserted;
END;


--------UPDATE TRIGGERS------
CREATE TRIGGER trg_AfterUpdate_Choferes
ON Choferes
AFTER UPDATE
AS BEGIN
INSERT INTO AuditoriaChoferes(IDChoferes,Accion)
SELECT IDChoferes,'Actualizado'
FROM inserted
END;

-------Triggers Delete-------
CREATE TRIGGER trg_AfterDelete_Choferes
ON Choferes
AFTER DELETE
AS
BEGIN
    INSERT INTO AuditoriaChoferes (IDChoferes, Accion)
    SELECT IDChoferes, 'Eliminado'
    FROM deleted;
END;
GO
