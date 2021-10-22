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
    public class OrderServiceBL : IOrderService<OrderClient>
    {
        private readonly IOrderService<Order> _orderService;
        public OrderServiceBL(IOrderService<Order> service)
        {
            _orderService = service;
        }

        public IEnumerable<OrderClient> GetAll()
        {
            return _orderService.GetAll().Select(c => c.Map<OrderClient>());
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
    }
}
