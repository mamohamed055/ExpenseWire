CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(512) NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL
)
