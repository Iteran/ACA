CREATE TABLE [dbo].[CommandProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	ProductId int not null,
	CommandId int not null,
	Quantity int, 
    CONSTRAINT [FK_CommandProduct_ToCommand] FOREIGN KEY ([CommandId]) REFERENCES [Command]([Id]), 
    CONSTRAINT [FK_CommandProduct_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
)
