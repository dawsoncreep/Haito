USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosOrdenCompra]    Script Date: 23/06/2020 12:55:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 18-06-2019
-- Description:	obtiene los datos de la cotizacion
-- =============================================
ALTER PROCEDURE [dbo].[obtenerDatosOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@idOrdenCompra int = 0,
	@idEncabezado int, 
	@idMoneda int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



    -- Insert statements for procedure here
	SELECT c.*, 
		p.nombre,
		cd.idUnidadMedida,
		cd.cantidad,
		cd.precioUnitario,
		cl.idEmpresa,		
		CONVERT(DECIMAL(10,2), (cd.cantidad*cd.precioUnitario)) as importe  ,
		dbo.subtotalOrdenCompra(c.idOrdenCompra, @idEncabezado) as subtotal,
		dbo.ivaOrdenCompra(c.idOrdenCompra, @idEncabezado) as iva ,
		dbo.totalOrdenCompra(c.idOrdenCompra, @idEncabezado) as total,
		cd.idOrdenCompraDetalle
		 ,dbo.obtenerAtencionDomicilio(c.idProveedor) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
		,[dbo].[CantidadConLetra] (dbo.totalOrdenCompra(c.idOrdenCompra, @idEncabezado), @idMoneda) as cantidadLetra
		,u.firma
		, u.imagenFirma
		, p .idProducto
	from ordenCompra c 
	inner join ordenCompraDetalle cd on c.idOrdenCompra = cd.idOrdenCompra
	inner join clienteProveedor cl on cl.idClienteProveedor = c.idProveedor
	inner join producto p on cd.idProducto = p.idProducto
	inner join usuario u on c.idUsuario = u.idUsuario
	where c.idOrdenCompra = @idOrdenCompra and c.idEncabezado = @idEncabezado and cd.idEncabezado = @idEncabezado

END
