CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(100) NOT NULL,
    [Publisher] VARCHAR(50) NOT NULL,
    [PlataformId] INT NOT NULL,
    [Quantity] INT NOT NULL,
    [Year] INT NOT NULL,
    [Price] DECIMAL (7,2) NOT NULL,
    [ShelfId] INT NOT NULL,

    FOREIGN KEY (PlataformId) REFERENCES [dbo].[Plataform](Id),
    FOREIGN KEY (ShelfId) REFERENCES [dbo].[Shelf](Id)
)
