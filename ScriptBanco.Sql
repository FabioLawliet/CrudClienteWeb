create table estado(
id serial primary key,
nome varchar(100),
sigla varchar(2));

create table cidade(
id serial primary key,
nome varchar(100)
);

create table cliente(
	id serial primary key,
	nome varchar(100),
	cpfcnpj varchar(14),
	rgie varchar(12),
	ativo bool,
	endereco varchar(100),
	numero varchar(8),
	bairro varchar(50),
	cep varchar(8),
	complemento varchar(100),
	idcidade integer,
	idestado integer,
	CONSTRAINT "fk_idcidade" FOREIGN KEY (idcidade)
	REFERENCES public.cidade (id) MATCH SIMPLE
	ON UPDATE NO ACTION
	ON DELETE RESTRICT,
	CONSTRAINT "fk_idestado" FOREIGN KEY (idestado)
	REFERENCES public.estado (id) MATCH SIMPLE
	ON UPDATE NO ACTION
	ON DELETE RESTRICT
);