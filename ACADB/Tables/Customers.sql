CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(50) not null,
	[FirstName]varchar(20),
	[Email]varchar(30) not null,
	[Address]varchar(30),
	BusinessName varchar(100),
	PhoneNumber varchar(20),
	UserId int, 
    CONSTRAINT [FK_Customers_ToUser] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
