CREATE PROCEDURE [dbo].[spDeleteExpense]
	@Id int

	AS
	BEGIN

	SET NOCOUNT ON;

	DELETE FROM [dbo].[Expense]

	WHERE Id = @Id

	END
