USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[obtenerSigIDRemision]    Script Date: 01/10/2019 12:00:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JaimeCastorena
-- Create date: 01/10/2019
-- Description:	obtiene el ultimo ID de las cotizaciones
-- =============================================
create FUNCTION [dbo].[obtenerSigIDRemision]
(
	@idEncabezado int	
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result int

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = (select max(idRemision)+1 from remision where idEncabezado = @idEncabezado)

	-- Return the result of the function
	if @result is null set @result = 1
	RETURN @Result

END
