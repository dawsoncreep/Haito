USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarOrdenCompra]    Script Date: 30/07/2019 04:45:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las orden de compra y su detalle tanto para guardar o actualizar
-- =============================================
ALTER PROCEDURE [dbo].[InsertarCambiarOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@idOrdenCompra int = 0, 
	@idProveedor int = 0,
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
	set @existe = (select count (*) from ordenCompra where idOrdenCompra = @idOrdenCompra and idEncabezado = @idEncabezado)
	
	if ( @existe = 0)
	begin 
INSERT INTO [dbo].[ordenCompra]
           ([idOrdenCompra]
           ,[idProveedor]
           ,[fecha]
           ,[idUsuario]
           ,[observaciones],
		    idEncabezado
			,idMoneda)
   
			 VALUES
				   (@idOrdenCompra
				   ,@idProveedor
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda)
	end 
	else
	begin 

			UPDATE [dbo].ordenCompra
			   SET 
				  [idProveedor] = @idProveedor
				  ,[fecha] = @fecha
				  ,[idUsuario] = @idUsuario
				  ,[observaciones] = @observaciones
				  ,idMoneda = @idMoneda
			 WHERE idOrdenCompra = @idOrdenCompra and idEncabezado = @idEncabezado

	end
	


END
