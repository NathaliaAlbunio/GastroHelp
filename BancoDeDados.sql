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

insert into categoria(nome)
values
('Doces'),
('Salgados'),
('Assados'),
('Fritos'),
('Cozidos');


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
	foto varchar(1000),
	data_cadastro datetime not null default getdate()
);

create table favorito (
	id_favorito integer identity(1,1) primary key,
	id_receita int references receita (id_receita), 
	id_usuario integer references usuario (id_usuario),
	data_cadastro datetime not null default getdate()
);

SELECT * FROM usuario;

insert into receita (nome_rec, resumo, id_categoria, id_usuario, nivel_dificuldade, ingredientes, modo_preparo, rendimento, dica, publicada, foto)
select
	nome_rec, resumo, id_categoria, id_usuario, nivel_dificuldade, ingredientes, modo_preparo, rendimento, dica, publicada, foto
from receita where id_receita = 1;


update receita set 
	foto = 'Cerejas.jpg', 
	resumo = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.';
= 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.';


select * from receita;