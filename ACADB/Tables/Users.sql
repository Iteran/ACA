CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[IsAdmin] bit default 0,
	[Password] varbinary(64) not null,
	[Email] varchar(40),
	Salt varchar(100)
)
