USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[ivaCotizacion]    Script Date: 23/06/2020 01:06:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[ivaCotizacion]
(
	@idCotizacion int, @idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	declare @subtotalServicio decimal(10,2)
	declare @subtotalProdu decimal(10,2)
	declare @subtotal decimal(10,2)

	set  @subtotal = 0;
	select @subtotalServicio = (select sum (precioUnitario * cantidad) *.06
	from cotizacionDetalle 
	right join producto on cotizacionDetalle.idProducto = producto.idProducto 
	 where idCotizacion =  @idCotizacion and idEncabezado  =@idEncabezado and producto.tipoProducto = 1)
	 select @subtotalProdu  = (select sum (precioUnitario * cantidad) *.16
	from cotizacionDetalle 
	right join producto on cotizacionDetalle.idProducto = producto.idProducto 
	 where idCotizacion =  @idCotizacion and idEncabezado  =@idEncabezado and producto.tipoProducto = 0)

	 select @subtotal = isnull(@subtotalProdu,0) + isnull(@subtotalServicio,0)

	return @subtotal
END
