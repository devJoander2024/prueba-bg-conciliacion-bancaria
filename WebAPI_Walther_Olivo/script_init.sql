-- Crear tabla de registros contables
CREATE TABLE RegistrosContables (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Descripcion NVARCHAR(255),
    Monto DECIMAL(18,2)
);

-- Crear tabla de movimientos bancarios
CREATE TABLE MovimientosBancarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Descripcion NVARCHAR(255),
    Monto DECIMAL(18,2)
);

-- Insertar registros quemados en RegistrosContables
INSERT INTO RegistrosContables (Fecha, Descripcion, Monto)
VALUES 
('2025-01-01', 'Venta Producto A', 100.00),
('2025-01-02', 'Pago Cliente B', 200.00),
('2025-01-03', 'Compra Insumos', -50.00);

-- Insertar registros quemados en MovimientosBancarios
INSERT INTO MovimientosBancarios (Fecha, Descripcion, Monto)
VALUES 
('2025-01-01', 'Venta Producto A', 100.00),
('2025-01-02', 'Pago Cliente B', 200.00),
('2025-01-04', 'Comisión Bancaria', -5.00);
