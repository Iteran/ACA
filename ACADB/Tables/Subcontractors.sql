CREATE TABLE [dbo].[Subcontractors]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(50) not null,
	[Email] varchar(30) not null,
	[Address] varchar(50)
)
