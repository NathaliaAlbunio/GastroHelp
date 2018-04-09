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
	moderador bit default 0,
	data_cadastro datetime not null default getdate()
);

insert into usuario (nome, senha, email, nome_usuario, moderador)
values ('Moderador', '123', 'moderador@gastrohelp.com.br', 'moderador', 1);

create table categoria (
	id_categoria integer identity(1,1) primary key,
	nome varchar(300),
	data_cadastro datetime not null default getdate()
);

create table receita (
	id_receita integer identity(1,1) primary key,
	nome_rec varchar(250),
	resumo varchar(1000),
	id_categoria int references categoria (id_categoria), 
	id_usuario integer references usuario (id_usuario),
	nivel_dificuldade varchar(50),
	ingredientes varchar(max),
	modo_preparo varchar(max),
	rendimento varchar(100),
	dica varchar(max),
	publicada bit not null default 0,
	data_cadastro datetime not null default getdate()
);

create table favorito (
	id_favorito integer identity(1,1) primary key,
	id_receita int references receita (id_receita), 
	id_usuario integer references usuario (id_usuario),
	data_cadastro datetime not null default getdate()
);