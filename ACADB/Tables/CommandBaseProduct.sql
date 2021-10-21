CREATE TABLE [dbo].[CommandBaseProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	BaseProductId int not null,
	OrderId int not null,
	Quantity int, 
    CONSTRAINT [FK_CommandProduct_ToCommand] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [FK_CommandProduct_ToProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [BaseProducts]([Id])
)
