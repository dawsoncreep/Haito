USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarProducto]    Script Date: 23/06/2020 12:27:29 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 27-06-2019
-- Description:	inserta o modifica un registro de productos
-- =============================================
ALTER PROCEDURE [dbo].[InsertarCambiarProducto] 
	-- Add the parameters for the stored procedure here
	@idProducto int = 0, 
	@idEmpresa int = null,
	@nombre nvarchar(max), 
	@eliminar bit,
	@tipoProducto int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @existe int
	set @existe = (select count(*) from producto where active = 1 and idProducto = @idProducto)
	if (@existe > 0 )
	begin 
		if (@eliminar = 1)
		begin
			
			UPDATE [dbo].[producto]
			   SET 
				 active = 0       
			 WHERE idProducto = @idProducto

		end
		else
		begin

			UPDATE [dbo].[producto]
			   SET 
				  [nombre] = @nombre
				  ,[idEmpresa] = @idEmpresa
				  , tipoProducto = @idProducto
			 WHERE idProducto = @idProducto
		 end
	end
	else 
	begin 
INSERT INTO [dbo].[producto]
           ([idProducto]
           ,[nombre]
           ,[idEmpresa]
           ,[active]
		   ,tipoProducto)
     VALUES
           (@idProducto
           ,@nombre
           ,@idEmpresa
           ,1
		   ,@tipoProducto)
	end


END
