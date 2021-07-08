CREATE TABLE [dbo].[Usuario] (
	[ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Nome] nvarchar(254) NOT NULL, 
	[Email] nvarchar(254) NOT NULL, 
	[Senha] nvarchar(254) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Condutor] (
	[ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Nome] nvarchar(254) NOT NULL, 
	[CPF] nvarchar(20) NOT NULL, 
	[Telefone] nvarchar(20) NOT NULL, 
	[Email] nvarchar(254), 
	[CNH] nvarchar(20) NOT NULL, 
	[DataNascimento] date NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Veiculo] (
	[ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[Placa] nvarchar(20) NOT NULL, 
	[Modelo] nvarchar(75) NOT NULL, 
	[Marca] nvarchar(75) NOT NULL, 
	[Cor] nvarchar(75) NOT NULL, 
	[AnoFabricacao] int NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[VeiculoCompraVenda] (
	[ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[CondutorCompradorID] int NOT NULL, 
	[CondutorVendedorID] int, 
	[VeiculoID] int NOT NULL, 
	[Data] date NOT NULL, 
	FOREIGN KEY ([VeiculoID])
		REFERENCES [dbo].[Veiculo] ([ID])
		ON UPDATE CASCADE ON DELETE CASCADE, 
	FOREIGN KEY ([CondutorCompradorID])
		REFERENCES [dbo].[Condutor] ([ID])
		ON UPDATE CASCADE ON DELETE CASCADE
) ON [PRIMARY]
GO

INSERT INTO [Usuario] ([Nome],[Email],[Senha]) VALUES (N'Administrador',N'admin@teste.com',N'123456');