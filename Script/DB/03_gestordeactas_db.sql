USE GestorDeActasNet
GO

-- Table Add

-- Section Eventos

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'documentos')
DROP TABLE dbo.documentos
GO
CREATE TABLE dbo.documentos 
(
    id int identity NOT NULL,
	path_root nvarchar(200) NOT NULL,
    path_url nvarchar(200) NOT NULL,
	fecha_registro datetime	NOT NULL,
    CONSTRAINT PK_documentos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'tipo_eventos')
DROP TABLE dbo.tipo_eventos
GO
CREATE TABLE dbo.tipo_eventos 
(
    id int identity NOT NULL,
    tipo_evento nvarchar(200) NOT NULL,
    descripcion	nvarchar(2000) NULL
    CONSTRAINT PK_tipo_eventos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'eventos')
DROP TABLE dbo.eventos
GO
CREATE TABLE dbo.eventos
(
    id int identity NOT NULL,
	id_tipo_evento int NOT NULL,
    id_evento_persona int NOT NULL,
    id_documento int NOT NULL,
    id_estado int NOT NULL,
    fecha_registro datetime NOT NULL,
	fecha_programa date NULL,
	no_registro int NULL,
	no_libro int NULL,
	no_folio int NULL	
    CONSTRAINT PK_eventos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'evento_estados')
DROP TABLE dbo.evento_estados
GO
CREATE TABLE dbo.evento_estados
(
    id int identity NOT NULL,
    nombre_estado nvarchar(50) NOT NULL,
    CONSTRAINT PK_evento_estados PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'evento_personas')
DROP TABLE dbo.evento_personas
GO
CREATE TABLE dbo.evento_personas
(
    id int identity NOT NULL,
    id_persona int NOT NULL,
    id_evento int NOT NULL,
    id_evento_persona int NOT NULL,
    CONSTRAINT PK_evento_personas PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'evento_tipo_personas')
DROP TABLE dbo.evento_tipo_personas
GO
CREATE TABLE dbo.evento_tipo_personas
(
    id int identity NOT NULL,
    evento_tipo_persona nvarchar(50) NOT NULL,
    CONSTRAINT PK_evento_tipo_personas PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'generos')
DROP TABLE dbo.generos
GO
CREATE TABLE dbo.generos 
(
    id int identity NOT NULL,
    genero nvarchar(50) NOT NULL,
    CONSTRAINT PK_generos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'personas')
DROP TABLE dbo.personas
GO
CREATE TABLE dbo.personas
(
	id int identity NOT NULL,
	primer_nombre nvarchar(50) NOT NULL,
	segundo_nombre nvarchar(50) NULL,
	tercer_nombre nvarchar(50) NULL,
	primer_apellido nvarchar(50) NOT NULL,
	segundo_apellido nvarchar(50) NULL,
	apellido_casada nvarchar(50) NULL,
	fecha_nacimiento date NOT NULL,
	avenida numeric(4, 0) NULL,
	calle nvarchar(20) NULL,
	casa nvarchar(20) NULL,
	zona numeric(4, 0) NULL,
	manzana numeric(4, 0) NULL,
	lote numeric(4, 0) NULL,
	residencia nvarchar(50) NULL,
	barrio nvarchar(50) NULL,
	edificio nvarchar(50) NULL,
	ciudad nvarchar(50) NULL,
	id_municipio int NOT NULL,
	id_departamento int NOT NULL,
	id_pais int NOT NULL,
	id_tipo_persona int NOT NULL,
	id_genero int NOT NULL,
	id_telefono int NOT NULL,	
	CONSTRAINT PK_personas PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'telefonos')
DROP TABLE dbo.telefonos
GO
CREATE TABLE dbo.telefonos
(
    id int identity NOT NULL,
    telefono nvarchar(50) NOT NULL,
    CONSTRAINT PK_telefonos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'tipo_personas')
DROP TABLE dbo.tipo_personas
GO
CREATE TABLE dbo.tipo_personas
(
    id int identity NOT NULL,
    tipo_persona nvarchar(50) NOT NULL,
    CONSTRAINT PK_tipo_personas PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'usuarios')
DROP TABLE dbo.usuarios
GO
CREATE TABLE dbo.usuarios
(
    id int identity NOT NULL,
    usuario nvarchar(20) NOT NULL,
	correo	nvarchar(50) NULL,
    password_encrypt nvarchar(20) NOT NULL,
    CONSTRAINT PK_usuarios PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'paises')
DROP TABLE dbo.paises
GO
CREATE TABLE dbo.paises
(
    id int identity NOT NULL,
    pais nvarchar(50) NOT NULL,
    CONSTRAINT PK_paises PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'departamentos')
DROP TABLE dbo.departamentos
GO
CREATE TABLE dbo.departamentos 
(
    id int identity NOT NULL,
    id_pais INT NOT NULL,
	departamento nvarchar(50) NOT NULL,
    CONSTRAINT PK_departamentos PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'municipios')
DROP TABLE dbo.municipios
GO
CREATE TABLE dbo.municipios 
(
    id int identity NOT NULL,
    id_pais INT NOT NULL,
	id_departamento INT NOT NULL,
	municipio nvarchar(50) NOT NULL,
    CONSTRAINT PK_municipios PRIMARY KEY CLUSTERED (id ASC)
) ON [PRIMARY] 
GO

