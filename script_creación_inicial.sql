USE GD2C2014
GO
CREATE SCHEMA G_N
GO
-- hola
-- TABLA TEMPORAL DE HOTELES Y REGIMENES
SELECT DISTINCT Hotel_Ciudad, 
				Hotel_Calle, 
				Hotel_Nro_Calle,
				Hotel_CantEstrella, 
				Regimen_Descripcion, 
				Regimen_Precio
INTO G_N.#Hoteles_Regimenes_Temp
FROM gd_esquema.Maestra

-- TABLA HOTELES	
CREATE TABLE G_N.Hoteles(Hotel_Id INT IDENTITY(1,1) PRIMARY KEY,
						 Hotel_Nombre VARCHAR(70),
						 Hotel_Mail VARCHAR(50),
						 Hotel_Telefono VARCHAR(30),
						 Hotel_Pais VARCHAR(50),
						 Hotel_Ciudad VARCHAR(255) NOT NULL,
						 Hotel_Dom_Calle VARCHAR(255) NOT NULL,
						 Hotel_Dom_Nro NUMERIC(18,0) NOT NULL,
						 Hotel_Estrellas NUMERIC(18,0) NOT NULL,
						 Hotel_Fecha_Creacion DATE)

INSERT INTO G_N.Hoteles(Hotel_Ciudad, 
					    Hotel_Dom_Calle,
					    Hotel_Dom_Nro,
						Hotel_Estrellas) 
	SELECT DISTINCT Hotel_Ciudad, Hotel_Calle, Hotel_Nro_Calle, Hotel_CantEstrella
	FROM G_N.#Hoteles_Regimenes_Temp

-- TABLA REGÍMENES
CREATE TABLE G_N.Regimenes(Regimen_Id INT IDENTITY(1,1) PRIMARY KEY,
						   Regimen_Descripcion NVARCHAR(255) NOT NULL,
						   Regimen_Precio NUMERIC(18,2) NOT NULL)
				
INSERT INTO G_N.Regimenes(Regimen_Descripcion, Regimen_Precio)	   
	SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
	FROM G_N.#Hoteles_Regimenes_Temp

-- TABLA RELACIÓN HOTELES CON REGÍMENES
CREATE TABLE G_N.Hoteles_Regimenes(Hotel_Id INT FOREIGN KEY REFERENCES G_N.Hoteles(Hotel_Id),
								   Regimen_Id INT FOREIGN KEY REFERENCES G_N.Regimenes(Regimen_Id),
								   PRIMARY KEY (Hotel_Id, Regimen_Id))
								   
INSERT INTO G_N.Hoteles_Regimenes(Hotel_Id, Regimen_Id)
	SELECT DISTINCT Hotel_Id, Regimen_Id 
	FROM G_N.Hoteles, G_N.Regimenes, G_N.#Hoteles_Regimenes_Temp
	WHERE G_N.Hoteles.Hotel_Dom_Calle = G_N.#Hoteles_Regimenes_Temp.Hotel_Calle
	  AND G_N.Hoteles.Hotel_Dom_Nro = G_N.#Hoteles_Regimenes_Temp.Hotel_Nro_Calle
	  AND G_N.Hoteles.Hotel_Ciudad = G_N.#Hoteles_Regimenes_Temp.Hotel_Ciudad
	  AND G_N.Hoteles.Hotel_Estrellas = G_N.#Hoteles_Regimenes_Temp.Hotel_CantEstrella
	  AND G_N.Regimenes.Regimen_Descripcion = G_N.#Hoteles_Regimenes_Temp.Regimen_Descripcion
	  AND G_N.Regimenes.Regimen_Precio = G_N.#Hoteles_Regimenes_Temp.Regimen_Precio

-- TABLA TIPOS DE HABITACION
CREATE TABLE G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo INT PRIMARY KEY,
								  Habitacion_Tipo_Descripcion NVARCHAR(255) NOT NULL,
								  Habitacion_Tipo_Porcentual NUMERIC(18,2) NOT NULL)

INSERT INTO G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo,
								 Habitacion_Tipo_Descripcion,
								 Habitacion_Tipo_Porcentual)			
	SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual 
	FROM gd_esquema.Maestra
		
