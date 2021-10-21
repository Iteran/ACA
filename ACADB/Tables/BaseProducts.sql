CREATE TABLE [dbo].[BaseProducts]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(40),
	Picture varchar(100),
	[Description] varchar(500),
	Quantity int
)
