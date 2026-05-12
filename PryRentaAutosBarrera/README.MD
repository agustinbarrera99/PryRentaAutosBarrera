-- ============================================================
--  GESTIÓN DE FLOTAS - Script de Base de Datos
--  Motor: SQL Server Management Studio (SSMS)
--  Autor: Proyecto GestionFlotas
-- ============================================================
 
USE master;
GO
 
-- Crear la base de datos (si no existe)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionFlotas')
BEGIN
    CREATE DATABASE GestionFlotas;
END
GO
 
USE GestionFlotas;
GO
 
-- ============================================================
--  TABLA: Vehículos
-- ============================================================
IF OBJECT_ID('dbo.Vehiculos', 'U') IS NOT NULL
    DROP TABLE dbo.Vehiculos;
GO
 
CREATE TABLE dbo.Vehiculos (
    Id_Vehiculo     INT             NOT NULL IDENTITY(1,1),
    Patente         NVARCHAR(20)    NOT NULL,
    Modelo_Marca    NVARCHAR(100)   NOT NULL,
    Mantenimiento   DATE            NULL,
    Seguro          DATE            NULL,
    Estado          BIT             NOT NULL DEFAULT 1,   -- 1 = Disponible, 0 = No disponible
    CONSTRAINT PK_Vehiculos PRIMARY KEY (Id_Vehiculo),
    CONSTRAINT UQ_Vehiculos_Patente UNIQUE (Patente)
);
GO
 
-- ============================================================
--  TABLA: Choferes
-- ============================================================
IF OBJECT_ID('dbo.Choferes', 'U') IS NOT NULL
    DROP TABLE dbo.Choferes;
GO
 
CREATE TABLE dbo.Choferes (
    Id_Chofer           INT             NOT NULL IDENTITY(1,1),
    Nombre_Completo     NVARCHAR(150)   NOT NULL,
    DNI_Pasaporte       NVARCHAR(30)    NOT NULL,
    Telefono            NVARCHAR(20)    NULL,
    Licencia_Conducir   NVARCHAR(50)    NULL,
    CONSTRAINT PK_Choferes PRIMARY KEY (Id_Chofer),
    CONSTRAINT UQ_Choferes_DNI UNIQUE (DNI_Pasaporte)
);
GO
 
-- ============================================================
--  TABLA: Contratos
-- ============================================================
IF OBJECT_ID('dbo.Contratos', 'U') IS NOT NULL
    DROP TABLE dbo.Contratos;
GO
 
CREATE TABLE dbo.Contratos (
    Id_Contrato     INT             NOT NULL IDENTITY(1,1),
    Tipo            NVARCHAR(80)    NOT NULL,   -- Ej: 'Mensual', 'Por viaje', 'Anual'
    Monto_Base      MONEY           NOT NULL DEFAULT 0,
    Descripcion     NVARCHAR(500)   NULL,
    CONSTRAINT PK_Contratos PRIMARY KEY (Id_Contrato)
);
GO
 
-- ============================================================
--  TABLA: Alquileres / Registros
-- ============================================================
IF OBJECT_ID('dbo.Alquileres_Registros', 'U') IS NOT NULL
    DROP TABLE dbo.Alquileres_Registros;
GO
 
CREATE TABLE dbo.Alquileres_Registros (
    Id_Alquiler     INT             NOT NULL IDENTITY(1,1),
    Id_Vehiculo     INT             NOT NULL,
    Id_Chofer       INT             NOT NULL,
    Id_Contratos    INT             NOT NULL,
    Fecha_Inicio    DATE            NOT NULL,
    Fecha_Fin       DATE            NULL,
    Costo_Total     NUMERIC(18,2)   NOT NULL DEFAULT 0,
    Estado_Cobro    BIGINT          NOT NULL DEFAULT 0,  -- 0 = Pendiente, 1 = Pagado, 2 = Cancelado
    CONSTRAINT PK_Alquileres PRIMARY KEY (Id_Alquiler),
    CONSTRAINT FK_Alquileres_Vehiculo  FOREIGN KEY (Id_Vehiculo)  REFERENCES dbo.Vehiculos(Id_Vehiculo),
    CONSTRAINT FK_Alquileres_Chofer    FOREIGN KEY (Id_Chofer)    REFERENCES dbo.Choferes(Id_Chofer),
    CONSTRAINT FK_Alquileres_Contrato  FOREIGN KEY (Id_Contratos) REFERENCES dbo.Contratos(Id_Contrato)
);
GO
 
