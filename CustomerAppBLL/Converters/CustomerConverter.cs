using System.Linq;
using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        private AddressConverter aConv;

        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }
        internal Customer Convert(CustomerBO cust)
        {
            if (cust == null) { return null; }
            return new Customer()
            {
                Id = cust.Id,
                Addresses = cust.AddressesIds?.Select(aId => new CustomerAddress()
                {
                    AddressID = aId,
                    CustomerID = cust.Id
                }).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }

        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }
            return new CustomerBO()
            {
                Id = cust.Id,
                AddressesIds = cust.Addresses?.Select(a => a.AddressID).ToList(),
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
