CREATE PROCEDURE [dbo].[InsertUser]
	@email varchar(20),
	@password varchar(30)
	
	
AS
	BEGIN
		
		declare @salt varchar(100)
		set @salt = concat(newid(),newid(),newid())
		declare @secret varchar(100) = dbo.GetSecretKey()
		declare @hashpassword varbinary(64)
		set @hashpassword = HASHBYTES('SHA2_512',CONCAT(@salt,@password,@secret,@salt))
		insert into [Users] (Email,Password,Salt) values (@email,@hashpassword,@salt)
	END
RETURN 0