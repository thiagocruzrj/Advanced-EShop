IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Vouchers] (
    [Id] uniqueidentifier NOT NULL,
    [Code] varchar(100) NOT NULL,
    [Percent] decimal(18,2) NULL,
    [DiscountValue] decimal(18,2) NULL,
    [Quantity] int NOT NULL,
    [DiscountVoucher] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [UseDate] datetime2 NULL,
    [ExpirationDate] datetime2 NOT NULL,
    [Active] bit NOT NULL,
    [Used] bit NOT NULL,
    CONSTRAINT [PK_Vouchers] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200902135524_Voucher', N'3.1.4');

GO

