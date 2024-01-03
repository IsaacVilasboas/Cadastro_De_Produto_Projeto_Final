create table Produtos
(
	Id integer identity,
	CodBarra varchar(20) primary key not null,
	Nome_Produto varchar (50)not null,
	Nome_Fornecedor varchar (50)not null,
	Preco decimal (10,2) not null,
	Qtd integer not null,
	Categoria varchar (30) not null,
	Tipo varchar (20),
	Sabor varchar (20),
	Peso varchar (10),
	Recipiente varchar(10),
	DataCadastro DateTime
)
