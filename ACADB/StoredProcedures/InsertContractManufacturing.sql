CREATE PROCEDURE [dbo].[InsertContractManufacturing]
	@date date,
	@manufacturingId int,
	@subcontractorId int,
	@subcontractorCut money
AS
	insert into ContractManufacturing (Date,ManufacturingId,SubcontractorCut,SubcontractorId) values(@date,@manufacturingId,@subcontractorCut,@subcontractorId)
RETURN 0
