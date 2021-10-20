CREATE TABLE [dbo].[Workers]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(50) not null,
	FirstName varchar(20),
	[Email] varchar(30) not null,
	[Address] varchar(50)
)
