USE GestorDeActasNet
GO

-- Foreign Key Remove

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_eventos_tipo_eventos')
ALTER TABLE dbo.eventos DROP CONSTRAINT FK_eventos_tipo_eventos
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_eventos_evento_personas')
ALTER TABLE dbo.eventos DROP CONSTRAINT FK_eventos_evento_personas
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_eventos_documentos')
ALTER TABLE dbo.eventos DROP CONSTRAINT FK_eventos_documentos
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_eventos_evento_estados')
ALTER TABLE dbo.eventos DROP CONSTRAINT FK_eventos_evento_estados
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_evento_personas_personas')
ALTER TABLE dbo.evento_personas DROP CONSTRAINT FK_evento_personas_personas
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_evento_personas_evento_tipo_personas')
ALTER TABLE dbo.evento_personas DROP CONSTRAINT FK_evento_personas_evento_tipo_personas
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_evento_personas_eventos')
ALTER TABLE dbo.evento_personas DROP CONSTRAINT FK_evento_personas_eventos
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_tipo_personas')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_tipo_personas
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_telefonos')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_telefonos
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_generos')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_generos
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_paises')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_paises
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_departamentos')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_departamentos
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE name = 'FK_personas_municipios')
ALTER TABLE dbo.personas DROP CONSTRAINT FK_personas_municipios
GO
