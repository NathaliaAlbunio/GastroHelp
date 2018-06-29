create database GastroHelp
go

use GastroHelp
go

create table usuario 
(
	id_usuario		integer identity(1,1) primary key,
	nome			varchar(50),
	senha			varchar(10),
	email			varchar(50),
	nome_usuario	varchar(50),
	moderador		bit default 0,
	data_cadastro	datetime not null default getdate()
);
GO


insert into usuario (nome, senha, email, nome_usuario, moderador)
values ('Moderador', '123', 'moderador@gastrohelp.com.br', 'moderador', 1);
insert into usuario (nome, senha, email, nome_usuario, moderador)
values ('Tiago Andrade', '123', 'tgnandrade@gmail.com', 'tiago', 0);
GO

create table categoria 
(
	id_categoria	integer identity(1,1) primary key,
	nome			varchar(300),
	data_cadastro	datetime not null default getdate()
);
GO

insert into categoria(nome)
values
('Doces'),
('Salgados'),
('Assados'),
('Fritos'),
('Massas'),
('Ensopados'),
('Cozidos');
GO

create table receita 
(
	id_receita			integer identity(1,1) primary key,
	nome_rec			varchar(250),
	resumo				varchar(1000),
	id_categoria		int references categoria (id_categoria), 
	id_usuario			integer references usuario (id_usuario),
	nivel_dificuldade	varchar(50),
	ingredientes		varchar(max),
	modo_preparo		varchar(max),
	rendimento			varchar(100),
	dica				varchar(max),
	publicada			bit not null default 0,
	foto				varchar(1000),
	data_cadastro		datetime not null default getdate()
);



create table favorito 
(
	id_favorito		integer identity(1,1) primary key,
	id_receita		int references receita (id_receita), 
	id_usuario		integer references usuario (id_usuario),
	data_cadastro	datetime not null default getdate()
);

-- campo calculado que retorna a quantidade de favoritos de uma receita
IF OBJECT_ID(N'dbo.buscar_favoritos', N'FN') IS NOT NULL
    DROP FUNCTION [dbo].[buscar_favoritos]
GO

create function [dbo].[buscar_favoritos](@id_receita int) returns int
as
begin
    return (
		select count(*) from favorito f where f.id_receita = @id_receita
    );
end
go

-- criando campo de quantidade em estoque calculado
alter table receita add qtd_favorito as dbo.[buscar_favoritos](id_receita);
go

create table comentario
(
	id_comentario	integer identity(1,1) primary key,
	id_usuario		int references usuario(id_usuario),
	id_receita		int references receita(id_receita),
	texto			varchar(500),
	DataHora		Datetime not null default getdate()
);
GO

