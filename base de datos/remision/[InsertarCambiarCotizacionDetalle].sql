USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarCotizacionDetalle]    Script Date: 01/10/2019 10:47:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las cotizaciones y su detalle tanto para guardar o actualizar
-- =============================================
ALTER PROCEDURE [dbo].[InsertarCambiarCotizacionDetalle]
	-- Add the parameters for the stored procedure here
	@idCotizacion int = 0, 
	@idProducto int,
	@cantidad decimal(10,2),
	@precioUnitario decimal(10,2),
	@idUnidadMedida nvarchar(10),
	@idEncabezado int,
	@eliminar bit,
	@idCotizacionDetalle int = 0
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@eliminar = 1)
	begin 
		delete from cotizacionDetalle where idCotizacionDetalle = @idCotizacionDEtalle
	end
	else
	begin 

INSERT INTO [dbo].[cotizacionDetalle]
           ([idCotizacion]
           ,[idProducto]
           ,[cantidad]
           ,[precioUnitario]
           ,[idUnidadMedida]
		   ,idEncabezado)
     VALUES
           (@idCotizacion
           ,@idProducto
           ,@cantidad
           ,@precioUnitario
           ,@idUnidadMedida
		   ,@idEncabezado)
	end
	


END
