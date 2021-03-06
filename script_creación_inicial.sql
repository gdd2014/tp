USE GD2C2014
GO
CREATE SCHEMA G_N
GO

---------------------------------------------------------------------------------------------------------
-- TABLAS------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------

-- TABLA TEMPORAL DE HOTELES Y REGIMENES ----------------------------------------------------------------------------
SELECT DISTINCT Hotel_Ciudad, 
				Hotel_Calle, 
				Hotel_Nro_Calle,
				Hotel_CantEstrella, 
				Regimen_Descripcion, 
				Regimen_Precio
INTO G_N.#Hoteles_Regimenes_Temp
FROM gd_esquema.Maestra

-- TABLA HOTELES ----------------------------------------------------------------------------------------------------	
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

-- TABLA REGÍMENES --------------------------------------------------------------------------------------------------
CREATE TABLE G_N.Regimenes(Regimen_Id INT IDENTITY(1,1) PRIMARY KEY,
						   Regimen_Descripcion NVARCHAR(255) NOT NULL,
						   Regimen_Precio NUMERIC(18,2) NOT NULL)
				
INSERT INTO G_N.Regimenes(Regimen_Descripcion, Regimen_Precio)	   
	SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
	FROM G_N.#Hoteles_Regimenes_Temp

-- TABLA RELACIÓN HOTELES CON REGÍMENES -----------------------------------------------------------------------------
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

-- TABLA TIPOS DE HABITACION ----------------------------------------------------------------------------------------
CREATE TABLE G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo INT PRIMARY KEY,
								  Habitacion_Tipo_Descripcion NVARCHAR(255) NOT NULL,
								  Habitacion_Tipo_Porcentual NUMERIC(18,2) NOT NULL,
								  Habitacion_Tipo_Capacidad INT)

INSERT INTO G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo,
								 Habitacion_Tipo_Descripcion,
								 Habitacion_Tipo_Porcentual)			
	SELECT DISTINCT Habitacion_Tipo_Codigo, Habitacion_Tipo_Descripcion, Habitacion_Tipo_Porcentual 
	FROM gd_esquema.Maestra
		
-- TABLA HABITACIONES -----------------------------------------------------------------------------------------------
CREATE TABLE G_N.Habitaciones(Habitacion_Id INT IDENTITY(1,1) PRIMARY KEY,
							  Habitacion_Hotel_Id INT NOT NULL FOREIGN KEY REFERENCES G_N.Hoteles(Hotel_Id),
							  Habitacion_Numero NUMERIC(18,0) NOT NULL,
							  Habitacion_Piso NUMERIC(18,0) NOT NULL,
							  Habitacion_Es_Frente CHAR(1) NOT NULL CHECK (Habitacion_Es_Frente IN ('S', 'N')),
							  Habitacion_Tipo_Codigo INT NOT NULL FOREIGN KEY REFERENCES G_N.Habitacion_Tipos(Habitacion_Tipo_Codigo),
							  Habitacion_Descripcion NVARCHAR(255) NOT NULL DEFAULT '',
							  Estado CHAR NOT NULL CHECK (Estado IN ('A', 'N')) DEFAULT 'A')

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
							  
-- TABLA TIPOS DE DOCUMENTO ---------------------------------------------------------------------------------------
CREATE TABLE G_N.Documento_Tipos(Documento_Tipo_Id INT IDENTITY (1,1) PRIMARY KEY,
								 Documento_Tipo_Descripcion VARCHAR(30) NOT NULL)

INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('Pasaporte')
INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('D.N.I.')
INSERT INTO G_N.Documento_Tipos(Documento_Tipo_Descripcion) VALUES ('Cédula de Identidad')

-- TABLA CLIENTES -------------------------------------------------------------------------------------------------
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
						  Cliente_Documento_Repetido CHAR(1) DEFAULT 'F',
						  Estado CHAR NOT NULL CHECK (Estado IN ('A', 'N')) DEFAULT 'A')
						  
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

-- TABLA CONSUMIBLES -----------------------------------------------------------------------------------------------
CREATE TABLE G_N.Consumibles(Consumible_Codigo NUMERIC(18,0) PRIMARY KEY,
							 Consumible_Descripcion NVARCHAR(255) NOT NULL,
							 Consumible_Precio NUMERIC(18,2) NOT NULL)

