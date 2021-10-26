CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
	@email varchar(30)
As
	Update Users set Email = @email where Id = @id
RETURN 0
