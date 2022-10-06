# Gestor 2.0

Proyecto seminario

# Base de datos - Script

Pasos
- Ejcutar los archivos .sql en orden de numeracion
- Ej. 01_ .. 02_ .. 03_
- actualizar cadena de conexion configurado en appsetting.json con el id = db_connection

# Usuarios - Credenciales

Usuario por default #1
- User: admin
- Password: admin

# Actualizacion password
Ejecutar query

Aplicar Script
ALTER TABLE usuarios ALTER COLUMN password_encrypt nvarchar(50) NOT NULL

Delete
DELETE FROM usuarios;

INSERT INTO usuarios (usuario,correo,password_encrypt) VALUES ('administrador','admin@admin.com','+MKE1emqCFkHIRAhzg+fuA==')
INSERT INTO usuarios (usuario,correo,password_encrypt) VALUES ('admin','admin@admin.com','+MKE1emqCFkHIRAhzg+fuA==')
