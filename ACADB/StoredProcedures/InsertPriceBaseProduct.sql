CREATE PROCEDURE [dbo].[InsertPriceBaseProduct]
	@Id int,
	@priceProduct money,
	@dateStart datetime2

AS
	insert into PriceBaseProduct (PriceProduct,BaseProductId,DateStart) values(@priceProduct,@Id,@dateStart)
RETURN 0