INSERT INTO G_N.Consumibles(Consumible_Codigo, 
							Consumible_Descripcion,
							Consumible_Precio)
	SELECT DISTINCT Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
	FROM gd_esquema.Maestra 
	WHERE Consumible_Codigo IS NOT NULL

-- TABLA TEMPORAL DE HABITACIONES ----------------------------------------------------------------------------------
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
	
	
-- TABLA USUARIOS --------------------------------------------------------------------------------------------------
CREATE TABLE G_N.Usuarios(Usuario_Id INT IDENTITY(1,1) PRIMARY KEY,
						  Usuario_UserName NVARCHAR(50) NOT NULL UNIQUE,
						  Usuario_Password NVARCHAR(255) NOT NULL,
						  Usuario_Nombre_Completo NVARCHAR(255)NOT NULL,	
						  Usuario_Documento_Tipo_Id INT NOT NULL FOREIGN KEY REFERENCES G_N.Documento_Tipos(Documento_Tipo_Id),
						  Usuario_Documento_Nro NUMERIC(18,0) NOT NULL,
						  Usuario_Mail NVARCHAR(255) NOT NULL,
						  Usuario_Telefono NVARCHAR(30),
						  Usuario_Direccion NVARCHAR (255),
						  Usuario_Fecha_Nac DATE NOT NULL,
						  Estado CHAR NOT NULL CHECK (Estado IN ('A', 'N')) DEFAULT 'A',
						  Usuario_Logins_Fallidos INT NOT NULL DEFAULT 0)
		
-- ADMIN		
INSERT INTO G_N.Usuarios(Usuario_UserName,
						 Usuario_Password,
						 Usuario_Nombre_Completo,	
						 Usuario_Documento_Tipo_Id,
						 Usuario_Documento_Nro,
						 Usuario_Mail,
						 Usuario_Telefono,
						 Usuario_Direccion,
						 Usuario_Fecha_Nac)	
	VALUES('admin', 
		   'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 
		   'Martin Perez',
		   1, 
		   33204625,
		   'martinperez@gmail.com', 
		   '011 4-555-5555', 
		   'Av. Rivadavia 123',
		   '1985-12-12')

-- GUEST GENERICO		   
INSERT INTO G_N.Usuarios(Usuario_UserName,
						 Usuario_Password,
						 Usuario_Nombre_Completo,	
						 Usuario_Documento_Tipo_Id,
						 Usuario_Documento_Nro,
						 Usuario_Mail,
						 Usuario_Telefono,
						 Usuario_Direccion,
						 Usuario_Fecha_Nac)	
	VALUES('guest', 
		   'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 
		   'Martin Perez',
		   2, 
		   33669541,
		   'martinsuarez@gmail.com', 
		   '011 4-555-5556', 
		   'Av. Rivadavia 124',
		   '1985-12-16')
	
-- TABLA RESERVAS
-- TABLA RESERVAS TEMP ---------------------------------------------------------------------------------------------
SELECT DISTINCT h.Habitacion_Id,
				m.Regimen_Descripcion,
				r.Regimen_Id,
				m.Reserva_Codigo,
				m.Reserva_Fecha_Inicio,
				m.Reserva_Cant_Noches, 
				m.Cliente_Pasaporte_Nro, 
				m.Cliente_Mail,
				c.Cliente_Id,
				(m.Regimen_Precio + m.Hotel_CantEstrella * m.Hotel_Recarga_Estrella) * (m.Habitacion_Tipo_Codigo % 1000) AS Precio_Por_Noche
	INTO G_N.#Reservas_Temp
	FROM gd_esquema.Maestra m, G_N.Clientes c, G_N.#Habitaciones_Temp h, G_N.Regimenes r
	WHERE Reserva_Codigo IS NOT NULL
	  AND m.Cliente_Pasaporte_Nro = c.Cliente_Documento_Nro
	  AND m.Cliente_Mail = c.Cliente_Mail
	  AND m.Hotel_Ciudad = h.Hotel_Ciudad
	  AND m.Hotel_Calle = h.Hotel_Calle
	  AND m.Habitacion_Numero = h.Habitacion_Numero
	  AND m.Regimen_Descripcion = r.Regimen_Descripcion 
	  
