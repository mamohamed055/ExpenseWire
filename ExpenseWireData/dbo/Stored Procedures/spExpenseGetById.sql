CREATE PROCEDURE [dbo].[spExpenseGetById]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [UserId], [Type], [Description], [Amount]
	FROM dbo.Expense
	WHERE [UserId] = @Id;
END
