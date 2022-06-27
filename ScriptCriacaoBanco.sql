create table estado(
idestado serial primary key,
nome varchar(100),
sigla varchar(2));

insert into estado
values(1, 'Acre', 'AC'),
(2, 'Alagoas', 'AL'),
(3, 'Amapá', 'AP'),
(4, 'Amazonas', 'AM'),
(5, 'Bahia', 'BA'),
(6, 'Ceará', 'CE'),
(7, 'Espírito Santo', 'ES'),
(8, 'Goiás', 'GO'),
(9, 'Maranhão', 'MA'),
(10, 'Mato Grosso', 'MT'),
(11, 'Mato Grosso do Sul', 'MS'),
(12, 'Minas Gerais', 'MG'),
(13, 'Pará', 'PA'),
(14, 'Paraíba', 'PB'),
(15, 'Pernambuco', 'PE'),
(16, 'Piauí', 'PI'),
(17, 'Rio de Janeiro', 'RJ'),
(18, 'Rio Grande do Norte', 'RN'),
(19, 'Rio Grande do Sul', 'RS'),
(20, 'Rondônia', 'RO'),
(21, 'Roraima', 'RR'),
(22, 'Santa Catarina', 'SC'),
(23, 'São Paulo', 'SP'),
(24, 'Sergipe', 'SE'),
(25, 'Tocantins', 'TO'),
(26, 'Distrito Federal', 'DF'),
(27, 'Paraná', 'PR');

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
	nomecidade varchar(100),
	idestado integer,
	CONSTRAINT fk_idestado FOREIGN KEY (idestado)
	REFERENCES public.estado (idestado) MATCH SIMPLE
	ON UPDATE NO ACTION
	ON DELETE RESTRICT
);