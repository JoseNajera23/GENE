CREATE PROCEDURE InsertaVenta
@ProductoID INT,
@Cantidad INT,
@Precio DECIMAL(10,2),
@NuevaVentaID INT OUTPUT
AS 
BEGIN
SET NOCOUNT ON;

 INSERT INTO Ventas (ProductoID, Cantidad, Precio, Fecha)
    VALUES (@ProductoID, @Cantidad, @Precio, GETDATE());

	---Obtener el id recien creado
	SET @NuevaVentaID = SCOPE_IDENTITY();
	SELECT @NuevaVentaID AS VentaCreada;
	END;
	GO