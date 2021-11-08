CREATE PROCEDURE [dbo].[DeleteCustomer]
	@id int
AS
	update Users set CustomerId = null where CustomerId = @id
	delete from Customers where Id = @id
RETURN 0
