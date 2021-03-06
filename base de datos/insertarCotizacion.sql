USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarCotizacion]    Script Date: 30/07/2019 04:45:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las cotizaciones y su detalle tanto para guardar o actualizar
-- =============================================
ALTER PROCEDURE [dbo].[InsertarCambiarCotizacion] 
	-- Add the parameters for the stored procedure here
	@idCotizacion int = 0, 
	@idCliente int = 0,
	@fecha datetime,
	@idUsuario int,
	@observaciones nvarchar(500),
	@idEncabezado int,
	@idMoneda int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @existe int
	set @existe = (select count (*) from cotizacion where idCotizacion = @idCotizacion and idEncabezado = @idEncabezado)
	
	if ( @existe = 0)
	begin 

		INSERT INTO [dbo].[cotizacion]
				   ([idCotizacion]
				   ,[idCliente]
				   ,[fecha]
				   ,[idUsuario]
				   ,[observaciones]
				   ,idEncabezado
				   ,idMoneda)
			 VALUES
				   (@idCotizacion
				   ,@idCliente
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda)
	end 
	else
	begin 

			UPDATE [dbo].[cotizacion]
			   SET 
				  [idCliente] = @idCliente
				  ,[fecha] = @fecha
				  ,[idUsuario] = @idUsuario
				  ,[observaciones] = @observaciones
				  ,idEncabezado = @idEncabezado
				  ,idMoneda = @idMoneda
			 WHERE [idCotizacion] = @idCotizacion

	end
	


END
