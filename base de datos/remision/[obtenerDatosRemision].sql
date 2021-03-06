USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosRemision]    Script Date: 01/10/2019 10:48:34 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 01/10/2019
-- Description:	obtiene los datos de la remision
-- =============================================
alter PROCEDURE [dbo].[obtenerDatosRemision] 
	-- Add the parameters for the stored procedure here
	@idRemision int = 0,
	@idEncabezado int = 0, 
	@idMoneda int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.*, 
		p.nombre,
		rd.idUnidadMedida,
		rd.cantidad,
		rd.precioUnitario,
		cl.idEmpresa,		
		 CONVERT(DECIMAL(10,2), (rd.cantidad*rd.precioUnitario)) as importe  ,
		dbo.subtotalRemision(r.idRemision, @idEncabezado) as subtotal,
		dbo.ivaRemision(r.idRemision, @idEncabezado) as iva ,
		dbo.totalRemision(r.idRemision, @idEncabezado) as total,
		rd.idRemisionDetalle
	   ,dbo.obtenerAtencionDomicilio(r.idCliente) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
		,u.firma	    
		,[dbo].[CantidadConLetra] (dbo.totalRemision(r.idRemision, @idEncabezado), @idMoneda) as cantidadLetra

	from remision r inner join remisionDetalle rd on r.idRemision = rd.idRemision and r.idEncabezado = @idEncabezado
	inner join clienteProveedor cl on cl.idClienteProveedor = r.idCliente
	inner join producto p on rd.idProducto = p.idProducto
	inner join usuario u on r.idUsuario = u.idUsuario
	where r.idRemision = @idRemision and rd.idEncabezado = @idEncabezado 

END
