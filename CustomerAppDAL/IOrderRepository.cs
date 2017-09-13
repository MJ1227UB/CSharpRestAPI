using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL
{
    public interface IOrderRepository
    {
        //C
        Order Create(Order order);
        //R
        List<Order> GetAll();
        Order Get(int Id);
        //U
        //No Update for Repository, It will be the task of Unit of Work
        //D
        Order Delete(int Id);
    }
}
