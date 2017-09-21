using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdressAppBLL;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;

namespace CustomerAppBLL.Services
{
    class AdressService : IAdressService
    {
        private AddressConverter converter = new AddressConverter();
        private DALFacade facade;
        public AdressService(DALFacade facade)
        {
            this.facade = facade;
        }
        public AdressBO Create(AdressBO adress)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newAdress = uow.AdressRepository.Create(converter.Convert(adress));
                uow.Complete();
                return converter.Convert(newAdress);
            }
        }

        public List<AdressBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.AdressRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public AdressBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return converter.Convert(uow.AdressRepository.Get(Id));
            }
        }

        public AdressBO Update(AdressBO adress)
        {
            using (var uow = facade.UnitOfWork)
            {
                var adressFromDB = uow.AdressRepository.Get(adress.Id);
                if (adressFromDB == null)
                {
                    throw new InvalidOperationException("Address not found");
                }
                adressFromDB.Id = adress.Id;
                adressFromDB.City = adress.City;
                adressFromDB.Number = adress.Number;
                adressFromDB.Street = adress.Street;
                uow.Complete();
                return converter.Convert(adressFromDB);
            }
        }

        public AdressBO Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newAdress = uow.AdressRepository.Delete(Id);
                uow.Complete();
                return converter.Convert(newAdress);
            }
        }
    }
}
