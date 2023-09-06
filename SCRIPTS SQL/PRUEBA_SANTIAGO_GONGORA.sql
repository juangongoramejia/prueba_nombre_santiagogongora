CREATE DATABASE prueba_santiago_gongora

CREATE TABLE pacientes(
id int PRIMARY KEY IDENTITY,
N�mero_documento varchar(100),
Nombres varchar(100),
Apellidos varchar(100),
Correo varchar(100),
Telefono varchar(100),
Fecha_nacimiento datetime,
Estado_afiliacion bit
)

INSERT INTO pacientes (N�mero_documento, Nombres, Apellidos, Correo, Telefono, Fecha_nacimiento, Estado_afiliacion)
VALUES
('1234567890', 'Juan', 'P�rez', 'juan@example.com', '555-123-4567', '1990-05-15', 1),
('9876543210', 'Mar�a', 'G�mez', 'maria@example.com', '555-987-6543', '1985-09-20', 0),
('4567890123', 'Carlos', 'Rodr�guez', 'carlos@example.com', '555-234-5678', '2000-12-10', 1);
 
CREATE PROCEDURE sp_Registrar(
@N�mero_documento varchar(100),
@Nombres varchar(100),
@Apellidos varchar(100),
@Correo varchar(100),
@Telefono varchar(100),
@Fecha_nacimiento datetime,
@Estado_afiliacion bit
)
as
begin
	INSERT INTO pacientes (N�mero_documento, Nombres, Apellidos, Correo,
	Telefono, Fecha_nacimiento, Estado_afiliacion)
	VALUES (@N�mero_documento, @Nombres, @Apellidos, @Correo, @Telefono,
	@Fecha_nacimiento, @Estado_afiliacion)
end


CREATE PROCEDURE sp_Editar(
@id int,
@N�mero_documento varchar(100),
@Nombres varchar(100),
@Apellidos varchar(100),
@Correo varchar(100),
@Telefono varchar(100),
@Fecha_nacimiento datetime,
@Estado_afiliacion bit
)
AS
BEGIN
UPDATE pacientes SET N�mero_documento = @N�mero_documento,
Nombres = @Nombres,
Apellidos = @Apellidos,
Correo = @Correo,
Telefono = @Telefono,
Fecha_nacimiento = @Fecha_nacimiento,
Estado_afiliacion =	@Estado_afiliacion
WHERE id = @id 
END


CREATE PROCEDURE sp_Eliminar(
@id int )
as begin 
	DELETE FROM pacientes WHERE id = @id
end

CREATE PROCEDURE sp_Listar
AS
BEGIN
SELECT * FROM pacientes
END


