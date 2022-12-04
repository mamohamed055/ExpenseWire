CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Type] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(512) NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [FK_Expense_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    -- [CreatedBy] NVARCHAR(128) NOT NULL 
    -- [Status] NVARCHAR(50) NOT NULL
 
)
