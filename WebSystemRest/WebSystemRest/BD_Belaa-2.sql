if db_id('BD_Belaa') is not null
begin
	use master
	drop database BD_Belaa
end
go

create database BD_Belaa
go


use BD_Belaa
go

CREATE table tb_medida(
	id_med int IDENTITY(1,1) primary key,	
	desc_med varchar(100) not null)
GO
create table tb_ingredientes(
	id_ing int primary key IDENTITY(1,1) ,
	desc_ing varchar(100) not null,
	stock_ing int not null,
	costo_ing decimal(5,2) not null,
	id_med int not null references tb_medida)
go

create table tb_tipo(
	id_tipo int primary key IDENTITY(1,1) ,
	desc_tipo varchar(50) not null)
go

create table tb_plato(
	id_plato int primary key IDENTITY(1,1) ,
	nom_plato varchar(50) not null,
	id_tipo int not null references tb_tipo)
go



create procedure usp_listar_platos
as
select nom_plato, desc_tipo
from tb_plato p
join tb_tipo t
on p.id_tipo = t.id_tipo
go



create table tb_menu(
	id_menu int primary key IDENTITY(1,1) ,
	cant_menu int not null,
	fec_menu varchar(10) not null,
	tiempoTotal_menu varchar(10))
go

create table tb_detalleMenu(
	id_menu int not null references tb_menu ,
	id_plato int not null references tb_plato,
	primary key(id_menu, id_plato))
go

create table tb_receta(
	id_plato int references tb_plato,
	id_ing int references tb_ingredientes,
	rec_cantidad int,
	primary key(id_plato, id_ing))
go

insert into tb_tipo(desc_tipo) values('Refresco')
insert into tb_tipo(desc_tipo) values('Segundo')
insert into tb_tipo(desc_tipo) values('Postre')
GO
select * from tb_tipo
GO
insert into tb_medida(desc_med) values('kilogramos')
insert into tb_medida(desc_med) values('onzas')
insert into tb_medida(desc_med) values('gramos')
insert into tb_medida(desc_med) values('libras')
insert into tb_medida(desc_med) values('farenheit')
insert into tb_medida(desc_med) values('centigrados')
insert into tb_medida(desc_med) values('gas mark')
insert into tb_medida(desc_med) values('onzas fluidas')
insert into tb_medida(desc_med) values('tazas')
insert into tb_medida(desc_med) values('cucharadas')
insert into tb_medida(desc_med) values('cucharaditas')
GO
SELECT * FROM tb_medida
GO

create table logueo(
	usuario varchar(20) primary key,
	clave varchar(20))
	go


	insert into logueo values('jj', 'asdasd');
	insert into logueo values('junior', '123456');
	insert into tb_plato values('Arroz con pollo', 2);

	/*
	1. Lista de platos
	2. Despues vas a agregar un plato.
	3.
	
	
	*/ 

	select * from tb_plato