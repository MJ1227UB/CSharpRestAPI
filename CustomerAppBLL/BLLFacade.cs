using CustomerAppBLL.Services;
using CustomerAppDAL;
using System;
using System.Collections.Generic;
using System.Text;
using AdressAppBLL;

namespace CustomerAppBLL
{
    public class BLLFacade
    {
        public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade()); }
        }

        public IOrderService OrderService
        {
            get { return new OrderService(new DALFacade());}
        }

        public IAdressService AdressService
        {
            get { return new AdressService(new DALFacade());}
        }
    }
}
