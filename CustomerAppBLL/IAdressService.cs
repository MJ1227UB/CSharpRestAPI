using System.Collections.Generic;
using CustomerAppBLL.BusinessObjects;

namespace AdressAppBLL
{
    public interface IAdressService
    {
        //C
        AdressBO Create(AdressBO cust);
        //R
        List<AdressBO> GetAll();
        AdressBO Get(int Id);
        //U
        AdressBO Update(AdressBO cust);
        //D
        AdressBO Delete(int Id);
    }
}