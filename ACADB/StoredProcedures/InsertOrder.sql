CREATE PROCEDURE [dbo].[InsertOrder]
	@date date,
	@customerId int,
	@isPaid bit
AS
	insert into Orders (Date,CustomerId,IsPaid) values (@date,@customerId,@isPaid)
RETURN 0
