CREATE PROCEDURE [dbo].[InsertCustomer]
	@name varchar(20),
	@firstName varchar(20),
	@email varchar(50),
	@address varchar(200),
	@businessName varchar(100),
	@phoneNumber varchar(20)
	
AS
	insert into Customers (Name, FirstName, Email, Address, BusinessName, PhoneNumber) values(@name,@firstName,@email,@address,@businessName,@phoneNumber)
RETURN 0
