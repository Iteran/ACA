CREATE PROCEDURE [dbo].[InsertOrderBaseProduct]
	@baseProductId int ,
	@orderId int,
	@quantity int
AS
	insert into OrderBaseProduct(BaseProductId,OrderId,Quantity) values (@baseProductId,@orderId,@quantity)
RETURN 0
