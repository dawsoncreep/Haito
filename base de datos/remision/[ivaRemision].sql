USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[ivaCotizacion]    Script Date: 01/10/2019 12:39:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[ivaRemision]
(
	@idRemision int, @idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	declare @iva decimal(10,2)

	set @iva = (select sum (precioUnitario * cantidad)*.16 from remisionDetalle where idRemision = @idRemision and idEncabezado = @idEncabezado)

	return @iva
END
