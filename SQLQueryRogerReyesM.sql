create database BD_REYES_ROGER
go

use BD_REYES_ROGER

go 

create table Personas
(
identificador int identity(1,1),
nombres varchar(50),
apellidos varchar(50),
numero_identificacion varchar(13),
email varchar(50),
tipo_identificacion varchar(50),
fecha_creacion date
	CONSTRAINT PK_Personas
    PRIMARY KEY NONCLUSTERED (numero_identificacion)
);

go 

alter table Personas 
add identificacion_tipo as concat(numero_identificacion,tipo_identificacion);

go 

alter table Personas
add nombres_apellidos as concat(nombres,apellidos);

go

alter table Personas
ADD CONSTRAINT DF_Fecha_Creacion DEFAULT getdate() FOR fecha_creacion;

go

insert into Personas(nombres, apellidos, numero_identificacion, email, tipo_identificacion ) 
values ('ROGER', 'REYES', '0926286121', 'roger.reyes@outlook.com', 'C');

insert into Personas(nombres, apellidos, numero_identificacion, email, tipo_identificacion ) 
values ('JONATHAN', 'CABRERA', '0918662212001', 'acabrera@outlook.com', 'R');

go

create table Usuarios
(
identificador int identity(1,1),
usuario varchar(50),
pass varchar(50),
fecha_creacion date,
	CONSTRAINT PK_Usuarios
    PRIMARY KEY NONCLUSTERED (usuario)
);

go

alter table Usuarios
ADD CONSTRAINT DF_Usuario_Fecha_Creacion DEFAULT getdate() FOR fecha_creacion;

go

insert into Usuarios(usuario, pass ) 
values ('RREYESM', 'Q12w3e4r');

insert into Usuarios(usuario, pass ) 
values ('CCABRERA', 'Q12w3e4r');

go 

select * from Personas;
select * from Usuarios;

go

create proc sp_buscar_personas
as
	select * from Personas;

go

create proc sp_buscar_personas_por_id
@id int
as
	select * from Personas where identificador = @id;

go

create proc sp_buscar_usuarios
as
	select * from Usuarios;

go

create proc sp_buscar_usuarios_por_id
@id int
as
	select * from Usuarios where identificador = @id;

go