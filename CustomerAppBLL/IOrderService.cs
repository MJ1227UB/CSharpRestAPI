﻿using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;

namespace CustomerAppBLL
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO cust);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int Id);
        //U
        OrderBO Update(OrderBO cust);
        //D
        OrderBO Delete(int Id);
    }
}
