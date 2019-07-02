

--USE [Haito]
--GO

--INSERT INTO [dbo].[Empresa]
--           ([Nombre]
--           ,[active])
--select distinct empresa, 1 from [dbo].['CLIENTES $']
--set ansi_warnings off
--USE [Haito]
--GO
--INSERT INTO [dbo].[clienteProveedor]
--           ([idEmpresa]
--           ,[atencion]
          
--           ,[telefono]
          
--           ,[correo]
--           ,[diasCredito]
--           ,[domicilio]
           
--           ,[cliente]
         
--           ,[active])

--select e.idEmpresa, isnull(c.contacto,''), isnull(c.columna,''), isnull(c.correo,''), isnull(c.comentarios,''),
-- isnull(c.domicilio,''), 1, 1
--from [dbo].['CLIENTES $'] c inner join empresa e on e.nombre = c.empresa

----delete from clienteProveedor
--select * from clienteproveedor
--select * from [dbo].['CLIENTES $']


--USE [Haito]
--GO

--INSERT INTO [dbo].[Empresa]
--           ([Nombre]
--           ,[active])
--select distinct proveedor, 1 from  [dbo].[PROVEEDORES$]
--poner la tablar para generacion de indices



--set ansi_warnings off


--USE [Haito]
--GO

--INSERT INTO [dbo].[clienteProveedor]
--           ([idEmpresa]
--           ,[atencion]
--           ,[celular]
--           ,[telefono]
--           ,[correo]
--           ,[diasCredito]
--           ,[domicilio]
--                      ,[cliente]
--           ,[active])

--select e.idEmpresa, p.atencion, p.celular, p.telefono, p.correo, p.[dias credito], p.f7, 0, 1

--from [dbo].[PROVEEDORES$] p inner join empresa e on e.nombre = p.proveedor


--select * from  [dbo].[PROVEEDORES$]