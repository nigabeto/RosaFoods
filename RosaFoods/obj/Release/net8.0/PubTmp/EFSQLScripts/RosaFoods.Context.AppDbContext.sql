IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240508222612_PrimeiraMigracao'
)
BEGIN
    CREATE TABLE [Categorias] (
        [CategoriaId] int NOT NULL IDENTITY,
        [CategoriaNome] nvarchar(100) NOT NULL,
        [Descricao] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Categorias] PRIMARY KEY ([CategoriaId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240508222612_PrimeiraMigracao'
)
BEGIN
    CREATE TABLE [Pizzas] (
        [PizzaId] int NOT NULL IDENTITY,
        [Nome] nvarchar(80) NOT NULL,
        [DescricaoCurta] nvarchar(200) NOT NULL,
        [DescricaoDetalhada] nvarchar(200) NOT NULL,
        [Preco] decimal(10,2) NOT NULL,
        [ImagemUrl] nvarchar(200) NULL,
        [ImagemThumbnailUrl] nvarchar(200) NULL,
        [IsPizzaFavorita] bit NOT NULL,
        [EmEstoque] bit NOT NULL,
        [CategoriaId] int NOT NULL,
        CONSTRAINT [PK_Pizzas] PRIMARY KEY ([PizzaId]),
        CONSTRAINT [FK_Pizzas_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([CategoriaId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240508222612_PrimeiraMigracao'
)
BEGIN
    CREATE INDEX [IX_Pizzas_CategoriaId] ON [Pizzas] ([CategoriaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240508222612_PrimeiraMigracao'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240508222612_PrimeiraMigracao', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509121017_PopularCategorias'
)
BEGIN
    INSERT INTO Categorias(CategoriaNome, Descricao) VALUES('Normal','Pizza preparada com ingredientes normais')
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509121017_PopularCategorias'
)
BEGIN
    INSERT INTO Categorias(CategoriaNome,Descricao) VALUES('Doce','Pizza preparada com ingredientes doces')
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509121017_PopularCategorias'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240509121017_PopularCategorias', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509122458_PopularPizzas'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com fermentação natural, molho de tomate rústico, mussarela tradicional e orégano.','A Pizza de Mussarela é coberta com molho de tomate, queijo tipo mussarela, azeitonas pretas e orégano e massa com fermentação natural.',1, '~/Images/pizza-mussarela.jpg','~/Images/pizza-mussarela.jpg', 1 ,'Mussarela', 30.50)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509122458_PopularPizzas'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com farinha de trigo, linguiça calabresa, cebola, azeitona e orégano','Combinação de Linguiça Calabresa, rodelas de cebolas frescas, azeitonas pretas, mussarela, polpa de tomate, orégano e massa especial.',1, '~/Images/pizza-calabresa.jpg','~/Images/pizza-calabresa.jpg', 1 ,'Calabresa', 35.70)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509122458_PopularPizzas'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com farinha de trigo, mussarela de búfala, tomate, queijo parmesão, azeite de oliva, manjericão, sal e fermento biológico.','Composta pelos ingredientes Farinha, água, sal e fermento e molho de tomate San Marzano, muçarela de búfala, azeite de oliva extra virgem e manjericão.',1, '~/Images/marguerita.jpg','~/Images/marguerita.jpg', 1 ,'Marguerita', 41.90)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509122458_PopularPizzas'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(2,'Mistura frutas como abacaxi, pêssego, figo, ameixa e cereja','Deliciosa pizza leve,  molho caseiro feito com muçarela e lombo canadense, bananas caramelizadas, figos, pêssegos, abacaxi e cerejas. ',1, '~/Images/morango.jpg','~/Images/morango.jpg', 0 ,'California', 55.80)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240509122458_PopularPizzas'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240509122458_PopularPizzas', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510222922_PopularPizzasTeste'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com fermentação natural, molho de tomate, presunto, mussarela tradicional e orégano.','A Pizza de Presunto é coberta com molho de tomate, queijo tipo mussarela, presunto e massa com fermentação natural.',1, 'RosaFoods/wwwroot/Images/presunto.jpg','RosaFoods/wwwroot/Images/presunto.jpg', 1 ,'Presunto', 40.50)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510222922_PopularPizzasTeste'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240510222922_PopularPizzasTeste', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510224811_PopularPizzaTeste02'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com fermentação natural, molho de tomate, presunto, mussarela, ervilhas e orégano.','A Pizza de Portuguesa é coberta com molho de tomate, queijo tipo mussarela, presunto e massa com fermentação natural.',1, 'https://github.com/nigabeto/RosaFoods/blob/50f68255d99f372e11413cc6fbf81a7d9854e8ac/RosaFoods/wwwroot/Images/pizza-portuguesa.jpg','https://github.com/nigabeto/RosaFoods/blob/50f68255d99f372e11413cc6fbf81a7d9854e8ac/RosaFoods/wwwroot/Images/pizza-portuguesa.jpg', 1 ,'Portuguesa', 39.40)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510224811_PopularPizzaTeste02'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240510224811_PopularPizzaTeste02', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510230556_PopularPizzasTeste03'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Combo especial','Monte seu combo',1, 'https://drive.google.com/file/d/1cWgfzeaavrZdE36uXAXjX9HCb__gbWT2/view?usp=sharing','https://drive.google.com/file/d/1cWgfzeaavrZdE36uXAXjX9HCb__gbWT2/view?usp=sharing', 1 ,'Combo', 70.50)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510230556_PopularPizzasTeste03'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240510230556_PopularPizzasTeste03', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510233901_PopularPizza04'
)
BEGIN
    INSERT INTO Pizzas(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsPizzaFavorita,Nome,Preco) VALUES(1,'Feita com fermentação natural, molho de tomate, presunto, mussarela, ervilhas e orégano.','A Pizza de Portuguesa é coberta com molho de tomate, queijo tipo mussarela, presunto e massa com fermentação natural.',1, 'C:\RosaFoods\RosaFoods\RosaFoods\wwwroot\Images\pizza-portuguesa.jpg','C:\RosaFoods\RosaFoods\RosaFoods\wwwroot\Images\pizza-portuguesa.jpg', 0 ,'Portuguesa', 39.40)
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240510233901_PopularPizza04'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240510233901_PopularPizza04', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240512163058_CarrinhoCompraItem'
)
BEGIN
    CREATE TABLE [CarrinhoCompraItens] (
        [CarrinhoCompraItemId] int NOT NULL IDENTITY,
        [PizzaId] int NULL,
        [Quantidade] int NOT NULL,
        [CarrinhoCompraId] nvarchar(200) NULL,
        CONSTRAINT [PK_CarrinhoCompraItens] PRIMARY KEY ([CarrinhoCompraItemId]),
        CONSTRAINT [FK_CarrinhoCompraItens_Pizzas_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizzas] ([PizzaId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240512163058_CarrinhoCompraItem'
)
BEGIN
    CREATE INDEX [IX_CarrinhoCompraItens_PizzaId] ON [CarrinhoCompraItens] ([PizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240512163058_CarrinhoCompraItem'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240512163058_CarrinhoCompraItem', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240513225601_PedidoDetalhes'
)
BEGIN
    CREATE TABLE [Pedidos] (
        [PedidoId] int NOT NULL IDENTITY,
        [Nome] nvarchar(50) NOT NULL,
        [Sobrenome] nvarchar(50) NOT NULL,
        [Endereco1] nvarchar(100) NOT NULL,
        [Endereco2] nvarchar(100) NULL,
        [Cep] nvarchar(10) NOT NULL,
        [Estado] nvarchar(10) NULL,
        [Cidade] nvarchar(50) NULL,
        [Telefone] nvarchar(25) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [PedidoTotal] decimal(18,2) NOT NULL,
        [TotalItensPedido] int NOT NULL,
        [PedidoEnviado] datetime2 NOT NULL,
        [PedidoEntregueEm] datetime2 NULL,
        CONSTRAINT [PK_Pedidos] PRIMARY KEY ([PedidoId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240513225601_PedidoDetalhes'
)
BEGIN
    CREATE TABLE [PedidoDetalhes] (
        [PedidoDetalheId] int NOT NULL IDENTITY,
        [PedidoId] int NOT NULL,
        [PizzaId] int NOT NULL,
        [Quantidade] int NOT NULL,
        [Preco] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_PedidoDetalhes] PRIMARY KEY ([PedidoDetalheId]),
        CONSTRAINT [FK_PedidoDetalhes_Pedidos_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedidos] ([PedidoId]) ON DELETE CASCADE,
        CONSTRAINT [FK_PedidoDetalhes_Pizzas_PizzaId] FOREIGN KEY ([PizzaId]) REFERENCES [Pizzas] ([PizzaId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240513225601_PedidoDetalhes'
)
BEGIN
    CREATE INDEX [IX_PedidoDetalhes_PedidoId] ON [PedidoDetalhes] ([PedidoId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240513225601_PedidoDetalhes'
)
BEGIN
    CREATE INDEX [IX_PedidoDetalhes_PizzaId] ON [PedidoDetalhes] ([PizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240513225601_PedidoDetalhes'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240513225601_PedidoDetalhes', N'8.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240514160916_AdicionarIdentity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240514160916_AdicionarIdentity', N'8.0.5');
END;
GO

COMMIT;
GO

