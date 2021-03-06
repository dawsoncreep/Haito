USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarOrdenCompraDetalle]    Script Date: 01/10/2019 10:47:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las orden de compra y su detalle tanto para guardar o actualizar
-- =============================================
ALTER PROCEDURE [dbo].[InsertarCambiarOrdenCompraDetalle]
	-- Add the parameters for the stored procedure here
	@idOrdenCompra int = 0, 
	@idProducto int,
	@cantidad decimal(10,2),
	@precioUnitario decimal(10,2),
	@idUnidadMedida nvarchar(10),
	@eliminar bit,
	@idEncabezado int,
	@idOrdenCompraDetalle int = 0
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if(@eliminar = 1)
	begin 
		delete from ordenCompraDetalle where idOrdenCompraDetalle = @idOrdenCompraDetalle and idEncabezado = @idEncabezado
	end
	else
	begin 

INSERT INTO [dbo].[ordenCompraDetalle]
           ([idOrdenCompra]
           ,[idProducto]
           ,[cantidad]
           ,[precioUnitario]
           ,[idUnidadMedida]
		   ,idEncabezado)
     VALUES
           (@idOrdenCompra
           ,@idProducto
           ,@cantidad
           ,@precioUnitario
           ,@idUnidadMedida
		   ,@idEncabezado)
	end
	


END
