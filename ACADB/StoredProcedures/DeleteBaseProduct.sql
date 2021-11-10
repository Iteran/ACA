CREATE PROCEDURE [dbo].[DeleteBaseProduct]
	@id int
AS
	update BaseProducts set IsActive = 0 where Id = @id
RETURN 0
