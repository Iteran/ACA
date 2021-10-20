CREATE TABLE [dbo].[ComponentEndProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	BaseProductId int,
	EndProductId int,
	QuantityBaseProduct int, 
    CONSTRAINT [FK_ComponentEndProduct_ToBaseProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [BaseProducts]([Id]), 
    CONSTRAINT [FK_ComponentEndProduct_ToEndProduct] FOREIGN KEY ([EndProductId]) REFERENCES [EndProducts]([Id])
)
