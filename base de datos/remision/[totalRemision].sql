USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[[totalRemision]]    Script Date: 01/10/2019 12:02:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[totalRemision]
(
	@idRemision int, @idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	declare @total decimal(10,2)

	set @total = (select sum (precioUnitario * cantidad)*.16 + sum (precioUnitario * cantidad) 
	from remisionDetalle where idRemision = @idRemision and idEncabezado = @idEncabezado)

	return @total
END