CREATE TABLE G_N.Reserva_Estados(Reserva_Estado_Id INT PRIMARY KEY IDENTITY(1, 1),
								 Reserva_Estado_Descripcion NVARCHAR(50) NOT NULL DEFAULT '')
								 
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva correcta')
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva modificada')
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva cancelada por Recepción')
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva cancelada por Cliente')
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva cancelada por No-Show')
INSERT INTO G_N.Reserva_Estados VALUES ('Reserva efectivizada')

-- TABLA RESERVAS --------------------------------------------------------------------------------------------------
CREATE TABLE G_N.Reservas(Reserva_Codigo INT PRIMARY KEY IDENTITY(110741, 1),
						  Reserva_Cliente_Id INT FOREIGN KEY REFERENCES G_N.Clientes(Cliente_Id),
						  Reserva_Regimen_Id INT FOREIGN KEY REFERENCES G_N.Regimenes(Regimen_Id),
						  Reserva_Fecha_Creacion DATE NULL DEFAULT GETDATE(),
						  Reserva_Fecha_Inicio DATE NOT NULL,
						  Reserva_Fecha_Fin DATE NOT NULL,
						  Reserva_Precio_Por_Noche NUMERIC(18,2),
						  Reserva_Estado_Id INT NOT NULL DEFAULT 1 FOREIGN KEY REFERENCES G_N.Reserva_Estados(Reserva_Estado_Id),
						  Reserva_Usuario_Id INT NOT NULL DEFAULT 2 FOREIGN KEY REFERENCES G_N.Usuarios(Usuario_Id),
						  Reserva_Fecha_Cancelacion DATE,
						  Reserva_Motivo_Cancelacion NVARCHAR(100))

SET IDENTITY_INSERT G_N.Reservas ON;
INSERT INTO G_N.Reservas(Reserva_Codigo,
						 Reserva_Cliente_Id,
						 Reserva_Regimen_Id,
						 Reserva_Fecha_Inicio,
						 Reserva_Fecha_Fin,
						 Reserva_Precio_Por_Noche)
	SELECT Reserva_Codigo, 
		   Cliente_Id, Regimen_Id, 
		   Reserva_Fecha_Inicio, 
		   DATEADD(DAY, Reserva_Cant_Noches, Reserva_Fecha_Inicio),
		   Precio_Por_Noche
	FROM G_N.#Reservas_Temp
SET IDENTITY_INSERT G_N.Reservas OFF;

-- TABLA RESERVAS_HABITACIONES ---------------------------------------------------------------------------------------
CREATE TABLE G_N.Reservas_Habitaciones(Reserva_Codigo INT FOREIGN KEY REFERENCES G_N.Reservas(Reserva_Codigo),
									   Habitacion_Id INT FOREIGN KEY REFERENCES G_N.Habitaciones(Habitacion_Id),
									   PRIMARY KEY (Reserva_Codigo, Habitacion_Id))
									   

INSERT INTO G_N.Reservas_Habitaciones(Reserva_Codigo, Habitacion_Id)
	SELECT Reserva_Codigo, Habitacion_Id FROM G_N.#Reservas_Temp

-- TABLA ESTADÍAS ---------------------------------------------------------------------------------------
CREATE TABLE G_N.Estadias(Estadia_Reserva_Codigo INT PRIMARY KEY FOREIGN KEY REFERENCES G_N.Reservas(Reserva_Codigo),
						  Estadia_Fecha_Inicio DATE NOT NULL,
						  Estadia_Fecha_Fin DATE NULL)
						  
INSERT INTO G_N.Estadias(Estadia_Reserva_Codigo, Estadia_Fecha_Inicio, Estadia_Fecha_Fin)
	SELECT DISTINCT m.Reserva_Codigo, m.Estadia_Fecha_Inicio, DATEADD(DAY, m.Estadia_Cant_Noches, m.Estadia_Fecha_Inicio) 
	FROM gd_esquema.Maestra m, G_N.#Reservas_Temp rt
	WHERE m.Reserva_Codigo = rt.Reserva_Codigo
	  AND m.Estadia_Fecha_Inicio IS NOT NULL
	  AND m.Estadia_Cant_Noches IS NOT NULL
	  
