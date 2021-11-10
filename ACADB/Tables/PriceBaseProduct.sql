CREATE TABLE [dbo].[PriceBaseProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	PriceProduct money,
	BaseProductId int,
	DateStart datetime2,
	EndDate datetime2, 
    CONSTRAINT [FK_PriceBaseProduct_ToBaseProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [BaseProducts]([Id]), 
    CONSTRAINT [CK_PriceBaseProduct_EndDate] CHECK (EndDate > DateStart)
)

GO

CREATE TRIGGER [dbo].[Trigger_PriceBaseProduct]
    ON [dbo].[PriceBaseProduct]
    instead of INSERT
    AS
    BEGIN
        SET NoCount ON
        declare @productId int
        declare @dateStart datetime2, @price money
        select @productId = BaseProductId, @dateStart = DateStart, @price = PriceProduct from inserted
        
        update PriceBaseProduct set EndDate = @dateStart where BaseProductId = @productId and EndDate is null
        insert into PriceBaseProduct (PriceProduct,BaseProductId,DateStart) values(@price,@productId,@dateStart)
    END