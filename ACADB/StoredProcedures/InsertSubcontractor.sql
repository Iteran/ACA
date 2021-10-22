CREATE PROCEDURE [dbo].[InsertSubcontractor]
	@name varchar(100),
	@email varchar(50),
	@address varchar(200)
AS
	insert into Subcontractors (Name,Email,Address) values (@name,@email,@address)
RETURN 0
