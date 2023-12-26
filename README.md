# TesteVariacaoAtivo

# Sobre o projeto

TesteVariacaoAtivo é uma Aplicação Backend.

A aplicação consiste em 2 consultas de API sendo uma de iintegração com a api do Yahoo Finance e a outra api sendo acessada com os dados salvos na Base de dados, os dados em Json são coletados referentes a variação do preço de um ativo nos últimos 30 pregões, esses dados são transformados em objetos c# e inseridos na Base de dados usando a biblioteca do BulkInsert. Com os dados da API de integração salvos na Base são apresentados o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentados. Dados sendo consumidos da Base de dados.


# Tecnologias utilizadas
## Backend
- C#
- NET Core 6.0
- Arquitetura DDD
- Banco de Dados: SQL Server
- Migrations
- Teste Unitário camada de Serviço do Get da Porcentagem 

# Pré-requisitos: NET Core 6.0 / Visual Studio 2022

```bash
# clonar repositório
https://github.com/thiago-win10/TesteVariacaoAtivo.git

# executar o projeto com Visual Studio 2022 com arquivo Sln
```

```executar migrations via Visual Studio 2022
# Com a migrations já gerada no projeto; Marque o Projeto TesteVariacaoAtivo.Api como "Set as Startup Project" e depois acessar o menu Tools -> Nugget Package Manage -> Package Manager Console -> Selecione Default project o projeto TesteVariacaoAtivo.Infra e inserir o comando: update-database.
Este comando insere as migrations na base de dados configurada no appsettings.
Rodando o projeto com F5 o projeto da Api abre a documentação do Swagger
Caso a migração nao seja efetuda, crie no SQL Server o nome do banco configurado no appsettings e rode o update-database novamente.

# executar a migração com banco de dados do SQL Server linha de comando
```
> dotnet ef database update

# executar o projeto linha de comando
dotnet run
```
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
