CREATE TABLE [dbo].[Command]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Date] date not null,
	CustomerId int not null,
	Total money,
	IsPaid bit, 
    CONSTRAINT [FK_Command_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
