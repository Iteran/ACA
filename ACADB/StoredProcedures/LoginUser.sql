CREATE PROCEDURE [dbo].[LoginUser]
	@email varchar(40),
	@password varchar(20)
AS
		declare @salt varchar(100)
		set @salt = (select Salt from Users where Email = @email)
		declare @secret varchar(100) = dbo.GetSecretKey()
		declare @hashpassword varbinary(64)
		set @hashpassword = HASHBYTES('SHA2_512',CONCAT(@salt,@password,@secret,@salt))
		declare @Id int
		set @Id  =(select Id from Users where  Password = @hashpassword  and  Email = @email)
		select * from V_Users where Id = @Id
			
