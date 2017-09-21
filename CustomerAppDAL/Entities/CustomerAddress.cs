using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Entities
{
    public class CustomerAddress
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public int AddressID { get; set; }
        public Address Address { get; set; }
    }
}
