CREATE DATABASE SIGHU_BD

GO

USE SIGHU_BD

GO

CREATE TABLE EMPRESA
(
	IdEmpresa int identity(1,1) primary key,
	NIT varchar(12) not null,
	NombreEmpresa varchar(100) not null,
	Activo int not null
)

GO

CREATE TABLE PERSONA
(
	IdPersona int identity(1,1) primary key,
	NombreP varchar(50) not null,
	ApellidoP varchar(50) not null,
	TipoDoc varchar(2) not null,
	NumeroDoc varchar(15) not null,
	Direccion varchar(100) not null,
	Telefono varchar(10),
	Genero varchar(1) not null,
	Celular varchar(15) not null,
	Mail varchar(50) not null,
	Edad int not null,
	LugarNac varchar(50),
	EstadoCivil varchar(10),
	Nacionalidad varchar(20),
	RH varchar(3) not null,
	NivelAcademico varchar(20) not null,
	FotoPerfil varchar(max),
	UsuarioAsig int default 0
)

GO

CREATE TABLE PERFILES
(
	IdPerfil int identity(1,1) primary key,
	Perfil varchar(50) not null,
	Activo int not null,
)

GO

CREATE TABLE GRUPO_ADJUNTO
(
	IdGrupo int identity(1,1) primary key,
	NombreGrupo varchar(50) not null,
	Activo int not null,
)

GO

CREATE TABLE CARGO
(
	IdCargo int identity(1,1) primary key,
	NombreC varchar(100) not null,
	Activo int not null default 1
)

GO

CREATE TABLE ARMA
(
	IdArma int identity(1,1) primary key,
	TipoArma varchar(50) not null,
	SerieArma varchar(50) not null,
	MarcaArma varchar(100) not null
)

GO

CREATE TABLE VESTUARIO
(
	IdVestuario int identity(1,1) primary key,
	NVestuario varchar(100) not null,
	TGorra int not null,
	TCamisa int not null,
	TPantalon int not null,
	TChaqueta int not null,
	TZapatos int not null
)

GO 

CREATE TABLE VEHICULO
(
	IdVehiculo int identity(1,1) primary key,
	MedioTransporte varchar(100) not null,
	PlacaVehiculo varchar(10) not null,
	ModeloVehiculo int not null,
	MarcaVehiculo varchar(50) not null
)

GO 

CREATE TABLE TIPO_ADJUNTO
(
	IdTAdjunto int identity(1,1) primary key,
	CodTitulo varchar(15) not null,
	Nombre varchar(50) not null,
	Activo int not null,
	IdGrupo int,
	foreign key (IdGrupo) references GRUPO_ADJUNTO(IdGrupo)
)

GO

CREATE TABLE USUARIO
(
	IdUsuario int identity(1,1) primary key,
	LoginUsuario varchar(50) not null,
	PasswordUsuario varchar(max) not null,
	Activo int not null,
	IdPersona int,
	IdPerfil int,
	foreign key (IdPersona) references PERSONA(IdPersona),
	foreign key (IdPerfil) references PERFILES(IdPerfil)
)

GO

CREATE TABLE ADJUNTOS
(
	IdAdjunto int identity(1,1) primary key,
	IdTipoAdjunto int not null,
	RutaAdjunto varchar(max) not null,
	IdPersona int,
	foreign key (IdTipoAdjunto) references TIPO_ADJUNTO(IdTAdjunto),
	foreign key (IdPersona) references PERSONA(IdPersona)
)

GO

CREATE TABLE PERSONA_HAS_CARGO
(
	IdPersonaHasCargo int identity(1,1) primary key,
	IdPersona int,
	IdCargo int,
	IdArma int,
	IdVestuario int,
	IdVehiculo int,
	IdEmpresa int,
	AniosExpLab int,
	Actual int,
	foreign key (IdPersona) references PERSONA(IdPersona),
	foreign key (IdCargo) references CARGO(IdCargo),
	foreign key (IdArma) references ARMA(IdArma),
	foreign key (IdVestuario) references VESTUARIO(IdVestuario),
	foreign key (IdVehiculo) references VEHICULO(IdVehiculo),
	foreign key (IdEmpresa) references EMPRESA(IdEmpresa)
)

GO

CREATE TABLE MENU
(
	idMenu int identity(1,1) primary key,
	NMenu varchar(50),
	url varchar(50),
	Activo int,
	Perfil int
)