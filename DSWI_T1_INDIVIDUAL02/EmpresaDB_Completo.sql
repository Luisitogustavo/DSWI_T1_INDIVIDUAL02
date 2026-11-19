
/*
    NEXUS MANAGEMENT CONSOLE
    Evaluación T1 - Desarrollo de Servicios Web I
    Base de datos: EmpresaDB
    Motor: Microsoft SQL Server

    Contenido:
    - Clientes y Pedidos
    - Relación 1:N
    - Registros iniciales
    - Procedimientos almacenados CRUD parcial

    Script preparado para evitar duplicar datos
    cuando se ejecuta nuevamente.
*/

-- 1. CREACIÓN DE BASE DE DATOS
IF DB_ID(N'EmpresaDB') IS NULL
BEGIN
    CREATE DATABASE EmpresaDB;
END;
GO

USE EmpresaDB;
GO

-- 2. TABLA CLIENTES
IF OBJECT_ID(N'dbo.Clientes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes
    (
        ClienteID INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        CorreoElectronico NVARCHAR(100) NOT NULL
    );
END;
GO

-- 3. TABLA PEDIDOS
IF OBJECT_ID(N'dbo.Pedidos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Pedidos
    (
        PedidoID INT IDENTITY(1,1) PRIMARY KEY,
        FechaPedido DATE NOT NULL,
        Monto DECIMAL(10,2) NOT NULL,
        Estado NVARCHAR(50) NOT NULL,
        ClienteID INT NOT NULL,

        CONSTRAINT FK_Pedidos_Clientes
            FOREIGN KEY (ClienteID)
            REFERENCES dbo.Clientes(ClienteID)
            ON DELETE CASCADE
            ON UPDATE CASCADE
    );
END;
GO

-- 4. REGISTROS INICIALES
-- Solo se insertan si ambas tablas están vacías.
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes)
   AND NOT EXISTS (SELECT 1 FROM dbo.Pedidos)
BEGIN
    INSERT INTO dbo.Clientes
        (Nombre, CorreoElectronico)
    VALUES
        (N'María Pérez', N'maria.perez@example.com'),
        (N'Juan Torres', N'juan.torres@example.com'),
        (N'Lucía Ramírez', N'lucia.ramirez@example.com');

    DECLARE @MariaID INT =
        (SELECT TOP (1) ClienteID FROM dbo.Clientes
         WHERE CorreoElectronico = N'maria.perez@example.com');

    DECLARE @JuanID INT =
        (SELECT TOP (1) ClienteID FROM dbo.Clientes
         WHERE CorreoElectronico = N'juan.torres@example.com');

    DECLARE @LuciaID INT =
        (SELECT TOP (1) ClienteID FROM dbo.Clientes
         WHERE CorreoElectronico = N'lucia.ramirez@example.com');

    INSERT INTO dbo.Pedidos
        (FechaPedido, Monto, Estado, ClienteID)
    VALUES
        ('2025-04-01', 150.00, N'Pendiente', @MariaID),
        ('2025-04-02', 300.50, N'Entregado', @MariaID),
        ('2025-04-03', 75.25, N'Cancelado', @JuanID),
        ('2025-04-04', 500.00, N'Pendiente', @LuciaID);
END;
GO

-- 5. PROCEDIMIENTOS ALMACENADOS: CLIENTES

CREATE OR ALTER PROCEDURE dbo.usp_Clientes_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ClienteID, Nombre, CorreoElectronico
    FROM dbo.Clientes
    ORDER BY ClienteID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Clientes_Crear
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Clientes
        (Nombre, CorreoElectronico)
    VALUES
        (@Nombre, @CorreoElectronico);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Clientes_Editar
    @ClienteID INT,
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Clientes
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico
    WHERE ClienteID = @ClienteID;
END;
GO

-- 6. PROCEDIMIENTOS ALMACENADOS: PEDIDOS

CREATE OR ALTER PROCEDURE dbo.usp_Pedidos_Listar
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PedidoID, FechaPedido, Monto, Estado, ClienteID
    FROM dbo.Pedidos
    ORDER BY PedidoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Pedidos_Crear
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Pedidos
        (FechaPedido, Monto, Estado, ClienteID)
    VALUES
        (@FechaPedido, @Monto, @Estado, @ClienteID);
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_Pedidos_Editar
    @PedidoID INT,
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Pedidos
    SET FechaPedido = @FechaPedido,
        Monto = @Monto,
        Estado = @Estado,
        ClienteID = @ClienteID
    WHERE PedidoID = @PedidoID;
END;
GO

-- 7. VERIFICACIÓN DE LOS PROCEDIMIENTOS
EXEC dbo.usp_Clientes_Listar;
EXEC dbo.usp_Pedidos_Listar;
GO

PRINT N'EmpresaDB: configuración completada correctamente.';
GO
