ALTER PROCEDURE Clientes_activos   
AS      
BEGIN      
      
SELECT      
    HuellaXml,
    Nombre,
    Vigencia
FROM      
(      
 SELECT        
  A.idCliente,      
  A.Nombre,      
  A.Huella,
  A.HuellaXml,
  B.Fecha_Pago,      
  CASE        
    WHEN C.Frecuencia = 'DIARIO' THEN CAST(B.Fecha_Pago AS DATE)        
    WHEN C.Frecuencia = 'SEMANAL' THEN DATEADD(day, -1, DATEADD(week, 1, CAST(B.Fecha_Pago AS DATE)))  
    WHEN C.Frecuencia = 'MENSUAL' THEN DATEADD(day, -1, DATEADD(month, 1, CAST(B.Fecha_Pago AS DATE)))            
	WHEN C.Frecuencia = 'BIMESTRAL' THEN DATEADD(day, -1, DATEADD(month, 2, CAST(B.Fecha_Pago AS DATE)))  
	WHEN C.Frecuencia = 'TRIMESTRAL' THEN DATEADD(day, -1, DATEADD(month, 3, CAST(B.Fecha_Pago AS DATE)))  
    WHEN C.Frecuencia = 'SEMESTRAL' THEN DATEADD(day, -1, DATEADD(month, 6, CAST(B.Fecha_Pago AS DATE)))  
	WHEN C.Frecuencia = 'ANUAL' THEN DATEADD(day, -1, DATEADD(year, 1, CAST(B.Fecha_Pago AS DATE)))  
  END AS Vigencia,      
  B.idPaquete,      
  C.Frecuencia,
  A.Activo
 FROM        
  Clientes AS A      
 INNER JOIN        
  (      
   SELECT        
    idCliente,        
    MAX(Fecha_Pago) AS UltimoPago      
   FROM        
    Pagos      
   GROUP BY        
    idCliente      
  ) AS UltimosPagos ON A.idCliente = UltimosPagos.idCliente      
 INNER JOIN        
  Pagos AS B ON A.idCliente = B.idCliente AND B.Fecha_Pago = UltimosPagos.UltimoPago      
 INNER JOIN Paquetes AS C ON B.idPaquete = C.idPaquete      
) AS T      
-- Comparamos contra el inicio del día de hoy
WHERE Vigencia >= CAST(GETDATE() AS DATE)     
AND Activo = 1;
END