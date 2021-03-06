USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[siguienteFolio]    Script Date: 01/10/2019 12:03:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 29082019
-- Description:	obtiene el siguiente folio para guardarlo si es nuevo
-- =============================================
ALTER FUNCTION [dbo].[siguienteFolio] 
(
	-- Add the parameters for the function here
	@tabla nvarchar(20)
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result int

	-- Add the T-SQL statements to compute the return value here
	IF @tabla = 'cotizacion'
	begin
		SELECT @Result = ( select MAX( idcotizacion )+1 from cotizacion)

	end 
	IF @tabla = 'ordenCompra'
	begin
		SELECT @Result = ( select MAX( idOrdenCompra )+1 from ordenCompra)

	end 

		IF @tabla = 'remision'
	begin
		SELECT @Result = ( select MAX( idRemision)+1 from remision)
		 
	end 

	if @Result = null 
		begin 
			set @Result = 1
		end

	-- Return the result of the function
	RETURN @Result

END
