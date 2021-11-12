CREATE TABLE [dbo].[PriceBaseProduct]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	PriceProduct money,
	BaseProductId int,
	DateStart datetime2,
	EndDate datetime2, 
    CONSTRAINT [FK_PriceBaseProduct_ToBaseProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [BaseProducts]([Id]), 
   

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
       
        update PriceBaseProduct set EndDate = @dateStart where BaseProductId = @productId and ((EndDate is null and DateStart<@dateStart) or (EndDate>@dateStart and EndDate is not null))
        declare @datestart2 datetime2
        select @datestart2 = DateStart from PriceBaseProduct where @productId = BaseProductId and EndDate is null
        if(@dateStart < @datestart2 )
            begin
                declare @endDate datetime2
                set @endDate = @datestart2
                insert into PriceBaseProduct(PriceProduct,BaseProductId,DateStart,EndDate) values (@price,@productId,@dateStart,@endDate)

            end
        else
            begin
               insert into PriceBaseProduct (PriceProduct,BaseProductId,DateStart) values(@price,@productId,@dateStart)
            end
    END