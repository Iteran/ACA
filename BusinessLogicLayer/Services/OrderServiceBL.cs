using BusinessLogicLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using InterfacesACA.Interfaces;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class OrderServiceBL : IOrderService<OrderClient,OrderDetailsClient>
    {
        private readonly IOrderService<Order,OrderDetails> _orderService;
        public OrderServiceBL(IOrderService<Order,OrderDetails> service)
        {
            _orderService = service;
        }

        public IEnumerable<OrderClient> GetAll()
        {
            IEnumerable<OrderClient> orderClients = _orderService.GetAll().Select(c => c.Map<OrderClient>());
            orderClients = orderClients?.Select(o => { o.orderDetails = _orderService.GetDetails(o.Id).Select(od => od.Map<OrderDetailsClient>()); return o; });
            return orderClients;
        }
        public OrderClient GetById(int Id)
        {
            return _orderService.GetById(Id).Map<OrderClient>();
        }
        public void Create(OrderClient order)
        {
            _orderService.Create(order.Map<Order>());
        }
        public bool Delete(int Id)
        {
            return _orderService.Delete(Id);
        }
        public bool Paid(int Id)
        {
            return _orderService.Paid(Id);
        }

        public OrderClient Update(int Id, OrderClient Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetailsClient> GetDetails(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
