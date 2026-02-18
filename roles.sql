USE Gimnasio
GO

ALTER TABLE [dbo].[Usuarios] 
ADD [Rol] INT NOT NULL DEFAULT 2; -- Por defecto, todos son usuarios normales
GO

ALTER TABLE [dbo].[Usuarios] 
ADD [Usuario] VARCHAR(200) NOT NULL DEFAULT ''; -- Por defecto, todos son usuarios normales
GO

select * from Usuarios
update Usuarios set Usuario = 'IRMA GUADALUPE HARO HEREDIA' where nombre = 'as'
update Usuarios set Usuario = 'ADMIN IRMA GUADALUPE HARO HEREDIA' where nombre = 'asd'
update Usuarios set Usuario = 'IRMA HARO HEREDIA' where nombre = 'Irma_0001'
update Usuarios set Usuario = 'KEVIN AYALA' where nombre = 'Kevin_0001'