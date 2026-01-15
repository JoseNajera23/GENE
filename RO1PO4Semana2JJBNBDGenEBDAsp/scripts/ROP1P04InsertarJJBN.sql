Use GenE
--------Creacion de Insert Camiones
INSERT INTO Camiones(Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,UrlFoto) 
VALUES 
('ZAC-1111', 'Camión 3.5 Ton', 2020, 'Isuzu', 3500, 85420.5, 1, 'img/isuzu.jpg'),
('ZAC-2222', 'Camión Rabón', 2019, 'Kenworth', 8000, 230150.2, 0, 'img/kenworth.jpg'),
('ZAC-3333', 'Camión Torton', 2023, 'Volvo', 18000, 12000.0, 1, 'img/volvo.jpg');
GO

select * from Camiones
----------------------Creacion insert choferes---,

INSERT INTO Choferes(Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,
Licencia,UrlFoto)
VALUES (
    'Eden',
    'Muñoz',
    'López',
    '4921234567',
    '1988-05-12',
    'LIC-987654',
    'img/chofer_eden.jpg'
),(
    'Jesus',
    'Ortiz',
    'Paz',
    '4921474567',
    '1998-06-12',
    'LIC-987654',
    'img/chofer_jop.jpg'
),(
    'Jose',
    'Pérez',
    'Leon',
    '4921897567',
    '2018-09-12',
    'LIC-987654',
    'img/chofer_jose.jpg'
);
GO
select * from Choferes

--Creacion de insertar Rutas
INSERT INTO Ruta
(IDChoferes, IDCamion, Origen, Destino, FechaSalida, FechaLlegada, ATiempo, Distancia)
VALUES
(1, 2, 'Zacatecas', 'Guadalajara',
 '2026-01-08 07:30:00', '2026-01-08 14:45:00', 1, 348.75),

(2, 1, 'Zacatecas', 'Texas',
 '2025-12-12 09:30:00', '2026-01-01 01:45:00', 1, 348.75),

(3, 2, 'Zacatecas', 'Chiapas',
 '2026-01-01 04:30:00', '2026-02-02 23:45:00', 1, 348.75);
GO
SELECT * FROM Ruta

	Use GenE