CREATE PROCEDURE [dbo].[spExpenseGetById]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [UserId],[CreatedDate], [Type], [Description], [Amount]
	FROM dbo.Expense
	WHERE [UserId] = @Id;
END
