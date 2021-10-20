CREATE TABLE [dbo].[Manufacturing]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	DateStart date,
	DeadLine date,
	Total Money,
	DownPayment money,
	CustomerId int not null,
	[Status] bit
 )
