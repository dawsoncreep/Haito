USE [Haito]
GO
/****** Object:  UserDefinedFunction [dbo].[calculaIVA]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 24 julio 2020
-- Description:	obtiene el IVA por id y tipo
-- =============================================
CREATE FUNCTION [dbo].[calculaIVA] 
(
	-- Add the parameters for the function here
	@id int, 
	@tipoDato int, --1 cotizacion, --2 orden compra, --3 remision
	@idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(10,2)

	DECLARE @IVA decimal(3,2) 
	set @IVA =  convert(decimal(3,2),(select valor from parametro where nombre = 'IVA'))

IF @tipoDato = 1 --cotizacion
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@IVA)
	from cotizacionDetalle 
	right join producto on cotizacionDetalle.idProducto = producto.idProducto 
	 where idCotizacion =  @id and idEncabezado  =@idEncabezado)

END
ELSE
IF @tipoDato = 2 --orden compra
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@IVA)
	from ordenCompraDetalle 
	right join producto on ordenCompraDetalle.idProducto = producto.idProducto 
	 where idOrdenCompra =  @id and idEncabezado  =@idEncabezado)
END
ELSE
IF @tipoDato = 3 -- remision
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@IVA)
	from remisionDetalle 
	right join producto on remisionDetalle.idProducto = producto.idProducto 
	 where idRemision =  @id and idEncabezado  =@idEncabezado)
END

	-- Return the result of the function
	RETURN @Result

END

GO
/****** Object:  UserDefinedFunction [dbo].[calculaRetencion]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 24 julio 2020
-- Description:	obtiene la retencion si aplica por id y tipo
-- =============================================
CREATE FUNCTION [dbo].[calculaRetencion]
(
	-- Add the parameters for the function here
	@id int, 
	@tipoDato int, --1 cotizacion, --2 orden compra, --3 remision
	@idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(10,2)

	DECLARE @Retencion decimal(3,2) 
	set @Retencion =  convert(decimal(3,2),(select valor from parametro where nombre = 'RETENCION'))

IF @tipoDato = 1 --cotizacion
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@Retencion)
	from cotizacionDetalle inner join cotizacion on cotizacionDetalle.idCotizacion = cotizacion.idCotizacion and cotizacion.tipo = 1
	right join producto on cotizacionDetalle.idProducto = producto.idProducto 
	 where cotizacionDetalle.idCotizacion =  @id and cotizaciondetalle.idEncabezado  =@idEncabezado)

END
ELSE
IF @tipoDato = 2 --orden compra
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@Retencion)
	from ordenCompraDetalle inner join ordenCompra on ordenCompraDetalle.idOrdenCompra = ordenCompra.idOrdenCompra and ordenCompra.tipo = 1
	right join producto on ordenCompraDetalle.idProducto = producto.idProducto 
	 where ordenCompraDetalle.idOrdenCompra =  @id and ordencompradetalle.idEncabezado  =@idEncabezado)
END
ELSE
IF @tipoDato = 3 -- remision
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) * (@Retencion)
	from remisionDetalle inner join remision on remisionDetalle.idRemision = remision.idRemision and remision.tipo = 1
	right join producto on remisionDetalle.idProducto = producto.idProducto 
	 where remisionDetalle.idRemision =  @id and remisiondetalle.idEncabezado  =@idEncabezado)
END

	-- Return the result of the function
	RETURN isnull(@Result, 0)

END

GO
/****** Object:  UserDefinedFunction [dbo].[calculaSubtotal]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 24 julio 2020
-- Description:	obtiene el subtotal por id y tipo
-- =============================================
CREATE FUNCTION [dbo].[calculaSubtotal]
(
	-- Add the parameters for the function here
	@id int, 
	@tipoDato int, --1 cotizacion, --2 orden compra, --3 remision
	@idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(10,2)

IF @tipoDato = 1 --cotizacion
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) from cotizacionDetalle 
	where idCotizacion = @id and idEncabezado = @idEncabezado)

END
ELSE
IF @tipoDato = 2 --orden compra
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) from ordenCompraDetalle 
	where idOrdenCompra = @id and idEncabezado = @idEncabezado)
END
ELSE
IF @tipoDato = 3 -- remision
BEGIN
	SET @Result = (select sum (precioUnitario * cantidad) from remisionDetalle 
	where idRemision = @id and idEncabezado = @idEncabezado)
END

	-- Return the result of the function
	RETURN @Result

END

GO
/****** Object:  UserDefinedFunction [dbo].[calculaTotal]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 24 julio 2020
-- Description:	obtiene la retencion si aplica por id y tipo
-- =============================================
CREATE FUNCTION [dbo].[calculaTotal]
(
	-- Add the parameters for the function here
	@id int, 
	@tipoDato int, --1 cotizacion, --2 orden compra, --3 remision
	@idEncabezado int
)
RETURNS decimal(10,2)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(10,2)

	DECLARE @RetencionPorc decimal(3,2) 
	set @RetencionPorc =  convert(decimal(3,2),(select valor from parametro where nombre = 'RETENCION'))

	DECLARE @IVAPorc decimal(3,2) 
	set @IVAPorc =  convert(decimal(3,2),(select valor from parametro where nombre = 'IVA'))

	declare @subtotal decimal(10,2)
	declare @IVA decimal(10,2)
	declare @retencion decimal(10,2)
	declare @total decimal(10,2)

IF @tipoDato = 1 --cotizacion
BEGIN
	set @subtotal = (select sum (precioUnitario * cantidad) from cotizacionDetalle 
					right join producto on cotizacionDetalle.idProducto = producto.idProducto 
					 where cotizacionDetalle.idCotizacion =  @id and idEncabezado  =@idEncabezado )
	set @IVA = (select sum (precioUnitario * cantidad) * (@IVAPorc)  from cotizacionDetalle 
					right join producto on cotizacionDetalle.idProducto = producto.idProducto 
					 where cotizacionDetalle.idCotizacion =  @id and idEncabezado  =@idEncabezado )
	set @retencion = (select sum (precioUnitario * cantidad) * (@RetencionPorc) from cotizacionDetalle 
					right join producto on cotizacionDetalle.idProducto = producto.idProducto 
					inner join cotizacion on cotizacion.idCotizacion = cotizacionDetalle.idCotizacion
					 where cotizacionDetalle.idCotizacion =  @id and cotizaciondetalle.idEncabezado  =@idEncabezado 
					 and cotizacion.tipo = 1 )	
    select @total = isnull(@subtotal,0) + isnull(@IVA,0) - isnull(@retencion,0)
	return @total
	END
	ELSE
	IF @tipoDato = 2 --orden compra
	BEGIN
	set @subtotal = (select sum (precioUnitario * cantidad) from ordenCompraDetalle 
					right join producto on ordenCompraDetalle.idProducto = producto.idProducto 
					 where ordenCompraDetalle.idOrdenCompra =  @id and idEncabezado  =@idEncabezado )

	set @IVA = (select sum (precioUnitario * cantidad) * (@IVAPorc)  from ordenCompraDetalle 
					right join producto on ordenCompraDetalle.idProducto = producto.idProducto 
					 where ordenCompraDetalle.idOrdenCompra =  @id and idEncabezado  =@idEncabezado )

	set @retencion = (select sum (precioUnitario * cantidad) * (@RetencionPorc) from ordenCompraDetalle 
					right join producto on ordenCompraDetalle.idProducto = producto.idProducto 
					inner join ordenCompra on ordenCompra.idOrdenCompra = ordenCompraDetalle.idOrdenCompra
					 where ordenCompraDetalle.idOrdenCompra =  @id and ordenCompraDetalle.idEncabezado  =@idEncabezado 
					 and ordenCompra.tipo = 1 )	

    select @total = isnull(@subtotal,0) + isnull(@IVA,0) - isnull(@retencion,0)
	return @total
	END
	ELSE
	IF @tipoDato = 3 -- remision
	BEGIN
		set @subtotal = (select sum (precioUnitario * cantidad) from remisionDetalle 
					right join producto on remisionDetalle.idProducto = producto.idProducto 
					 where remisionDetalle.idRemision =  @id and idEncabezado  =@idEncabezado )

	set @IVA = (select sum (precioUnitario * cantidad) * (@IVAPorc)  from remisionDetalle 
					right join producto on remisionDetalle.idProducto = producto.idProducto 
					 where remisionDetalle.idRemision =  @id and idEncabezado  =@idEncabezado )

	set @retencion = (select sum (precioUnitario * cantidad) * (@RetencionPorc) from remisionDetalle 
					right join producto on remisionDetalle.idProducto = producto.idProducto 
					inner join remision on remision.idRemision = remisionDetalle.idRemision
					 where remisionDetalle.idRemision =  @id and remisionDetalle.idEncabezado  =@idEncabezado 
					 and remision.tipo = 1 )	

    select @total = isnull(@subtotal,0) + isnull(@IVA,0) - isnull(@retencion,0)
	return @total
	END
	return 0.0
	END

GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarCotizacion]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las cotizaciones y su detalle tanto para guardar o actualizar
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCambiarCotizacion] 
	-- Add the parameters for the stored procedure here
	@idCotizacion int = 0, 
	@idCliente int = 0,
	@fecha datetime,
	@idUsuario int,
	@observaciones nvarchar(500),
	@idEncabezado int,
	@idMoneda int,
	@tipo int
	
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
				   ,idMoneda
				   ,tipo)
			 VALUES
				   (@idCotizacion
				   ,@idCliente
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda
				   ,@tipo)
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
				  ,tipo = @tipo
			 WHERE [idCotizacion] = @idCotizacion

	end
	


END

GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarOrdenCompra]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las orden de compra y su detalle tanto para guardar o actualizar
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCambiarOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@idOrdenCompra int = 0, 
	@idProveedor int = 0,
	@fecha datetime,
	@idUsuario int,
	@observaciones nvarchar(500),
	@idEncabezado int,
	@idMoneda int,
	@tipo int
	
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
			,idMoneda
			,tipo)
   
			 VALUES
				   (@idOrdenCompra
				   ,@idProveedor
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda
				   ,@tipo)
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
				  ,tipo = @tipo
			 WHERE idOrdenCompra = @idOrdenCompra and idEncabezado = @idEncabezado

	end
	


END

GO
/****** Object:  StoredProcedure [dbo].[InsertarCambiarRemision]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 28-06-2019
-- Description:	hace el ingreso de las cotizaciones y su detalle tanto para guardar o actualizar
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCambiarRemision] 
	-- Add the parameters for the stored procedure here
	@idRemision int = 0, 
	@idCliente int = 0,
	@fecha datetime,
	@idUsuario int,
	@observaciones nvarchar(500),
	@idEncabezado int,
	@idMoneda int,
	@tipo int
	
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
				   ,idMoneda
				   ,tipo)
			 VALUES
				   (@idRemision
				   ,@idCliente
				   ,@fecha
				   ,@idUsuario
				   ,@observaciones
				   ,@idEncabezado
				   ,@idMoneda
				   ,@tipo)
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
				  ,tipo = @tipo
			 WHERE idRemision = @idRemision

	end
	


END

GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosCotizacion]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 18-06-2019
-- Description:	obtiene los datos de la cotizacion
-- =============================================
CREATE PROCEDURE [dbo].[obtenerDatosCotizacion] 
	-- Add the parameters for the stored procedure here
	@idCotizacion int = 0,
	@idEncabezado int = 0, 
	@idMoneda int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.*, 
		p.nombre,
		cd.idUnidadMedida,
		cd.cantidad,
		cd.precioUnitario,
		cl.idEmpresa,		
		 CONVERT(DECIMAL(10,2), (cd.cantidad*cd.precioUnitario)) as importe  ,
		dbo.calculasubtotal(c.idCotizacion, 1, @idEncabezado) as subtotal,
		dbo.calculaIVA(c.idCotizacion,1, @idEncabezado) as iva ,
		dbo.calculaTotal(c.idCotizacion,1, @idEncabezado) as total,
		cd.idCotizacionDetalle
	   ,dbo.obtenerAtencionDomicilio(c.idCliente) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
		,u.firma	    
		,[dbo].[CantidadConLetra] (dbo.totalCotizacion(c.idCotizacion, @idEncabezado), @idMoneda) as cantidadLetra
		, u.imagenFirma
		,p.idProducto
		,[dbo].[calculaRetencion](c.idCotizacion, 1, @idEncabezado) as retencion
	from cotizacion c inner join cotizacionDetalle cd on c.idCotizacion = cd.idCotizacion and c.idEncabezado = @idEncabezado
	inner join clienteProveedor cl on cl.idClienteProveedor = c.idCliente
	inner join producto p on cd.idProducto = p.idProducto
	inner join usuario u on c.idUsuario = u.idUsuario
	where c.idCotizacion = @idCotizacion and cd.idEncabezado = @idEncabezado 

END

GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosOrdenCompra]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 18-06-2019
-- Description:	obtiene los datos de la cotizacion
-- =============================================
CREATE PROCEDURE [dbo].[obtenerDatosOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@idOrdenCompra int = 0,
	@idEncabezado int, 
	@idMoneda int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



    -- Insert statements for procedure here
	SELECT c.*, 
		p.nombre,
		cd.idUnidadMedida,
		cd.cantidad,
		cd.precioUnitario,
		cl.idEmpresa,		
		CONVERT(DECIMAL(10,2), (cd.cantidad*cd.precioUnitario)) as importe  ,
		dbo.calculasubtotal(c.idOrdenCompra,2, @idEncabezado) as subtotal,
		dbo.calculaiva(c.idOrdenCompra,2, @idEncabezado) as iva ,
		dbo.calculatotal(c.idOrdenCompra,2, @idEncabezado) as total,
		cd.idOrdenCompraDetalle
		 ,dbo.obtenerAtencionDomicilio(c.idProveedor) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
		,[dbo].[CantidadConLetra] (dbo.totalOrdenCompra(c.idOrdenCompra, @idEncabezado), @idMoneda) as cantidadLetra
		,u.firma
		, u.imagenFirma
		, p .idProducto
		, dbo.calcularetencion(c.idOrdenCompra, 2, @idEncabezado) as retencion
	from ordenCompra c 
	inner join ordenCompraDetalle cd on c.idOrdenCompra = cd.idOrdenCompra
	inner join clienteProveedor cl on cl.idClienteProveedor = c.idProveedor
	inner join producto p on cd.idProducto = p.idProducto
	inner join usuario u on c.idUsuario = u.idUsuario
	where c.idOrdenCompra = @idOrdenCompra and c.idEncabezado = @idEncabezado and cd.idEncabezado = @idEncabezado

END

GO
/****** Object:  StoredProcedure [dbo].[obtenerDatosRemision]    Script Date: 24/07/2020 03:57:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaime Castorena
-- Create date: 01/10/2019
-- Description:	obtiene los datos de la remision
-- =============================================
CREATE PROCEDURE [dbo].[obtenerDatosRemision] 
	-- Add the parameters for the stored procedure here
	@idRemision int = 0,
	@idEncabezado int = 0, 
	@idMoneda int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.*, 
		p.nombre,
		rd.idUnidadMedida,
		rd.cantidad,
		rd.precioUnitario,
		cl.idEmpresa,		
		 CONVERT(DECIMAL(10,2), (rd.cantidad*rd.precioUnitario)) as importe  ,
		dbo.calculasubtotal(r.idRemision,3, @idEncabezado) as subtotal,
		dbo.calculaiva(r.idRemision,3, @idEncabezado) as iva ,
		dbo.calculatotal(r.idRemision,3, @idEncabezado) as total,
		rd.idRemisionDetalle
	   ,dbo.obtenerAtencionDomicilio(r.idCliente) as atencion
		,u.nombre as usuario
		,dbo.obtenerencabezado(@idEncabezado) as encabezado
		,u.firma	    
		,[dbo].[CantidadConLetra] (dbo.totalRemision(r.idRemision, @idEncabezado), @idMoneda) as cantidadLetra
		, u.imagenFirma
		, p.idProducto
		, dbo.calculaRetencion(r.idRemision, 3, @idEncabezado) as retencion
	from remision r inner join remisionDetalle rd on r.idRemision = rd.idRemision and r.idEncabezado = @idEncabezado
	inner join clienteProveedor cl on cl.idClienteProveedor = r.idCliente
	inner join producto p on rd.idProducto = p.idProducto
	inner join usuario u on r.idUsuario = u.idUsuario
	where r.idRemision = @idRemision and rd.idEncabezado = @idEncabezado 

END

GO