CREATE TABLE G_N.Estadias_Clientes(Estadia_Reserva_Codigo INT FOREIGN KEY REFERENCES G_N.Estadias(Estadia_Reserva_Codigo),
								   Cliente_Id INT FOREIGN KEY REFERENCES G_N.Clientes(Cliente_Id),
								       PRIMARY KEY (Estadia_Reserva_Codigo, Cliente_Id))
									   
INSERT INTO G_N.Estadias_Clientes(Estadia_Reserva_Codigo, Cliente_Id)
	SELECT e.Estadia_Reserva_Codigo, r.Reserva_Cliente_Id FROM G_N.Estadias e 
		JOIN G_N.Reservas r ON e.Estadia_Reserva_Codigo = r.Reserva_Codigo
	

-- TABLA FACTURAS ----------------------------------------------------------------------------------------
CREATE TABLE G_N.Pago_Tipos(Pago_Tipo_Id INT IDENTITY(1,1) PRIMARY KEY,
							Pago_Tipo_Descripcion NVARCHAR(50) NOT NULL)
							
INSERT INTO G_N.Pago_Tipos VALUES ('Efectivo')
INSERT INTO G_N.Pago_Tipos VALUES ('Tarjeta de crédito')

CREATE TABLE G_N.Facturas(Factura_Nro NUMERIC(18, 0) PRIMARY KEY,
						  Factura_Fecha DATE NOT NULL,
						  Factura_Total NUMERIC(18,2) NOT NULL,
						  Factura_Estadia_Reserva_Codigo INT FOREIGN KEY REFERENCES G_N.Estadias(Estadia_Reserva_Codigo),
						  Factura_Pago_Tipo_Id INT NOT NULL FOREIGN KEY REFERENCES G_N.Pago_Tipos(Pago_Tipo_Id),
						  Factura_Tarjeta_Numero DECIMAL(18,0),
						  Factura_Tarjeta_Cod_Seg INT)

INSERT INTO G_N.Facturas
	SELECT DISTINCT m.Factura_Nro, m.Factura_Fecha, m.Factura_Total, e.Estadia_Reserva_Codigo, 1, NULL, NULL
		FROM gd_esquema.Maestra m, G_N.Estadias e
		WHERE Factura_Nro IS NOT NULL
		  AND m.Reserva_Codigo = e.Estadia_Reserva_Codigo
		  
-- TABLA ITEMS DE FACTURAS -------------------------------------------------------------------------------
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

	
-- TABLA ESTADIAS CONSUMIBLES -------------------------------------------------------------------------------	
CREATE TABLE G_N.Estadias_Consumibles(Id INT PRIMARY KEY IDENTITY(1,1),
									  Estadia_Reserva_Codigo INT FOREIGN KEY REFERENCES G_N.Estadias(Estadia_Reserva_Codigo),
									  Consumible_Codigo NUMERIC(18,0) FOREIGN KEY REFERENCES G_N.Consumibles(Consumible_Codigo),
									  Consumible_Cantidad INT NOT NULL,
									  Habitacion_Id INT FOREIGN KEY REFERENCES G_N.Habitaciones(Habitacion_Id))
  
INSERT INTO G_N.Estadias_Consumibles(Estadia_Reserva_Codigo,
									 Consumible_Codigo,
									 Consumible_Cantidad)
	SELECT Reserva_Codigo, Consumible_Codigo, SUM(Item_Factura_Cantidad)
	FROM gd_esquema.Maestra m
	WHERE Item_Factura_Cantidad IS NOT NULL
	  AND Item_Factura_Monto IS NOT NULL
	  AND Consumible_Codigo IS NOT NULL
	GROUP BY Reserva_Codigo, Consumible_Codigo
	
	
-- DROP TEMP TABLES --------------------------------------------------------------------------------------
DROP TABLE G_N.#Habitaciones_Temp
DROP TABLE G_N.#Hoteles_Regimenes_Temp
DROP TABLE G_N.#Reservas_Temp

