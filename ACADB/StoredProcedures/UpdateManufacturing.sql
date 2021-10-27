CREATE PROCEDURE [dbo].[UpdateManufacturing]
	@Id int,
	@dateStart date,
	@deadLine date,
	@total money,
	@downPayment money,
	@customerId int,
	@status varchar(30)
AS
	update Manufacturing set DateStart = @dateStart, DeadLine = @deadLine, Total = @total, DownPayment = @downPayment
	,CustomerId = @customerId, status = @status where Id = @Id
RETURN 0
