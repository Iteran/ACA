CREATE PROCEDURE [dbo].[BindCustomer]
	@customerId int,
	@userId int
AS
	Update Customers set UserId = @userId where Id = @customerId and UserId is null
RETURN 0
