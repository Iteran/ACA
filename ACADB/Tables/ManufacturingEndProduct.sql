CREATE TABLE [dbo].[ManufacturingEndProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	ManufacturingId int,
	EndProductId int, 
    CONSTRAINT [FK_ManufacturingEndProduct_ToManufacturing] FOREIGN KEY ([ManufacturingId]) REFERENCES [Manufacturing]([Id]), 
    CONSTRAINT [FK_ManufacturingEndProduct_ToEndProduct] FOREIGN KEY ([EndProductID]) REFERENCES [EndProducts]([Id])
)
