using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.BusinessObjects
{
    public class AdressBO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
    }
}
