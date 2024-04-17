create  database Rutas

CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY,
    Nombre VARCHAR(100),
    TipoCliente VARCHAR(50)
);


CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY,
    ClienteID INT FOREIGN KEY REFERENCES Clientes(ClienteID),
    Ruta VARCHAR(100),
    Precio DECIMAL(10, 2),
    NumeroPersonas INT
);


INSERT INTO Clientes (ClienteID, Nombre, TipoCliente)
VALUES (1, 'Colegio San Juan', 'Promoción de colegios');


INSERT INTO Clientes (ClienteID, Nombre, TipoCliente)
VALUES (2, 'María López', 'Adulto mayor');


INSERT INTO Ventas (VentaID, ClienteID, Ruta, Precio, NumeroPersonas)
VALUES (1, 1, 'Sacsayhuaman – Puka Pukara – Tambomachay', 100.00, 25);


INSERT INTO Ventas (VentaID, ClienteID, Ruta, Precio, NumeroPersonas)
VALUES (2, 2, 'Tipon - Lucre - Piquillaqta', 120.00, 10);

