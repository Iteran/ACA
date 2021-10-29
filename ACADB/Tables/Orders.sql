CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Date] datetime2 not null,
	CustomerId int not null,
	IsPaid bit, 
    CONSTRAINT [FK_Command_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id])
)
