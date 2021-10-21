CREATE PROCEDURE [dbo].[InsertOrder]
	@date date,
	@customerId int,
	@total money,
	@isPaid bit
AS
	insert into Orders (Date,CustomerId,Total,IsPaid) values (@date,@customerId,@total,@isPaid)
RETURN 0
