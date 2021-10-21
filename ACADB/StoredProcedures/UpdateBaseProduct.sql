CREATE PROCEDURE [dbo].[UpdateBaseProduct]
	@picture varchar(200) = 0,
	@description varchar(300),
	@quantity int
AS
	update BaseProducts set Picture = @picture, Description = @description, Quantity = @quantity
RETURN 0
