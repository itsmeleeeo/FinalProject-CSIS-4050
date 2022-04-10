CREATE TABLE [dbo].[Shelf]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Color] VARCHAR(25) NOT NULL,
    [Capacity] INT NOT NULL,
    [PlataformId] INT NOT NULL,
    FOREIGN KEY (PlataformId) REFERENCES [dbo].[Plataform](Id)
)
