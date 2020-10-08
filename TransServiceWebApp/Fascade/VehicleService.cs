using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.Models;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class VehicleService
    {
        public List<VehicleViewModel> GetAllVehicleList()
        {
            var model = new VehicleDao().GetAll();
            var result = new List<VehicleViewModel>();
            foreach (var item in model)
            {
                result.Add(new VehicleViewModel()
                {
                    Id = item.IdVehicle,
                    Name = item.RegistrationNumber + " / " + item.Marke + " " + item.CarModel
                });
            }
            return result;
        }

        internal void SaveForvarder(NewVehicleFormViewModel viewModel)
        {
            Vehicle vehicle = new Vehicle();
            VehicleCard vehicleCard = new VehicleCard();

            vehicle.Marke = viewModel.Marke;
            vehicle.CarModel = viewModel.CarModel;
            vehicle.YearProduction = viewModel.YearProduction;
            vehicle.EngineCapacity = viewModel.EngineCompacity;
            vehicle.EquipmentVersion = viewModel.EquipmentVersion;
            vehicle.TypeBody = viewModel.TypeBody;
            vehicle.RegistrationNumber = viewModel.RegistrationNumber;
            vehicle.EngineNumber = viewModel.EngineNumber;
            vehicle.Color = viewModel.Color;

            vehicleCard.DateOC = viewModel.DateOC;
            vehicleCard.NumberOC = viewModel.NumberOC;
            vehicleCard.DateTechnicalExamination = viewModel.DateTechnicalExamination;
            vehicleCard.TotalMieage = viewModel.TotalMieage;



            new VehicleDao().Save(vehicle);
        }




        private List<ShowAllVehicleViewModel> Map(List<Vehicle> allVehicleList)
        {
            var result = new List<ShowAllVehicleViewModel>();
            foreach (var vehicle in allVehicleList)
            {
                var tmp = new ShowAllVehicleViewModel();

                tmp.VehicleId = vehicle.IdVehicle;
                tmp.Marke = vehicle.Marke;
                tmp.Model = vehicle.CarModel;
                tmp.RegistrationNumber = vehicle.RegistrationNumber;
                tmp.EngineNumber = vehicle.EngineNumber;

                result.Add(tmp);
            }
            return result;
        }


        public List<ShowAllVehicleViewModel> GetAll()
        {
            //1
            List<Vehicle> vehicleList = new VehicleDao().GetAll();

            return Map(vehicleList);
        }



        public ShowVehicleDetailsViewModel GetDetailsVehicle(int vehicleId)
        {
            var model = new VehicleDao().GetVehicleDetails(vehicleId);

            var result = new ShowVehicleDetailsViewModel()
            {
            
                VehicleId = model.IdVehicle,
                Marke = model.Marke,
                Model = model.CarModel,
                YearProduction = model.YearProduction,
                EngineCompacity = model.EngineCapacity,
                EquipmentVersion = model.EquipmentVersion,
                TypeBody = model.TypeBody,
                RegistrationNumber = model.RegistrationNumber,
                EngineNumber = model.EngineNumber,
                Color = model.Color,



            };
            return result;
        }



    }
}