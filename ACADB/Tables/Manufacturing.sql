CREATE TABLE [dbo].[Manufacturing]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	CommandId int,
	CustomerId int not null,
	WorkerId int not null,
	WorkerCut money,
	[Status] bit, 
    CONSTRAINT [FK_Manufacturing_ToCommand] FOREIGN KEY ([CommandId]) REFERENCES [Command]([Id]), 
    CONSTRAINT [FK_Manufacturing_ToWorker] FOREIGN KEY ([WorkerId]) REFERENCES [Workers]([Id])
)
