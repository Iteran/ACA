CREATE PROCEDURE [dbo].[InsertManufacturing]
	@dateStart date,
	@deadLine date,
	@total money,
	@downPayment money,
	@customerId int,
	@status varchar(30)
AS
	insert into Manufacturing (DateStart,DeadLine,Total,DownPayment,CustomerId,Status) values(@dateStart,@deadLine,@total,@downPayment,@customerId,@status)
RETURN 0
