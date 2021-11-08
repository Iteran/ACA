	CREATE PROCEDURE [dbo].[BindCustomer]
	@customerId int,
	@userId int
AS
if exists (select CustomerId from users where CustomerId = @customerId)
	begin
		--raiseError
		return -1;
	end
	
	Update Users set CustomerId = @customerId where (Id = @userId) and (CustomerId is null) 
RETURN 0
