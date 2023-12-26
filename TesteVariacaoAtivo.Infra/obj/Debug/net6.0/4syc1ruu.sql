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

CREATE TABLE [Assets] (
    [Id] uniqueidentifier NOT NULL,
    [AssetName] varchar(250) NOT NULL,
    [DataAsset] datetime NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Assets] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231226061915_CodeFirstTableAsset', N'6.0.0');
GO

COMMIT;
GO

