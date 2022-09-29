CREATE PROCEDURE [dbo].[spExpenseGetAll]
AS
	BEGIN 
		SET NOCOUNT ON;

		SELECT [Type], [Description], [Amount]
		FROM dbo.Expense
	END