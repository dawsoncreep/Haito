USE [Haito]
GO
/****** Object:  StoredProcedure [dbo].[busquedaRemision]    Script Date: 01/10/2019 10:30:00 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 1/10/2019
-- Description:	realizar la busqueda de una remision
-- =============================================
create PROCEDURE [dbo].[busquedaRemision] 
	-- Add the parameters for the stored procedure here
	@buscar nvarchar(500) = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.idRemision, e.nombre as empresa, cl.atencion, r.fecha, 
	case  when r.idEncabezado= 0 then 'IVAN' 
	 when r.idEncabezado= 1 then 'HAITO' end as encabezado
	 ,r.idEncabezado
	from
	remision r
	inner join clienteProveedor cl on cl.idClienteProveedor = r.idCliente
	inner join usuario u on u.idUsuario = r.idUsuario
	inner join empresa e on cl.idEmpresa = e.idEmpresa
	where (
	cl.atencion like ('%' + @buscar +'%')
	or e.nombre like ('%' + @buscar +'%')
	or r.fecha like ('%' + @buscar +'%')
	or u.nombre like ('%' + @buscar +'%')	
	or e.nombre like ('%' + @buscar +'%')
	)

END
