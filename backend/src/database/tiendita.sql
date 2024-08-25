-- Tabla de Usuarios
CREATE TABLE USUARIOS (
    IDUsuario SERIAL PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena BYTEA NOT NULL,
    NombreCompleto VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UltimoAcceso TIMESTAMP
);

-- Tabla de Proveedores
CREATE TABLE PROVEEDORES (
    IDProveedor SERIAL PRIMARY KEY,
    NombreProveedor VARCHAR(100) NOT NULL UNIQUE,
    Contacto VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Direccion VARCHAR(200)
);

-- Tabla de Productos
CREATE TABLE PRODUCTOS (
    CodigoProducto SERIAL PRIMARY KEY,
    NombreProducto VARCHAR(100) NOT NULL,
    PrecioCosto DECIMAL(10, 2) NOT NULL,
    PrecioVenta DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Descripcion VARCHAR(200),
    IDProveedor INT REFERENCES PROVEEDORES(IDProveedor)
);

-- Tabla de Facturas
CREATE TABLE FACTURAS (
    IDFactura SERIAL PRIMARY KEY,
    Fecha DATE NOT NULL,
    IDUsuario INT REFERENCES USUARIOS(IDUsuario),
    TotalFactura DECIMAL(10, 2) NOT NULL
);

-- Tabla de Detalle de Facturas
CREATE TABLE DETALLE_FACTURA (
    IDDetalle SERIAL PRIMARY KEY,
    IDFactura INT REFERENCES FACTURAS(IDFactura),
    CodigoProducto INT REFERENCES PRODUCTOS(CodigoProducto),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Total DECIMAL(10, 2) NOT NULL
);

-- Tabla de Caja
CREATE TABLE CAJA (
    IDCaja SERIAL PRIMARY KEY,
    FechaApertura TIMESTAMP NOT NULL,
    FechaCierre TIMESTAMP,
    Responsable VARCHAR(50) NOT NULL,
    Ingreso DECIMAL(10, 2) NOT NULL,
    Egreso DECIMAL(10, 2) NOT NULL,
    Observaciones VARCHAR(200),
    Total DECIMAL(10, 2) NOT NULL
);

-- Tabla de Ventas
CREATE TABLE VENTAS (
    IDVenta SERIAL PRIMARY KEY,
    IDFactura INT REFERENCES FACTURAS(IDFactura),
    Comentario VARCHAR(250),
    FormaDePago VARCHAR(50) CHECK (FormaDePago IN ('Transferencia', 'Efectivo')),
    Fecha TIMESTAMP NOT NULL,
    TotalVenta DECIMAL(10, 2) NOT NULL
);

-- Tabla de Movimientos de Stock
CREATE TABLE MOVIMIENTOS_STOCK (
    IDMovimiento SERIAL PRIMARY KEY,
    Fecha TIMESTAMP NOT NULL,
    CodigoProducto INT REFERENCES PRODUCTOS(CodigoProducto),
    Ingreso INT DEFAULT 0,
    Egreso INT DEFAULT 0,
    Comentario VARCHAR(200)
);

-- Tabla de Movimientos de Dinero
CREATE TABLE MOVIMIENTOS_DINERO (
    IDMovimiento SERIAL PRIMARY KEY,
    Fecha TIMESTAMP NOT NULL,
    Concepto VARCHAR(100) NOT NULL,
    Monto DECIMAL(10, 2) NOT NULL,
    Comentarios VARCHAR(200)
);
