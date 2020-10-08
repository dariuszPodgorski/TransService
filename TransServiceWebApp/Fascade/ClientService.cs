using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.Models;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class ClientService
    {
        public List<ClientViewModel> GetClient()
        {
            var model = new ClientDao().GetAllClient();
            var result = new List<ClientViewModel>();
            foreach (var item in model)
            {
                result.Add(new ClientViewModel()
                {
                    Id = item.IdCleint,
                    Name = item.CompanyName,
                });
            }
            return result;
        }


        internal List<ShowAllClientsViewModel> GetAllClientsForvarder()
        {
            //1
            List<Client> clientList = new ClientDao().GetAllClient();
            List<ShowAllClientsViewModel> result = new List<ShowAllClientsViewModel>();

            //2
            foreach (var clientAll in clientList)
            {
                var model = new ShowAllClientsViewModel();

                model.CompanyName = clientAll.CompanyName;
                model.NIP = clientAll.NIP;
                model.PostCode = clientAll.PostCode;
                model.City = clientAll.City;
                model.Street = clientAll.Street;
                model.NumberOfBuilding = clientAll.NumberOfBuilding;
                model.NumberApartment = clientAll.NumberApartment;



                result.Add(model);
            }

            //3
            return result;
        }
    }
}