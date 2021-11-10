CREATE TABLE [dbo].[BaseProducts]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(40),
	Picture varchar(max),
	[Description] varchar(500),
	Quantity int, 
    [IsActive] BIT NULL DEFAULT 1
)

GO

CREATE TRIGGER [dbo].[Trigger_BaseProducts]
    ON [dbo].[BaseProducts]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
        insert into PriceBaseProduct (BaseProductId,DateStart,PriceProduct) values((select Id from inserted),getdate(),0)
    END
GO
