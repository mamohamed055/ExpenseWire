CREATE PROCEDURE [dbo].[spAddExpense]
	@Id int, /*Dont remove this line, otherwise you'll get that the procedure has too many arguments. I'm not using the Id anyways but I need it to edit the expense And it's in the expense model*/
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