-- TABLA USUARIOS-HOTELES ----------------------------------------------------------------------------------------
CREATE TABLE G_N.Usuarios_Hoteles(Usuario_Id INT FOREIGN KEY REFERENCES G_N.Usuarios(Usuario_Id),
								  Hotel_Id INT FOREIGN KEY REFERENCES G_N.Hoteles(Hotel_Id),
								  PRIMARY KEY (Usuario_Id, Hotel_Id))
		   
INSERT INTO G_N.Usuarios_Hoteles VALUES(1, 1)		   
		   
-- TABLA ROLES --------------------------------------------------------------------------------------------

CREATE TABLE G_N.Roles(Rol_Id INT IDENTITY(1,1) PRIMARY KEY,
					   Rol_Nombre NVARCHAR(50) NOT NULL UNIQUE,
					   Estado CHAR NOT NULL CHECK (Estado IN ('A', 'N')) DEFAULT 'A')
				
INSERT INTO G_N.Roles(Rol_Nombre) VALUES ('Administrador General')
INSERT INTO G_N.Roles(Rol_Nombre) VALUES ('Recepcionista')						 
INSERT INTO G_N.Roles(Rol_Nombre) VALUES ('Guest')		

-- TABLA USUARIOS_ROLES -----------------------------------------------------------------------------------

CREATE TABLE G_N.Usuarios_Roles(Usuario_Id INT FOREIGN KEY REFERENCES G_N.Usuarios(Usuario_Id),
								Rol_Id INT FOREIGN KEY REFERENCES G_N.Roles(Rol_Id),
								PRIMARY KEY (Usuario_Id, Rol_Id))

INSERT INTO G_N.Usuarios_Roles VALUES(1, 1)
								
-- TABLA FUNCIONALIDADES ----------------------------------------------------------------------------------
CREATE TABLE G_N.Funcionalidades(Funcionalidad_Id INT IDENTITY(1,1) PRIMARY KEY,
								 Funcionalidad_Nombre NVARCHAR(50) NOT NULL UNIQUE)
								 
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Cliente')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Hotel')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Habitacion')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Regimen Estadia')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Generar Reserva')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Modificar Reserva')	
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Cancelar Reserva')
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Registrar Estadia')	
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Registrar Consumibles')
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Facturar Publicaciones')
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('Listado Estadistico')		
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Usuario')
INSERT INTO G_N.Funcionalidades(Funcionalidad_Nombre) VALUES ('ABM Rol')

-- TABLA ROLES-FUNCIONALIDADES ----------------------------------------------------------------------------

CREATE TABLE G_N.Roles_Funcionalidades(Rol_Id INT FOREIGN KEY REFERENCES G_N.Roles(Rol_Id),
									   Funcionalidad_Id INT FOREIGN KEY REFERENCES G_N.Funcionalidades(Funcionalidad_Id),
								       PRIMARY KEY (Rol_Id, Funcionalidad_Id))

-- FUNCIONALIDADES DEL ADMINISTRADOR ---------------------------------------------------------------------

INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 1) /* Administrador - ABM Cliente */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 2) /* Administrador - ABM Hotel */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 3) /* Administrador - ABM Habitacion */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 4) /* Administrador - ABM Regimen de Estadia */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 5) /* Administrador - Generar Reserva  */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 6) /* Administrador - Modificar Reserva */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 7) /* Administrador - Cancelar Reserva */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 8) /* Administrador - Registrar Estadía */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 9) /* Administrador - Registrar Consumibles */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 10) /* Administrador - Facturar Publicaciones */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 11) /* Administrador - Listado Estadistico */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 12) /* Administrador - ABM Usuarios */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (1, 13) /* Administrador - ABM Roles */

-- FUNCIONALIDADES DE RECEPCIONISTA ---------------------------------------------------------------------

INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 1) /* Administrador - ABM Cliente */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 5) /* Administrador - Generar Reserva  */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 6) /* Administrador - Modificar Reserva */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 7) /* Administrador - Cancelar Reserva */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 8) /* Administrador - Registrar Estadía */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 9) /* Administrador - Registrar Consumibles */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 10) /* Administrador - Facturar Publicaciones */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (2, 11) /* Administrador - Listado Estadistico */

-- FUNCIONALIDADES DE GUEST ----------------------------------------------------------------------------

INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (3, 5) /* Administrador - Generar Reserva  */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (3, 6) /* Administrador - Modificar Reserva */
INSERT INTO G_N.Roles_Funcionalidades(Rol_Id, Funcionalidad_Id) VALUES (3, 7) /* Administrador - Cancelar Reserva */

-- BAJAS DE HOTEL --------------------------------------------------------------------------------------

CREATE TABLE G_N.Hoteles_Cerrados(Hotel_Id INT FOREIGN KEY REFERENCES G_N.Hoteles(Hotel_Id),
							      Desde_Fecha DATE NOT NULL,
								  Hasta_Fecha DATE NOT NULL,
								  Motivo VARCHAR(250) NOT NULL,
								  PRIMARY KEY (Hotel_Id, Desde_Fecha, Hasta_Fecha))
								 
UPDATE G_N.Hoteles SET Hotel_Ciudad = RTRIM(Hotel_Ciudad)
UPDATE G_N.Hoteles SET Hotel_Pais = 'Argentina'
UPDATE G_N.Hoteles SET Hotel_Nombre = ''
UPDATE G_N.Hoteles SET Hotel_Mail = ''
UPDATE G_N.Hoteles SET Hotel_Fecha_Creacion = GETDATE()

UPDATE G_N.Habitacion_Tipos SET Habitacion_Tipo_Capacidad = 1 WHERE Habitacion_Tipo_Codigo = 1001
UPDATE G_N.Habitacion_Tipos SET Habitacion_Tipo_Capacidad = 2 WHERE Habitacion_Tipo_Codigo = 1002
UPDATE G_N.Habitacion_Tipos SET Habitacion_Tipo_Capacidad = 3 WHERE Habitacion_Tipo_Codigo = 1003
UPDATE G_N.Habitacion_Tipos SET Habitacion_Tipo_Capacidad = 4 WHERE Habitacion_Tipo_Codigo = 1004
UPDATE G_N.Habitacion_Tipos SET Habitacion_Tipo_Capacidad = 5 WHERE Habitacion_Tipo_Codigo = 1005

-- SE CANCELAN LAS RESERVAS POR NO SHOW
UPDATE G_N.Reservas
	SET Reserva_Estado_Id = 5,
	    Reserva_Fecha_Cancelacion = Reserva_Fecha_Inicio,
	    Reserva_Motivo_Cancelacion = 'Dada de baja automáticamente por no show' 
	WHERE Reserva_Fecha_Inicio < GETDATE()
	  AND Reserva_Codigo NOT IN (SELECT Estadia_Reserva_Codigo FROM G_N.Estadias)

--------------------------------------------------------------------------------------------------------
-- STORED PROCEDURES -----------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------
GO
-- REGISTRO LOGIN FALLIDO ------------------------------------------------------------------------------
CREATE PROCEDURE G_N.Registrar_Login_Fallido 
	@Username NVARCHAR (50)
AS
BEGIN 
	DECLARE @Cantidad_Logins INT 
	SET @Cantidad_Logins = (SELECT U.Usuario_logins_Fallidos FROM G_N.Usuarios U WHERE @Username = Usuario_UserName)
	SET @Cantidad_Logins = (@Cantidad_Logins + 1)
	IF (@Cantidad_Logins >= 3)
	BEGIN
		UPDATE G_N.Usuarios
		SET Estado = 'N'
		WHERE @Username = Usuario_UserName
	END
	UPDATE G_N.Usuarios
	SET Usuario_Logins_Fallidos = @Cantidad_Logins
	WHERE @Username = Usuario_UserName
END
GO

-- RESETEO LOGIN FALLIDO -------------------------------------------------------------------------------
CREATE PROCEDURE G_N.Resetear_Login_fallido 
	@Username NVARCHAR (50)
AS
BEGIN 
	UPDATE G_N.Usuarios 
	SET Estado = 'A',
	Usuario_Logins_Fallidos = 0
	WHERE Usuario_UserName = @Username
END
GO

-- BAJA MOMENTANEA DE HOTEL ----------------------------------------------------------------------------
CREATE PROCEDURE G_N.Baja_Momentanea_Hotel @Hotel_Id INT, @Desde DATE, @Hasta DATE, @Motivo NVARCHAR (100)
AS
BEGIN 
INSERT INTO G_N.Hoteles_Cerrados
VALUES (@Hotel_Id, @Desde, @Hasta, @Motivo)

