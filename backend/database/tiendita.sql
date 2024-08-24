CREATE DATABASE Tiendita;
GO

USE Tiendita;
GO

-- Tabla de Usuarios
CREATE TABLE USUARIOS (
    IDUsuario INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARBINARY(256) NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    UltimoAcceso DATETIME
);

-- Tabla de Proveedores
CREATE TABLE PROVEEDORES (
    IDProveedor INT PRIMARY KEY IDENTITY(1,1),
    NombreProveedor VARCHAR(100) NOT NULL UNIQUE,
    Contacto VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Direccion VARCHAR(200)
);

-- Tabla de Productos
CREATE TABLE PRODUCTOS (
    CodigoProducto INT PRIMARY KEY IDENTITY(1,1),
    NombreProducto VARCHAR(100) NOT NULL,
    PrecioCosto DECIMAL(10, 2) NOT NULL,
    PrecioVenta DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Descripcion VARCHAR(200),
    IDProveedor INT FOREIGN KEY REFERENCES PROVEEDORES(IDProveedor)
);

-- Tabla de Facturas
CREATE TABLE FACTURAS (
    IDFactura INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    IDUsuario INT FOREIGN KEY REFERENCES USUARIOS(IDUsuario),
    TotalFactura DECIMAL(10, 2) NOT NULL
);

-- Tabla de Detalle de Facturas
CREATE TABLE DETALLE_FACTURA (
    IDDetalle INT PRIMARY KEY IDENTITY(1,1),
    IDFactura INT FOREIGN KEY REFERENCES FACTURAS(IDFactura),
    CodigoProducto INT FOREIGN KEY REFERENCES PRODUCTOS(CodigoProducto),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Total DECIMAL(10, 2) NOT NULL
);

-- Tabla de Caja
CREATE TABLE CAJA (
    IDCaja INT PRIMARY KEY IDENTITY(1,1),
    FechaApertura DATETIME NOT NULL,
    FechaCierre DATETIME,
    Responsable VARCHAR(50) NOT NULL,
    Ingreso DECIMAL(10, 2) NOT NULL,
    Egreso DECIMAL(10, 2) NOT NULL,
    Observaciones VARCHAR(200) NULL,
    Total DECIMAL(10, 2) NOT NULL
);

-- Tabla de Ventas
CREATE TABLE VENTAS (
    IDVenta INT PRIMARY KEY IDENTITY(1,1),
    IDFactura INT FOREIGN KEY REFERENCES FACTURAS(IDFactura),
    Comentario VARCHAR(250) NULL,
    FormaDePago VARCHAR(50) CHECK (FormaDePago IN ('Transferencia', 'Efectivo')),
    Fecha DATETIME NOT NULL,
    TotalVenta DECIMAL(10, 2) NOT NULL
);

-- Tabla de Movimientos de Stock
CREATE TABLE MOVIMIENTOS_STOCK (
    IDMovimiento INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    CodigoProducto INT FOREIGN KEY REFERENCES PRODUCTOS(CodigoProducto),
    Ingreso INT DEFAULT 0,
    Egreso INT DEFAULT 0,
    Comentario VARCHAR(200)
);

-- Tabla de Movimientos de Dinero
CREATE TABLE MOVIMIENTOS_DINERO (
    IDMovimiento INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    Concepto VARCHAR(100) NOT NULL,
    Monto DECIMAL(10, 2) NOT NULL,
    Comentarios VARCHAR(200)
);
