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

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Patronymic] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Phone] float NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Genre] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Publishers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    CONSTRAINT [PK_Publishers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [AuthorId] int NOT NULL,
    [PublisherId] int NOT NULL,
    [ReleaseYear] nvarchar(max) NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Books_Publishers_PublisherId] FOREIGN KEY ([PublisherId]) REFERENCES [Publishers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [BookIssues] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [BookId] int NOT NULL,
    [IssueDate] datetime2 NOT NULL,
    [DeliveryDate] datetime2 NOT NULL,
    CONSTRAINT [PK_BookIssues] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BookIssues_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookIssues_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Debtors] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [IssueId] int NOT NULL,
    CONSTRAINT [PK_Debtors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Debtors_BookIssues_IssueId] FOREIGN KEY ([IssueId]) REFERENCES [BookIssues] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Debtors_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id])
);
GO

CREATE INDEX [IX_BookIssues_BookId] ON [BookIssues] ([BookId]);
GO

CREATE INDEX [IX_BookIssues_ClientId] ON [BookIssues] ([ClientId]);
GO

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
GO

CREATE INDEX [IX_Books_GenreId] ON [Books] ([GenreId]);
GO

CREATE INDEX [IX_Books_PublisherId] ON [Books] ([PublisherId]);
GO

CREATE INDEX [IX_Debtors_ClientId] ON [Debtors] ([ClientId]);
GO

CREATE INDEX [IX_Debtors_IssueId] ON [Debtors] ([IssueId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211209203948_Migration1', N'5.0.0');
GO

COMMIT;
GO

