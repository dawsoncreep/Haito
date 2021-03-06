USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosCotizacion]    Script Date: 30/07/2019 04:10:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 18-06-2019
-- Description:	obtiene los datos de la cotizacion
-- =============================================
ALTER PROCEDURE [dbo].[obtenerDatosCotizacion] 
	-- Add the parameters for the stored procedure here
	@idCotizacion int = 0,
	@idEncabezado int = 0, 
	@idMoneda int = 0
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
		dbo.subtotalCotizacion(c.idCotizacion, @idEncabezado) as subtotal,
		dbo.ivaCotizacion(c.idCotizacion, @idEncabezado) as iva ,
		dbo.totalCotizacion(c.idCotizacion, @idEncabezado) as total,
		cd.idCotizacionDetalle
	   ,dbo.obtenerAtencionDomicilio(c.idCliente) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
	    
		,[dbo].[CantidadConLetra] (dbo.totalCotizacion(c.idCotizacion, @idEncabezado), @idMoneda) as cantidadLetra
	from cotizacion c inner join cotizacionDetalle cd on c.idCotizacion = cd.idCotizacion and c.idEncabezado = @idEncabezado
	inner join clienteProveedor cl on cl.idClienteProveedor = c.idCliente
	inner join producto p on cd.idProducto = p.idProducto
	inner join usuario u on c.idUsuario = u.idUsuario
	where c.idCotizacion = @idCotizacion and cd.idEncabezado = @idEncabezado 

END
