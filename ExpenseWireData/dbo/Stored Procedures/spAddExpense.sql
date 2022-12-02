CREATE PROCEDURE [dbo].[spAddExpense]
	@UserId nvarchar(128),
	@Type nvarchar(50),
	@Description nvarchar(512),
	@Amount money,
	@CreatedDate datetime2

	AS
	BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.Expense(Type, Description, Amount, UserId, CreatedDate)
	VALUES (@Type, @Description, @Amount, @UserId, @CreatedDate);

	END

