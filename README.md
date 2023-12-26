# TesteVariacaoAtivo

# Sobre o projeto

TesteVariacaoAtivo é uma Aplicação Backend.

A aplicação consiste em uma consulta na API do Yahoo Finance, onde os dados em Json são coletados referentes a variação do preço de um ativo nos últimos 30 pregões. No result da API são apresentados o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentados dados sendo consumidos na Base de dados.


# Tecnologias utilizadas
## Back end
- C#
- NET Core 6.0
- Arquitetura DDD/TDD
- Banco de Dados: SQL Server

## Implantação em produção
- Back end: Heroku
# Como executar o projeto

## Back end
Pré-requisitos: NET Core 6.0 / Visual Studio 2022

```bash
# clonar repositório
git clone https://github.com/devsuperior/sds1-wmazoni

# entrar na pasta do projeto back end
cd backend 

# executar o projeto com Visual Studio 2022 com arquivo Sln
```

# executar a migração com banco de dados do SQL Server comando cmd
```
> dotnet ef migrations add InitialCreate
> dotnet ef database update

# Script da Migration para Rodar no SQL

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

# Autor

Thiago Santos Soares
