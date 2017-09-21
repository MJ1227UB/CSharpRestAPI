using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL.Entities;

namespace AdressAppDAL
{
    public interface IAddressRepository
    {
        //C
        Address Create(Address adress);
        //R
        List<Address> GetAll();
        IEnumerable<Address> GetAllById(List<int> ids);
        Address Get(int Id);
        //U
        //No Update for Repository, It will be the task of Unit of Work
        //D
        Address Delete(int Id);
    }
}
