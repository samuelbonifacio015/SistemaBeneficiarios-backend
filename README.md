# SistemaBeneficiarios Backend

## Desarrollado en :
- ASP. NET (C#)
- SQL Server

## Instrucciones de instalación :

1. **Clona el repositorio:**
  ```bash
  git clone https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend.git
  cd SistemaBeneficiarios-backend
  ```
![gitclone](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/gitclone.png)
2. **Selecciona las queries (SQLQuery1.sql)**
![executequery](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/executequery.png)
3. **Crea la base de datos en SQL Server y ejecuta las queries una por una:**
    ```sql
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
    ```
![createdbSQLServer](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/createdbSQLServer.png)
4. Corre el proyecto de .NET con tu IDE de preferencia.
![runproject](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/runproject.png)
5. Una vez compilado, abre tu navegador y visita [http://localhost:5002/swagger] para ver probar REST API.
![swaggerdocs](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/swaggerdocs.png)

***Nota: Para pasar al backend, revisa el repositorio adjuntado.***

### Video de prueba: 
![Video](https://github.com/samuelbonifacio015/SistemaBeneficiarios-backend/raw/master/SistemaBeneficiarios/Docs/video.png)
https://drive.google.com/file/d/1516KiKHfzzZpL46vVWW8PCAVUogLIiuN/view?usp=sharing

### Repositorio de Frontend: 
https://github.com/samuelbonifacio015/SistemaBeneficiarios-frontend
