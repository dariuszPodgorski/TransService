using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TransServiceWebApp.DAO;
using TransServiceWebApp.Models;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class ServiceService
    {
        public List<TypeServiceViewModel> GetAllTypeService()
        {
            var model = new ServiceDao().GetAllTypeService();
            var result = new List<TypeServiceViewModel>();
            foreach (var item in model)
            {
                result.Add(new TypeServiceViewModel()
                {
                    Id = item.IdTypeService,
                    Name = item.Name
                });
            }
            return result;
        }

        internal void ValidateAddService(NewServiceFormForvarderViewModel model)
        {

        }

        internal void AddServiceForvarder(NewServiceFormForvarderViewModel model)
        {
            Service vehicle = new Service();

            vehicle.IdVehicle = model.VehicleId;
            vehicle.IdTypeService = model.TypeServiceId;
            vehicle.DateService = model.DateService;
            vehicle.Defects = model.Defects;
            vehicle.ReplacedParts = model.ReplacedParts;
            vehicle.DescriptionRepair = model.DescriptionRepair;
            vehicle.TotalMileage = model.TotalMileage;
            vehicle.Description = model.Description;


            new ServiceDao().Save(vehicle);
        }


        private List<ShowAllServiceViewModel> Map(List<Service> allServiceList)
        {
            var result = new List<ShowAllServiceViewModel>();
            foreach (var service in allServiceList)
            {
                var tmp = new ShowAllServiceViewModel();



                tmp.ServiceId = service.IdSerwis;
                tmp.Marke = service.Vehicle.Marke;
                tmp.CarModel = service.Vehicle.CarModel;

                tmp.DateService = service.DateService;
                tmp.RegistrationNumber = service.Vehicle.RegistrationNumber;
                tmp.TypeService = service.TypeService.Name;



                result.Add(tmp);
            }
            return result;
        }


        public List<ShowAllServiceViewModel> GetAllService()
        {
            //1
            List<Service> serviceList = new ServiceDao().GetAll();

            return Map(serviceList);
        }



        public ShowDetailsServiceViewModel GetDetailsService(int serviceId)
        {
            var model = new ServiceDao().GetServiceDetails(serviceId);

            var result = new ShowDetailsServiceViewModel()
            {

                ServiceId = model.IdSerwis,
                Marke = model.Vehicle.Marke,
                Model = model.Vehicle.CarModel,
                YearProduction = model.Vehicle.YearProduction,
                EngineCompacity = model.Vehicle.EngineCapacity,
                TypeBody = model.Vehicle.TypeBody,
                RegistrationNumber = model.Vehicle.RegistrationNumber,
                EngineNumber = model.Vehicle.EngineNumber,
                Color = model.Vehicle.Color,

                DateService = model.DateService,
                Defects = model.Defects,
                ReplacedParts = model.ReplacedParts,
                DescriptionRepair = model.DescriptionRepair,
                TotalMileage = model.TotalMileage,
                Description = model.Description


            };
            return result;
        }
    }
}