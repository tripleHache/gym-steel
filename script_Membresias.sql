use Gimnasio
go

-- Agregamos la columna NroPersonas a la tabla existente
ALTER TABLE [dbo].[Paquetes]
ADD [NroPersonas] INT NOT NULL DEFAULT 1;
GO