USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarRemison]    Script Date: 01/10/2019 10:41:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las cotizaciones y su detalle tanto para guardar o actualizar
-- =============================================
create PROCEDURE [dbo].[InsertarCambiarRemision] 
	-- Add the parameters for the stored procedure here
	@idRemision int = 0, 
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
	set @existe = (select count (*) from remision where idRemision = @idRemision and idEncabezado = @idEncabezado)
	
	if ( @existe = 0)
	begin 

		INSERT INTO [dbo].remision
				   (idRemision
				   ,[idCliente]
				   ,[fecha]
				   ,[idUsuario]
				   ,[observaciones]
				   ,idEncabezado
				   ,idMoneda)
			 VALUES
				   (@idRemision
				   ,@idCliente
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda)
	end 
	else
	begin 

			UPDATE [dbo].remision
			   SET 
				  idRemision = @idRemision
				  ,[fecha] = @fecha
				  ,[idUsuario] = @idUsuario
				  ,[observaciones] = @observaciones
				  ,idEncabezado = @idEncabezado
				  ,idMoneda = @idMoneda
			 WHERE idRemision = @idRemision

	end
	


END