-- TABLA HABITACIONES
CREATE TABLE G_N.Habitaciones(Habitacion_Id INT IDENTITY(1,1) PRIMARY KEY,
							  Habitacion_Hotel_Id INT NOT NULL FOREIGN KEY REFERENCES G_N.Hoteles(Hotel_Id),
							  Habitacion_Numero NUMERIC(18,0) NOT NULL,
							  Habitacion_Piso NUMERIC(18,0) NOT NULL,
							  Habitacion_Es_Frente CHAR(1) NOT NULL,
							  Habitacion_Tipo_Codigo INT NOT NULL FOREIGN KEY REFERENCES G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo))

INSERT INTO G_N.Habitaciones(Habitacion_Hotel_Id,
							 Habitacion_Numero,
							 Habitacion_Piso,
							 Habitacion_Es_Frente,
							 Habitacion_Tipo_Codigo)
	SELECT DISTINCT
		(SELECT H.Hotel_Id FROM G_N.Hoteles H
		 WHERE H.Hotel_Ciudad = M.Hotel_Ciudad 
		   AND H.Hotel_Dom_Calle = M.Hotel_Calle 
		   AND H.Hotel_Dom_Nro = M.Hotel_Nro_Calle) AS HotelId,
		M.Habitacion_Numero,
		M.Habitacion_Piso,
		M.Habitacion_Frente, 
		M.Habitacion_Tipo_Codigo
	FROM G_N.Hoteles H, gd_esquema.Maestra M
	
							  
-- TABLA TIPOS DE DOCUMENTO
CREATE TABLE G_N.Documento_Tipos(Documento_Tipo_Id INT IDENTITY (1,1) PRIMARY KEY,
								 Documento_Tipo_Descripcion VARCHAR(30) NOT NULL)

INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('Pasaporte')
INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('D.N.I.')
INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('Cédula de Identidad')

-- TABLA CLIENTES
CREATE TABLE G_N.Clientes(Cliente_Id INT IDENTITY(1,1) PRIMARY KEY,
						  Cliente_Documento_Tipo_Id INT NOT NULL FOREIGN KEY REFERENCES G_N.Documento_Tipos(Documento_Tipo_Id),
						  Cliente_Documento_Nro NUMERIC(18,0) NOT NULL, 
						  Cliente_Apellido NVARCHAR(255) NOT NULL,
						  Cliente_Nombre NVARCHAR(255) NOT NULL, 
						  Cliente_Fecha_Nac DATE NOT NULL, 
						  Cliente_Mail NVARCHAR(255) NOT NULL,
						  Cliente_Telefono NVARCHAR(30),
						  Cliente_Dom_Pais NVARCHAR(255),
						  Cliente_Dom_Localidad NVARCHAR(255),
						  Cliente_Dom_Calle NVARCHAR(255) NOT NULL,
					      Cliente_Dom_Nro_Calle NUMERIC(18,0) NOT NULL,
						  Cliente_Piso NUMERIC(18,0) NOT NULL,
						  Cliente_Depto NVARCHAR(50) NOT NULL,
						  Cliente_Nacionalidad NVARCHAR(255) NOT NULL,
						  Cliente_Mail_Repetido CHAR(1) DEFAULT 'F',
						  Cliente_Documento_Repetido CHAR(1) DEFAULT 'F')
						  
ALTER TABLE G_N.Clientes ADD CONSTRAINT MailRepeTrueOFalse CHECK (Cliente_Mail_Repetido IN ('F', 'T'))
ALTER TABLE G_N.Clientes ADD CONSTRAINT DocRepeTrueOFalse CHECK (Cliente_Documento_Repetido IN ('F', 'T'))

INSERT INTO G_N.Clientes(Cliente_Documento_Tipo_Id,
						 Cliente_Documento_Nro, 
						 Cliente_Apellido,
						 Cliente_Nombre, 
						 Cliente_Fecha_Nac, 
						 Cliente_Mail,
						 Cliente_Dom_Calle,
						 Cliente_Dom_Nro_Calle,
						 Cliente_Piso,
						 Cliente_Depto,
						 Cliente_Nacionalidad)
	SELECT DISTINCT 1,
					Cliente_Pasaporte_Nro, 
					Cliente_Apellido,
				    Cliente_Nombre, 
			    	Cliente_Fecha_Nac, 
					Cliente_Mail,
					Cliente_Dom_Calle,
					Cliente_Nro_Calle,
					Cliente_Piso,
					Cliente_Depto,
					Cliente_Nacionalidad
	FROM gd_esquema.Maestra
	