-- ============================================================
--  DATOS DE PRUEBA
-- ============================================================
 
-- Vehículos
INSERT INTO dbo.Vehiculos (Patente, Modelo_Marca, Mantenimiento, Seguro, Estado)
VALUES
    ('AA123BB', 'Toyota Hilux 2022',       '2025-06-01', '2025-12-31', 1),
    ('CC456DD', 'Ford Ranger 2021',         '2025-04-15', '2025-11-30', 1),
    ('EE789FF', 'Volkswagen Amarok 2023',   '2025-08-20', '2026-01-15', 0);
GO
 
-- Choferes
INSERT INTO dbo.Choferes (Nombre_Completo, DNI_Pasaporte, Telefono, Licencia_Conducir)
VALUES
    ('Carlos Martínez',   '28456789', '3516001122', 'LIC-0001'),
    ('Ana González',      '32156823', '3516003344', 'LIC-0002'),
    ('Roberto Silva',     '25789654', '3516005566', 'LIC-0003');
GO
 
-- Contratos
INSERT INTO dbo.Contratos (Tipo, Monto_Base, Descripcion)
VALUES
    ('Mensual',   150000, 'Contrato mensual estándar por vehículo'),
    ('Por viaje',  12000, 'Tarifa fija por cada viaje realizado'),
    ('Anual',    1500000, 'Contrato anual con mantenimiento incluido');
GO
 
-- Alquileres
INSERT INTO dbo.Alquileres_Registros (Id_Vehiculo, Id_Chofer, Id_Contratos, Fecha_Inicio, Fecha_Fin, Costo_Total, Estado_Cobro)
VALUES
    (1, 1, 1, '2025-01-01', '2025-01-31', 150000, 1),
    (2, 2, 2, '2025-02-10', '2025-02-10',  12000, 0),
    (3, 3, 3, '2025-01-01', '2025-12-31', 1500000, 0);
GO
 
-- ============================================================
--  VISTAS ÚTILES
-- ============================================================
 
-- Vista: Alquileres con detalle completo
IF OBJECT_ID('dbo.vw_AlquileresDetalle', 'V') IS NOT NULL
    DROP VIEW dbo.vw_AlquileresDetalle;
GO
 
CREATE VIEW dbo.vw_AlquileresDetalle AS
SELECT
    ar.Id_Alquiler,
    v.Patente,
    v.Modelo_Marca,
    c.Nombre_Completo   AS Chofer,
    ct.Tipo             AS TipoContrato,
    ar.Fecha_Inicio,
    ar.Fecha_Fin,
    ar.Costo_Total,
    CASE ar.Estado_Cobro
        WHEN 0 THEN 'Pendiente'
        WHEN 1 THEN 'Pagado'
        WHEN 2 THEN 'Cancelado'
        ELSE 'Desconocido'
    END AS Estado_Cobro
FROM dbo.Alquileres_Registros ar
INNER JOIN dbo.Vehiculos   v  ON ar.Id_Vehiculo  = v.Id_Vehiculo
INNER JOIN dbo.Choferes    c  ON ar.Id_Chofer    = c.Id_Chofer
INNER JOIN dbo.Contratos   ct ON ar.Id_Contratos = ct.Id_Contrato;
GO
 
PRINT 'Base de datos GestionFlotas creada correctamente.';
GO