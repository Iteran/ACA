CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[IsAdmin] bit default 0,
	[Password] varbinary(64) not null,
	[Email] varchar(40),
	Salt varchar(100), 
    [CustomerId] INT NULL, 
    CONSTRAINT [FK_Users_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