UPDATE G_N.Clientes SET Cliente_Mail_Repetido = 'T'
	WHERE Cliente_Mail IN (SELECT Cliente_Mail FROM G_N.Clientes GROUP BY Cliente_Mail HAVING COUNT(*) > 1)
	
UPDATE G_N.Clientes SET Cliente_Documento_Repetido = 'T'
	WHERE CAST(Cliente_Documento_Tipo_Id AS NVARCHAR) + '-' + CAST(Cliente_Documento_Nro AS NVARCHAR) IN 
		(SELECT CAST(Cliente_Documento_Tipo_Id AS NVARCHAR) + '-' + CAST(Cliente_Documento_Nro AS NVARCHAR)
			FROM G_N.Clientes 
			GROUP BY CAST(Cliente_Documento_Tipo_Id AS NVARCHAR) + '-' + CAST(Cliente_Documento_Nro AS NVARCHAR)
			HAVING COUNT(*) > 1)

-- TABLA CONSUMIBLES
CREATE TABLE G_N.Consumibles(Consumible_Codigo NUMERIC(18,0) PRIMARY KEY,
							 Consumible_Descripcion NVARCHAR(255) NOT NULL,
							 Consumible_Precio NUMERIC(18,2) NOT NULL)

INSERT INTO G_N.Consumibles(Consumible_Codigo, 
							Consumible_Descripcion,
							Consumible_Precio)
	SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
	FROM gd_esquema.Maestra 
	WHERE Consumible_Codigo IS NOT NULL

-- TABLA TEMPORAL DE HABITACIONES
SELECT DISTINCT m.Hotel_Ciudad,
				m.Hotel_Calle,
				m.Hotel_Nro_Calle,
				ho.Hotel_Id, 
				m.Habitacion_Numero,
				ha.Habitacion_Id
	INTO G_N.#Habitaciones_Temp
	FROM gd_esquema.Maestra m, G_N.Hoteles ho, G_N.Habitaciones ha
	WHERE ho.Hotel_Ciudad = m.Hotel_Ciudad
	  AND ho.Hotel_Dom_Calle = m.Hotel_Calle
	  AND ho.Hotel_Dom_Nro = m.Hotel_Nro_Calle
	  AND ha.Habitacion_Numero = m.Habitacion_Numero
	  AND ha.Habitacion_Hotel_Id = ho.Hotel_Id
	
-- TABLA RESERVAS
SELECT DISTINCT h.Habitacion_Id,
				m.Regimen_Descripcion,
				r.Regimen_Id,
				m.Reserva_Codigo,
				m.Reserva_Fecha_Inicio,
				m.Reserva_Cant_Noches, 
				m.Cliente_Pasaporte_Nro, 
				m.Cliente_Mail,
				c.Cliente_Id
	INTO G_N.#Reservas_Temp
	FROM gd_esquema.Maestra m, G_N.Clientes c, G_N.#Habitaciones_Temp h, G_N.Regimenes r
	WHERE Reserva_Codigo IS NOT NULL
	  AND m.Cliente_Pasaporte_Nro = c.Cliente_Documento_Nro
	  AND m.Cliente_Mail = c.Cliente_Mail
	  AND m.Hotel_Ciudad = h.Hotel_Ciudad
	  AND m.Hotel_Calle = h.Hotel_Calle
	  AND m.Habitacion_Numero = h.Habitacion_Numero
	  AND m.Regimen_Descripcion = r.Regimen_Descripcion 

CREATE TABLE G_N.Reservas(Reserva_Codigo NUMERIC(18, 0) PRIMARY KEY IDENTITY(110741, 1),
						  Reserva_Cliente_Id INT FOREIGN KEY REFERENCES G_N.Clientes(Cliente_Id),
						  Reserva_Habitacion_Id INT FOREIGN KEY REFERENCES G_N.Habitaciones(Habitacion_Id),
						  Reserva_Regimen_Id INT FOREIGN KEY REFERENCES G_N.Regimenes(Regimen_Id),
						  Reserva_Fecha_Creacion DATE NULL DEFAULT GETDATE(),
						  Reserva_Fecha_Inicio DATE NOT NULL,
						  Reserva_Cant_Noches NUMERIC(18, 0) NOT NULL)

