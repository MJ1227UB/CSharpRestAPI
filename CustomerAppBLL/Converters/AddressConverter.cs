using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    class AddressConverter
    {
        internal Address Convert(AdressBO adress)
        {
            if (adress == null){ return null; }
            return new Address()
            {
                Id = adress.Id,
                City = adress.City,
                Number = adress.Number,
                Street = adress.Street
            };
        }
        internal AdressBO Convert(Address adress)
        {
            if (adress == null) { return null; }
            return new AdressBO()
            {
                Id = adress.Id,
                City = adress.City,
                Number = adress.Number,
                Street = adress.Street
            };
        }
    }
}
