CREATE TABLE [dbo].[Sales]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [ProductId] INT NOT NULL,
    [ProductName] VARCHAR(100) NOT NULL,
    [Quantity] INT NOT NULL,
    [SalesTotal] DECIMAL (7,2) NOT NULL,
    [UserId] INT NOT NULL,

    FOREIGN KEY (ProductId) REFERENCES [dbo].[Product](Id),
    FOREIGN KEY (UserId) REFERENCES [dbo].[Users](Id)
)
