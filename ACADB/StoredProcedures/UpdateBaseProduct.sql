CREATE PROCEDURE [dbo].[UpdateBaseProduct]
	@name varchar(40),
	@picture varchar(200) = 0,
	@description varchar(300),
	@quantity int,
	@id int
AS
	update BaseProducts set Picture = @picture, Description = @description, Quantity = @quantity, Name = @name where Id = @id
RETURN 0
