IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [ShopCartClients] (
    [Id] uniqueidentifier NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_ShopCartClients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShopCartItems] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Name] varchar(100) NULL,
    [Quantity] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Image] varchar(100) NULL,
    [ShopCartId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ShopCartItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShopCartItems_ShopCartClients_ShopCartId] FOREIGN KEY ([ShopCartId]) REFERENCES [ShopCartClients] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IDX_Client] ON [ShopCartClients] ([ClientId]);

GO

CREATE INDEX [IX_ShopCartItems_ShopCartId] ON [ShopCartItems] ([ShopCartId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200621021914_ShopCart', N'3.1.3');

GO