SET IDENTITY_INSERT G_N.Reservas ON;
INSERT INTO G_N.Reservas(Reserva_Codigo,
						 Reserva_Cliente_Id,
						 Reserva_Habitacion_Id,
						 Reserva_Regimen_Id,
						 Reserva_Fecha_Inicio,
						 Reserva_Cant_Noches)
	SELECT Reserva_Codigo, Cliente_Id, Habitacion_Id, Regimen_Id, Reserva_Fecha_Inicio, Reserva_Cant_Noches
	FROM G_N.#Reservas_Temp
SET IDENTITY_INSERT G_N.Reservas OFF;

UPDATE G_N.Reservas SET Reserva_Fecha_Creacion = NULL

-- TABLA ESTADÍAS
CREATE TABLE G_N.Estadias(Estadia_Id NUMERIC(18, 0) PRIMARY KEY IDENTITY(1, 1),
						  Estadia_Reserva_Codigo NUMERIC(18, 0) FOREIGN KEY REFERENCES G_N.Reservas(Reserva_Codigo),
						  Estadia_Fecha_Inicio DATE NOT NULL,
						  Estadia_Cant_Noches NUMERIC(18, 0) NOT NULL)
						  
INSERT INTO G_N.Estadias(Estadia_Reserva_Codigo, Estadia_Fecha_Inicio, Estadia_Cant_Noches)
	SELECT DISTINCT m.Reserva_Codigo, m.Estadia_Fecha_Inicio, m.Estadia_Cant_Noches 
	FROM gd_esquema.Maestra m, G_N.#Reservas_Temp rt
	WHERE m.Reserva_Codigo = rt.Reserva_Codigo
	  AND m.Estadia_Fecha_Inicio IS NOT NULL
	  AND m.Estadia_Cant_Noches IS NOT NULL

-- TABLA FACTURAS
CREATE TABLE G_N.Facturas(Factura_Nro NUMERIC(18, 0) PRIMARY KEY,
						  Factura_Fecha DATE NOT NULL,
						  Factura_Total NUMERIC(18,2) NOT NULL,
						  Factura_Estadia_Id NUMERIC(18,0) FOREIGN KEY REFERENCES G_N.Estadias(Estadia_Id))

INSERT INTO G_N.Facturas
	SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, e.Estadia_Id
		FROM gd_esquema.Maestra m, G_N.Estadias e
		WHERE Factura_Nro IS NOT NULL
		  AND m.Reserva_Codigo = e.Estadia_Reserva_Codigo
		  
-- TABLA ITEMS DE FACTURAS
CREATE TABLE G_N.Factura_Items(Factura_Item_Id NUMERIC(18, 0) IDENTITY(1, 1) PRIMARY KEY,
							   Factura_Item_Factura_Nro NUMERIC(18, 0) FOREIGN KEY REFERENCES G_N.Facturas(Factura_Nro),
							   Factura_Item_Consumible_Codigo NUMERIC(18, 0) NULL FOREIGN KEY REFERENCES G_N.Consumibles(Consumible_Codigo),
							   Factura_Item_Cantidad NUMERIC(18, 0) NOT NULL,
							   Factura_Item_Monto NUMERIC(18, 2) NOT NULL)


INSERT INTO G_N.Factura_Items(Factura_Item_Factura_Nro,
							  Factura_Item_Consumible_Codigo,
							  Factura_Item_Cantidad,
							  Factura_Item_Monto)
	SELECT Factura_Nro, Consumible_Codigo, Item_Factura_Cantidad, Item_Factura_Monto
	FROM gd_esquema.Maestra m
	WHERE Item_Factura_Cantidad IS NOT NULL
	  AND Item_Factura_Monto IS NOT NULL

	  
-- DROP TEMP TABLES
DROP TABLE G_N.#Habitaciones_Temp
DROP TABLE G_N.#Hoteles_Regimenes_Temp
DROP TABLE G_N.#Reservas_Temp