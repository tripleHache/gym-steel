ALTER TABLE Clientes ADD Activo BIT DEFAULT 1;
UPDATE Clientes SET Activo = 1;