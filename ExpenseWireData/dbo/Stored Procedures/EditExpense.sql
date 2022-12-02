CREATE PROCEDURE [dbo].[EditExpense]
	@UserId nvarchar(128),
	@Type nvarchar(50),
	@Description nvarchar(512),
	@Amount money,
	@CreatedDate datetime2

	AS
	BEGIN

	SET NOCOUNT ON;

	UPDATE Expense

	SET UserId = @UserId, [Type] = @Type, [Description] = @Description, Amount = @Amount, CreatedDate = @CreatedDate
	WHERE CreatedDate = @CreatedDate
