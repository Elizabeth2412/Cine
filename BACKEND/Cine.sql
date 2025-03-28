USE DB_CINE


CREATE TABLE pelicula(
	id_pelicula int PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(150) NOT NULL,
	duracion TIME(2) NOT NULL
);

CREATE TABLE sala_cine(
	id_sala int PRIMARY KEY IDENTITY(1,1),
	nombre VARCHAR(150) NOT NULL,
	estado VARCHAR(10) NOT NULL	
);

CREATE TABLE pelicula_salacine(
	id_pelicula_sala int PRIMARY KEY IDENTITY(1,1),
	id_sala_cine INT FOREIGN KEY REFERENCES sala_cine(id_sala),
	fecha_publicacion DATETIME,
	fecha_fin DATETIME,
	id_pelicula INT FOREIGN KEY REFERENCES pelicula(id_pelicula)
);


INSERT INTO pelicula (nombre, duracion) VALUES ('Avengers','1:30:00')
SELECT * FROM pelicula

-- STORES PROCEDURES DE PELICULA  ---

CREATE PROCEDURE sp_listapelicula 
AS
BEGIN
SELECT
	a.id_Pelicula,
	a.nombre,
	a.duracion
FROM pelicula AS a
END
GO

CREATE PROCEDURE sp_buscarpelicula 
	@nombre VARCHAR(60)
AS
BEGIN
SELECT
	a.id_Pelicula,
	a.nombre,
	a.duracion
FROM pelicula AS a
WHERE nombre = @nombre
END


CREATE PROCEDURE sp_crearpelicula
	@nombre VARCHAR(60),
	@duracion TIME(2)
AS
BEGIN
INSERT INTO pelicula
	(nombre,duracion)
	VALUES
	(@nombre,@duracion)
END


CREATE PROCEDURE sp_editarpelicula
	@id_pelicula int,
	@nombre VARCHAR(60),
	@duracion TIME(2)
AS
BEGIN
UPDATE pelicula SET
	nombre = @nombre,
	duracion = @duracion
WHERE id_pelicula = @id_pelicula
END


CREATE PROCEDURE sp_eliminarpelicula
	@id_pelicula int
AS
BEGIN
	DELETE FROM pelicula WHERE id_pelicula = @id_pelicula
END



-- STORES PROCEDURES DE SALA  ---
CREATE PROCEDURE sp_listasala 
AS
BEGIN
SELECT
	a.id_sala,
	a.nombre,
	a.estado
FROM sala_cine AS a
END
GO

CREATE PROCEDURE sp_buscarsala 
	@id_sala INT
AS
BEGIN
SELECT
	a.id_sala,
	a.nombre,
	a.estado
FROM sala_cine AS a
WHERE id_sala = @id_sala
END


CREATE PROCEDURE sp_crearsala
	@nombre VARCHAR(60),
	@estado VARCHAR(10)
AS
BEGIN
INSERT INTO sala_cine
	(nombre,estado)
	VALUES
	(@nombre,@estado)
END


CREATE PROCEDURE sp_editarsala
	@id_sala int,
	@nombre VARCHAR(60),
	@estado VARCHAR(10)
AS
BEGIN
UPDATE sala_cine SET
	nombre = @nombre,
	estado = @estado
WHERE id_sala = @id_sala
END


CREATE PROCEDURE sp_eliminarsala
	@id_sala INT
AS
BEGIN
	DELETE FROM sala_cine WHERE id_sala = @id_sala
END





SELECT * FROM pelicula WHERE nombre = 'Avatar'
