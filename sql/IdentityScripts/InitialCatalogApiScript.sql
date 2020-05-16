IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(250) NOT NULL,
    [Description] varchar(500) NOT NULL,
    [Active] bit NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    [Image] varchar(250) NOT NULL,
    [StockQuantity] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200516182207_Initial', N'3.1.3');

GO