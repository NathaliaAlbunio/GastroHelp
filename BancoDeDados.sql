use master
go

create database GastroHelp
go

use GastroHelp
go

create table usuario (
	id_usuario integer identity(1,1) primary key,
	nome varchar(50),
	senha varchar(10),
	email varchar(50),
	nome_usuario varchar(50),
	moderador bit default 0
);

insert into usuario (nome, senha, email, nome_usuario, moderador)
values ('Moderador', '123', 'moderador@gastrohelp.com.br', 'moderador', 1);

create table categoria(
	id_categoria integer identity(1,1) primary key,
	nome varchar(300)
);

create table receita (
	id_receita integer identity(1,1) primary key,
	id_categoria int references categoria (id_categoria), 
	id_usuario integer references usuario,
	nivel_dificuldade varchar(20),
	ingredientes varchar(max),
	modo_preparo varchar(max),
	nome_rec varchar(50),
	rendimento varchar(20),
	dica varchar(max),
	publicada bit not null default 0
);