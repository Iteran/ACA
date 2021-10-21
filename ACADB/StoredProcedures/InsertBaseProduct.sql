CREATE PROCEDURE [dbo].[InsertBaseProduct]
	@picture varchar(200),
	@description varchar(200),
	@quantity int
AS
	insert into BaseProducts (Picture,Description,Quantity) values(@picture,@description,@quantity)
RETURN 0
