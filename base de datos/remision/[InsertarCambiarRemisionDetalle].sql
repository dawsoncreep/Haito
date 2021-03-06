USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarRemisionDetalle]    Script Date: 01/10/2019 10:42:46 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 01/10/2019
-- Description:	hace el ingreso de las remisiones y su detalle tanto para guardar o actualizar
-- =============================================
create PROCEDURE [dbo].[InsertarCambiarRemisionDetalle]
	-- Add the parameters for the stored procedure here
	@idRemision int = 0, 
	@idProducto int,
	@cantidad decimal(10,2),
	@precioUnitario decimal(10,2),
	@idUnidadMedida nvarchar(10),
	@idEncabezado int,
	@eliminar bit,
	@idRemisionDetalle int = 0
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@eliminar = 1)
	begin 
		delete from remisionDetalle where idRemisionDetalle = @idRemisionDetalle
	end
	else
	begin 

INSERT INTO [dbo].remisionDetalle
           (idRemision
           ,[idProducto]
           ,[cantidad]
           ,[precioUnitario]
           ,[idUnidadMedida]
		   ,idEncabezado)
     VALUES
           (@idRemision
           ,@idProducto
           ,@cantidad
           ,@precioUnitario
           ,@idUnidadMedida
		   ,@idEncabezado)
	end
	


END
