IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Jogadores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Jogadores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Jogos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [DataLancamento] datetime2 NOT NULL,
    [JogadorId] uniqueidentifier NULL,
    CONSTRAINT [PK_Jogos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jogos_Jogadores_JogadorId] FOREIGN KEY ([JogadorId]) REFERENCES [Jogadores] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [JogosJogadores] (
    [Id] uniqueidentifier NOT NULL,
    [IdJogador] uniqueidentifier NOT NULL,
    [IdJogo] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_JogosJogadores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JogosJogadores_Jogadores_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogadores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_JogosJogadores_Jogos_IdJogador] FOREIGN KEY ([IdJogador]) REFERENCES [Jogos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Jogos_JogadorId] ON [Jogos] ([JogadorId]);

GO

CREATE INDEX [IX_JogosJogadores_IdJogador] ON [JogosJogadores] ([IdJogador]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200914193122_InitialCreate', N'3.1.8');

GO