END
GO

-- PROCEDURE PARA CANCELAR LAS RESERVAS QUE NO SE PRESENTARON DEL DÍA DE AYER ---------------------------
CREATE PROCEDURE G_N.Bajar_Reservas_De_Ayer_Por_No_Show
AS
BEGIN 
	UPDATE G_N.Reservas
	SET Reserva_Estado_Id = 5,
	    Reserva_Fecha_Cancelacion = GETDATE(),
	    Reserva_Motivo_Cancelacion = 'Dada de baja automáticamente por no show' 
	WHERE Reserva_Fecha_Inicio = Convert(DATE, DATEADD(DAY, -1, GETDATE()))
	  AND Reserva_Codigo NOT IN (SELECT Estadia_Reserva_Codigo FROM G_N.Estadias)
END
GO


---------------------------------------------------------------------------------------------------------
-- FUNCIONES --------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------

-- FUNCION RECIBE ID HOTEL Y DEVUELVE REGIMENES ACTIVOS -------------------------------------------------
CREATE FUNCTION G_N.Regimenes_Necesarios_Hotel(@Hotel_id INT)
RETURNS TABLE
AS 
	RETURN (SELECT DISTINCT Res.Reserva_Regimen_Id 
			FROM G_N.Habitaciones Hab, G_N.Reservas_Habitaciones  RH, G_N.Reservas Res 
			WHERE Hab.Habitacion_Hotel_Id = @Hotel_id
			  AND Res.Reserva_Fecha_Cancelacion IS NULL
			  AND Hab.Habitacion_Id = RH.Habitacion_Id
			  AND RH.Reserva_Codigo = Res.Reserva_Codigo
		      AND Res.Reserva_fecha_fin > = GETDATE()) 
		
GO
			
-- FUNCION QUE RETORNA SI UN HOTEL TIENE RESERVAS EN UN PERIODO DADO
CREATE FUNCTION G_N.Hot_Tiene_Reservas_en_Periodo(@Hotel_id INT, @Inicio DATE, @Fin DATE)
RETURNS INT
AS 
BEGIN
	DECLARE @Resultado INT, @Cuenta INT
	SET @Cuenta = (SELECT  COUNT(Res.Reserva_Codigo) Q
					 FROM G_N.Habitaciones Hab, G_N.Reservas_Habitaciones RH, G_N.Reservas Res
					 WHERE Hab.Habitacion_Id = RH.Habitacion_Id
					   AND RH.Reserva_Codigo = Res.Reserva_Codigo
					   AND Res.Reserva_Fecha_Cancelacion IS NULL
					   AND Hab.Habitacion_Hotel_Id = @Hotel_id
					   AND ((Res.Reserva_Fecha_inicio BETWEEN @Inicio AND @Fin) 
					    OR (Res.Reserva_Fecha_fin BETWEEN @Inicio AND @Fin) 
						OR (Res.Reserva_Fecha_inicio < @Inicio AND Res.Reserva_Fecha_Fin > @Fin)))
						
	IF (@Cuenta > 0) SET @Resultado = 1
	ELSE SET @Resultado = 0
	RETURN @Resultado 
END

GO
			
-- FUNCION QUE RETORNA SI UNA HABITACION TIENE RESERVAS EN UN PERIODO DADO
CREATE FUNCTION G_N.Hab_Tiene_Reservas_en_Periodo(@Habitacion_id INT, @Inicio DATE, @Fin DATE)
RETURNS INT
AS 
BEGIN
	DECLARE @Resultado INT, @Cuenta INT
	SET @Cuenta = (SELECT  COUNT(Res.Reserva_Codigo) Q
					 FROM G_N.Habitaciones Hab, G_N.Reservas_Habitaciones RH, G_N.Reservas Res
					 WHERE Hab.Habitacion_Id = @Habitacion_id
					   AND Hab.Habitacion_Id = RH.Habitacion_Id
					   AND RH.Reserva_Codigo = Res.Reserva_Codigo
					   AND Res.Reserva_Fecha_Cancelacion IS NULL
					   
					   AND ((Res.Reserva_Fecha_inicio BETWEEN @Inicio AND @Fin) 
					    OR (Res.Reserva_Fecha_fin BETWEEN @Inicio AND @Fin) 
						OR (Res.Reserva_Fecha_inicio < @Inicio AND Res.Reserva_Fecha_Fin > @Fin)))
						
	IF (@Cuenta > 0) SET @Resultado = 1
	ELSE SET @Resultado = 0
	RETURN @Resultado 
