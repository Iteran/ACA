﻿CREATE PROCEDURE [dbo].[UpdateCustomer]
	@name varchar(20),
	@firstName varchar(20),
	@email varchar(50),
	@address varchar(200),
	@businessName varchar(100),
	@phoneNumber varchar(20),
	@Id int
	
AS
	Update Customers set Name = @name, FirstName = @firstName, Email = @email, Address = @address, BusinessName = @businessName, PhoneNumber = @phoneNumber where Id = @Id
RETURN 0
