using System;
using AdressAppDAL;

namespace CustomerAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IAddressRepository AdressRepository { get; }
        int Complete();
    }
}