END

GO

-- Funcion que retorna si un hotel está abierto en el período determinado
CREATE FUNCTION G_N.Hotel_Esta_Abierto_en_Periodo(@Hotel_Id INT, @Inicio DATE, @Fin DATE)
RETURNS INT
AS 
BEGIN
	DECLARE @Resultado INT, @Cuenta INT
	SET @Cuenta = (SELECT  COUNT(hc.Hotel_Id) Q
					 FROM G_N.Hoteles_Cerrados hc
					 WHERE hc.Hotel_Id = @Hotel_Id		   
					   AND ((hc.Desde_Fecha BETWEEN @Inicio AND @Fin) 
					    OR (hc.Hasta_Fecha BETWEEN @Inicio AND @Fin) 
						OR (hc.Desde_Fecha < @Inicio AND hc.Hasta_Fecha > @Fin)))
						
	IF (@Cuenta > 0) SET @Resultado = 0
	ELSE SET @Resultado = 1
	RETURN @Resultado 
END

GO

CREATE FUNCTION G_N.Hotel_De_Reserva(@Reserva_codigo INT)
RETURNS INT
AS 
BEGIN
	DECLARE @Resultado INT
	SET @Resultado = (SELECT DISTINCT h.Habitacion_Hotel_Id 
							FROM G_N.Reservas r 
							JOIN G_N.Reservas_Habitaciones rh ON r.Reserva_Codigo = rh.Reserva_Codigo
							JOIN G_N.Habitaciones h ON rh.Habitacion_Id = h.Habitacion_Id
							WHERE r.Reserva_Codigo = @Reserva_codigo)
	RETURN @Resultado;
END


GO

CREATE FUNCTION G_N.Capacidad_De_Reserva(@Reserva_codigo INT)
RETURNS INT
AS 
BEGIN
	DECLARE @Resultado INT
	SET @Resultado = (SELECT SUM(ht.Habitacion_Tipo_Capacidad)
							FROM G_N.Reservas_Habitaciones rh 
							JOIN G_N.Habitaciones h ON rh.Habitacion_Id = h.Habitacion_Id
							JOIN G_N.Habitacion_Tipos ht ON ht.Habitacion_Tipo_Codigo = h.Habitacion_Tipo_Codigo
						WHERE rh.Reserva_Codigo = @Reserva_codigo
						GROUP BY rh.Reserva_Codigo)

	RETURN @Resultado;
END

GO
  
CREATE FUNCTION G_N.Fecha_Max(@val1 DATE, @val2 DATE)
RETURNS DATE
AS
BEGIN
  IF @val1 > @val2
    RETURN @val1
  RETURN ISNULL(@val2,@val1)
END

GO

CREATE FUNCTION G_N.Fecha_Min(@val1 DATE, @val2 DATE)
RETURNS DATE
AS
BEGIN
  IF @val1 < @val2
    RETURN @val1
  RETURN ISNULL(@val2,@val1)
END

GO

CREATE FUNCTION G_N.Puntos_Por_Consumibles(@Monto NUMERIC(18,2), @Codigo_Consumible NUMERIC(18,0))
	RETURNS INT
	AS
	BEGIN
		DECLARE @Resultado INT
		IF @Codigo_Consumible IS NULL SET @Resultado = 0
		ELSE SET @Resultado = @Monto / 5
		
		RETURN @Resultado
	END

GO
	
CREATE FUNCTION G_N.Puntos_Por_Estadia(@Monto NUMERIC(18,2), @Codigo_Consumible NUMERIC(18,0))
	RETURNS INT
	AS
	BEGIN
		DECLARE @Resultado INT
		IF @Codigo_Consumible IS NOT NULL SET @Resultado = 0
		ELSE SET @Resultado = @Monto / 10
		
		RETURN @Resultado
	END
