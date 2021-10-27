CREATE PROCEDURE [dbo].[UpdatePassword]
	@newPwd varchar(40),
	@Id int
AS
		declare @salt varchar(100)
		set @salt = (select Salt from Users where Id = @Id)
		declare @secret varchar(100) = dbo.GetSecretKey()
		declare @hashpassword varbinary(64)
		set @hashpassword = HASHBYTES('SHA2_512',CONCAT(@salt,@newPwd,@secret,@salt))
		update Users set Password = @hashpassword where Id = @Id
RETURN 0
