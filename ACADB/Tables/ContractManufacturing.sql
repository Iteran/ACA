CREATE TABLE [dbo].[ContractManufacturing]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Date] date,
	ManufacturingId int,
	SubcontractorId int,
	SubcontractorCut money, 
    CONSTRAINT [FK_ContractManufacturing_ToManufacturing] FOREIGN KEY ([ManufacturingId]) REFERENCES [Manufacturing]([Id]), 
    CONSTRAINT [FK_ContractManufacturing_ToSubcontractor] FOREIGN KEY ([SubcontractorId]) REFERENCES [Subcontractors]([Id])
)
