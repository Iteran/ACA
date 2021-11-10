CREATE PROCEDURE [dbo].[InsertBaseProduct]
	@name varchar(40),
	@picture varchar(max),
	@description varchar(200),
	@quantity int
AS
	insert into BaseProducts (Name,Picture,Description,Quantity) values(@name,@picture,@description,@quantity)
RETURN 0
