CREATE PROCEDURE [dbo].[UpdateContractManufacturing]
	@Id int,
	@date date,
	@manufacturingId int,
	@subcontractorId int,
	@subcontractorCut money
AS
	update ContractManufacturing set Date = @date, ManufacturingId = @manufacturingId, SubcontractorId = @subcontractorId, SubcontractorCut = @subcontractorCut where Id = @Id
RETURN 0
