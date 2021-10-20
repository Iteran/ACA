CREATE function [dbo].[GetSecretKey]
()
	returns varchar
AS
	begin
		declare @secret varchar(100);
		set @secret = 'azhehzarhahrazh het azetazr tdaj"é"ezroiuéuezihoZIUH 9E9H0832OIZEHFIH ZOIDJPSOZOEHFZIHJHzopfejzpojzjgispoifizidfjzdfozkfezlrkzoerfzledsoflzdfdmtzrjtdfjzefoihzetujudnsjknrejrttoicommentckoazafafjzjzehityzééézdeejbazebbeaurayzryaeyeux'
		RETURN @secret
	end
