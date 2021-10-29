CREATE VIEW [dbo].[V_OrderDetail]
	AS SELECT  o.Id, ob.Quantity, b.Name, pb.PriceProduct from Orders o join OrderBaseProduct ob on o.Id = ob.OrderId join BaseProducts b on b.Id = ob.BaseProductId join PriceBaseProduct pb on b.Id = pb.BaseProductId where ((o.Date between pb.DateStart and pb.EndDate) or( o.Date > pb.DateStart and pb.EndDate is null))  
