CREATE PROCEDURE [dbo].[spEditExpense]
	@Id int,
	@CreatedDate datetime2,
	@Type nvarchar(50),
	@Description nvarchar(512),
	@Amount money,
	@UserId nvarchar(128)

	AS
	BEGIN

	SET NOCOUNT ON;

	UPDATE Expense

	SET CreatedDate = @CreatedDate, [Type] = @Type, [Description] = @Description, Amount = @Amount, UserId = @UserId
	WHERE Id = @Id

	END