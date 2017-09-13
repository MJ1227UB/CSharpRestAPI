using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;

namespace CustomerAppBLL.Services
{
    class OrderService : IOrderService
    {
        private OrderConverter converter = new OrderConverter();
        private DALFacade _facade;
        public OrderService(DALFacade facade)
        {
            _facade = facade;
        }
        public OrderBO Create(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Create(converter.Convert(order));
                uow.Complete();
                return converter.Convert(orderEntity);
            }
        }

        public List<OrderBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.OrderRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public OrderBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(Id);
                orderEntity.Customer = uow.CustomerRepository.Get(orderEntity.CustomerId);
                return converter.Convert(orderEntity);
            }
        }

        public OrderBO Update(OrderBO order)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Get(order.Id);
                if (order == null)
                {
                    throw new InvalidOperationException("Order not found");
                }
                orderEntity.DeliveryDate = order.DeliveryDate;
                orderEntity.OrderDate = order.OrderDate;
                orderEntity.CustomerId = order.CustomerId;
                uow.Complete();
                orderEntity.Customer = uow.CustomerRepository.Get(orderEntity.CustomerId);
                return converter.Convert(orderEntity);
            }
        }

        public OrderBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var orderEntity = uow.OrderRepository.Delete(Id);
                uow.Complete();
                return converter.Convert(orderEntity);
            }
        }
    }
}
