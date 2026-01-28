/* Setup Inicial */
CREATE DATABASE SistemaBeneficiarios;
GO

USE SistemaBeneficiarios;
GO

/* Tabla de DocumentoIdentidad */
CREATE TABLE DocumentoIdentidad (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Abreviatura VARCHAR(10) NOT NULL,
	Pais VARCHAR(50) NOT NULL,
	Longitud INT NOT NULL,
	SoloNumeros BIT NOT NULL,
	ACTIVO BIT NOT NULL DEFAULT 1
);
GO

/* Tabla de Beneficiario
 /? Constraint para referenciar al ID de la Tabla DcoumentoIdentidad
*/
CREATE TABLE Beneficiario (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombres VARCHAR(100) NOT NULL,
	Apellidos VARCHAR(100) NOT NULL,
	DocumentoIdentidadId INT NOT NULL,
	NumeroDocumento VARCHAR(20) NOT NULL,
	FechaNacimiento DATE NOT NULL,
	SEXO CHAR(1) NOT NULL,
    CONSTRAINT FK_Beneficiario_Documento FOREIGN KEY (DocumentoIdentidadId) REFERENCES DocumentoIdentidad(Id)
);
GO

/**	Procedures **/

/* /? Listar documentos activos */

CREATE PROCEDURE sp_GetActiveDocumentosIdentidad
AS
BEGIN
    SELECT Id, Nombre, Abreviatura, Pais, Longitud, SoloNumeros
    FROM DocumentoIdentidad
    WHERE Activo = 1;
END;
GO

/* /? Insertar beneficiario */

CREATE PROCEDURE sp_InsertBeneficiario
    @Nombres VARCHAR(100), @Apellidos VARCHAR(100), @DocumentoIdentidadId INT, 
    @NumeroDocumento VARCHAR(20), @FechaNacimiento DATE, @Sexo CHAR(1)
AS
BEGIN
    INSERT INTO Beneficiario (Nombres, Apellidos, DocumentoIdentidadId, NumeroDocumento, FechaNacimiento, Sexo)
    VALUES (@Nombres, @Apellidos, @DocumentoIdentidadId, @NumeroDocumento, @FechaNacimiento, @Sexo);
    SELECT CAST(SCOPE_IDENTITY() as int);
END;
GO

/* /? Listar beneficiarios */
CREATE PROCEDURE sp_GetBeneficiarios
AS
BEGIN
    SELECT b.Id, b.Nombres, b.Apellidos, b.NumeroDocumento, b.FechaNacimiento, b.Sexo,
       d.Nombre AS TipoDocumento, d.Abreviatura, d.Pais
    FROM Beneficiario b
    INNER JOIN DocumentoIdentidad d ON b.DocumentoIdentidadId = d.Id;
END;
GO

/* /? Editar beneficiarios */
CREATE PROCEDURE sp_EditarBeneficiario
    @Id INT, @Nombres VARCHAR(100), @Apellidos VARCHAR(100), @DocumentoIdentidadId INT,
    @NumeroDocumento VARCHAR(20), @FechaNacimiento DATE, @Sexo CHAR(1)
AS
BEGIN
    UPDATE Beneficiario
    SET Nombres = @Nombres, Apellidos = @Apellidos, DocumentoIdentidadId = @DocumentoIdentidadId,
    NumeroDocumento = @NumeroDocumento, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo
    WHERE Id = @Id;
END;
GO

/* /? Eliminar beneficiarios */
CREATE PROCEDURE sp_EliminarBeneficiario
    @Id INT 
AS
BEGIN
    DELETE FROM Beneficiario WHERE Id = @Id;
END;
GO

/* Por ultimo, insertamos datos semilla iniciales para la demo */
INSERT INTO DocumentoIdentidad
(Nombre, Abreviatura, Pais, Longitud, SoloNumeros, Activo)
VALUES
('DNI', 'DNI', 'Peru', 8, 1, 1),
('Pasaporte', 'PAS', 'Internacional', 9, 0, 1),
('Carnet de Extranjer�a', 'CE', 'Peru', 9, 1, 1),
('Documento Inactivo', 'OLD', 'Chile', 6, 1, 0);
