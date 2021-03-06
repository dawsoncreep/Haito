USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[subtotalRemision]    Script Date: 01/10/2019 12:01:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
create FUNCTION [dbo].[subtotalRemision]
(
	@idRemision int, @idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	declare @subtotal decimal(10,2)

	set @subtotal = (select sum (precioUnitario * cantidad) from remisionDetalle 
	where idRemision = @idRemision and idEncabezado = @idEncabezado)

	return @subtotal
END
