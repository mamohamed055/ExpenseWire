CREATE PROCEDURE [dbo].[spAddExpense]
	@Type nvarchar(50),
	@Description nvarchar(512),
	@Amount money

	AS
	BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.Expense(Type, Description, Amount)
	VALUES (@Type, @Description, @Amount);

	END

