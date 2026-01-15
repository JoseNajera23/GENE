USE GenE;
GO
----Pruebas para que no falle mi base de Datos
SELECT name FROM sys.tables;
--3 Probar LLAVES FORÁNEAS (prueba crítica)
-- Prueba que DEBE fallar

INSERT INTO Ruta
(IDChoferes,IDCamion,Origen,Destino,FechaSalida)
VALUES (999,999,'A','B',GETDATE());

--Prueba que DEBE funcionar
INSERT INTO Ruta
(IDChoferes,IDCamion,Origen,Destino,FechaSalida)
VALUES (1,1,'Zacatecas','Guadalajara',GETDATE());
GO

UPDATE Camiones
SET Kilometraje = Kilometraje + 100
WHERE IDCamion = 1;


-- Fecha llegada antes de salida (no debería permitirse)
INSERT INTO Ruta
(IDChoferes,IDCamion,FechaSalida,FechaLlegada)
VALUES (1,1,'2026-01-10','2026-01-09');

SELECT r.IDRuta, c.Nombre, ca.Matricula, r.Origen, r.Destino
FROM Ruta r
JOIN Choferes c ON r.IDChoferes = c.IDChoferes
JOIN Camiones ca ON r.IDCamion = ca.IDCamion;


RESTORE DATABASE GenE_Test
FROM DISK = 'C:\Respaldos\GenE_Contingencia.bak';



