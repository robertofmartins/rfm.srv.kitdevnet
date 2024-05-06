/*
drop table tb_produto;
drop table tb_item;
*/

create table tb_item
(
	id int identity(1, 1) not null,
	descricao varchar(100) not null,
	quantidade int not null,
	precoUnitario numeric(18,2) not null,
	ativo bit not null,
	dataCriacao datetime not null
);


create table tb_produto
(
	id int identity(1, 1) not null,
	descricao varchar(100) not null,
	quantidade int not null,
	precoUnitario numeric(18,2) not null,
	ativo bit not null,
	dataCriacao datetime not null
);

alter table tb_item add constraint pk_item primary key (id);
alter table tb_produto add constraint pk_produto primary key (id);

insert into tb_item values ('mesa', 10, 159.90, 1, getdate()); 
insert into tb_item values ('mouse', 25, 75.45, 1, getdate());

insert into tb_produto values ('celular', 70, 59.90, 1, getdate()); 
insert into tb_produto values ('capa', 11, 175.45, 1, getdate());

