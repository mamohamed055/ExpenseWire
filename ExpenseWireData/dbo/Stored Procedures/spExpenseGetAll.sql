CREATE PROCEDURE [dbo].[spExpenseGetAll]
AS
	BEGIN 
		SET NOCOUNT ON;

		SELECT [Id], [UserId], [CreatedDate],[Type], [Description], [Amount]
		FROM dbo.Expense
	END