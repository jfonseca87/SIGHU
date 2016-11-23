-- Inserta los perfiles disponibles en el programa
INSERT INTO PERFILES (Perfil, Activo) VALUES ('Administrativo', 1)
INSERT INTO PERFILES (Perfil, Activo) VALUES ('Guarda de Seguridad', 1)

-- Inserta las opciones del men�
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Armas', 'Arma' , 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Cargos', 'Cargo', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Contratos', 'Contrato', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Empresas', 'Empresa', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Grupos Adjuntos', 'GrupoAdjuntos', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Tipos Adjuntos', 'TipoAdjunto', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Personas', 'Persona', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Usuarios', 'Usuario', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Veh�culos', 'Vehiculo', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Vestuario', 'Vestuario', 1, 1)
INSERT INTO Menu (NMenu, url, Activo, Perfil) VALUES ('Editar Hoja de Vida', 'EditarHV', 1, 2)

-- Inserta los registros relacionados a un usuario administrativo y un usuario guarda de seguridad para pruebas
INSERT INTO PERSONA (NombreP, ApellidoP, TipoDoc, NumeroDoc, Direccion, Telefono, Genero, Celular, Mail, Edad, LugarNac, EstadoCivil, Nacionalidad, RH, NivelAcademico, FotoPerfil, usuario)
VALUES ('Jaime', 'Ramirez', 'CC', '123456789', 'Calle 5 # 13 - 15', '3154678', 'M', '3114567891', 'jaime@gmail.com', 20, 'Bogot�', 'Soltero', 'Colombiano', 'A+', 'Bachiller', 'jramirez.jpg', 1)
INSERT INTO USUARIO (LoginUsuario, PasswordUsuario, Activo, IdPersona, IdPerfil) VALUES ('jramirez', 'abc123', 1, 1, 1)	