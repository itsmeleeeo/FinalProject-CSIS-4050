CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) NOT NULL,
    [Username] VARCHAR(50) NOT NULL,
    [Password] VARCHAR(50) NOT NULL,
    [IsAdmin] Bit NOT NULL
)
