CREATE TABLE [dbo].[CommandBaseProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	BaseProductId int not null,
	CommandId int not null,
	Quantity int, 
    CONSTRAINT [FK_CommandProduct_ToCommand] FOREIGN KEY ([CommandId]) REFERENCES [Command]([Id]), 
    CONSTRAINT [FK_CommandProduct_ToProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [BaseProducts]([Id])
)
