USE GestorDeActasNet
GO

-- Foreign Key Add

ALTER TABLE dbo.eventos  WITH CHECK ADD  CONSTRAINT FK_eventos_tipo_eventos FOREIGN KEY(id_tipo_evento)
REFERENCES dbo.tipo_eventos (id)
GO

ALTER TABLE dbo.eventos  WITH CHECK ADD  CONSTRAINT FK_eventos_evento_personas FOREIGN KEY(id_evento_persona)
REFERENCES dbo.evento_personas (id)
GO

ALTER TABLE dbo.eventos  WITH CHECK ADD  CONSTRAINT FK_eventos_documentos FOREIGN KEY(id_documento)
REFERENCES dbo.documentos (id)
GO

ALTER TABLE dbo.eventos  WITH CHECK ADD  CONSTRAINT FK_eventos_evento_estados FOREIGN KEY(id_estado)
REFERENCES dbo.evento_estados (id)
GO


ALTER TABLE dbo.evento_personas  WITH CHECK ADD  CONSTRAINT FK_evento_personas_eventos FOREIGN KEY(id_evento)
REFERENCES dbo.eventos (id)
GO

ALTER TABLE dbo.evento_personas  WITH CHECK ADD  CONSTRAINT FK_evento_personas_evento_tipo_personas FOREIGN KEY(id_evento_persona)
REFERENCES dbo.evento_tipo_personas (id)
GO

ALTER TABLE dbo.evento_personas  WITH CHECK ADD  CONSTRAINT FK_evento_personas_personas FOREIGN KEY(id_persona)
REFERENCES dbo.personas (id)
GO


ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_generos FOREIGN KEY(id_genero)
REFERENCES dbo.generos (id)
GO

ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_telefonos FOREIGN KEY(id_telefono)
REFERENCES dbo.telefonos (id)
GO

ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_tipo_personas FOREIGN KEY(id_tipo_persona)
REFERENCES dbo.tipo_personas (id)
GO

ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_paises FOREIGN KEY(id_pais)
REFERENCES dbo.paises (id)
GO

ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_departamentos FOREIGN KEY(id_departamento)
REFERENCES dbo.departamentos (id)
GO

ALTER TABLE dbo.personas  WITH CHECK ADD  CONSTRAINT FK_personas_municipios FOREIGN KEY(id_municipio)
REFERENCES dbo.municipios (id)
GO