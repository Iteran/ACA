/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
insert into BaseProducts (Name,Picture,Description,Quantity) values('TissuBleu','Tissu mais bleu',10)
exec InsertUser 't@t','t'
update Users set IsAdmin = 1 where Id = 1
exec InsertCustomer 'Rog','Tom','t@t','LaRueOk','ACA','15151056521'

Declare @date date = '2021-10-30'
exec InsertOrder @date,1,0
insert into OrderBaseProduct (BaseProductId,OrderId,Quantity) values(1,1,4)
