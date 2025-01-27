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

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Edad INT NOT NULL
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

 INSERT INTO Usuarios (Nombre, Apellido, Email, Username, Password , Edad)
VALUES 
('Walther', 'Olivo', 'walther.olivo@sasf.net', 'devJoander7', 'devJoander7siu', 21);