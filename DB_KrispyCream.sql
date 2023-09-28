CREATE DATABASE KrispyCream;
GO
Use KrispyCream
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(50),
    Clave VARCHAR(500)
);
GO
CREATE TABLE Donas (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50)
	);
GO
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
	Direccion VARCHAR(200),
	Cantidad int,
	DonaId int,
	FOREIGN KEY (DonaID) REFERENCES Donas(Id)
	);
GO
INSERT INTO Usuarios(Nombre, Clave)
	VALUES 
	('krispy','kr1py1234')

GO
INSERT INTO Donas (Nombre)
	VALUES 
('Chocolate'),
('Moka'),
('Vainilla')
GO
