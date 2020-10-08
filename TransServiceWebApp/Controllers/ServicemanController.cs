using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransServiceWebApp.Enum;
using TransServiceWebApp.Fascade;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Controllers
{
    [AuthorizeEnum(UserType.EmployeeServiceMan)]
    public class ServicemanController : Controller
    {
        /*
        * 
        *INDEX 
        * 
        */
        [HttpGet]
        public ActionResult Index()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetEmployeeName(loginId);
            return View(model);
        }



        /*
        * 
        * WYŚWIETLANIE WSZYSTKICH POJAZDÓW
        * 
        */

        [HttpGet]
        public ActionResult ShowAllVehicle()
        {
            var showAllVehicle = new VehicleService().GetAll();

            return View(showAllVehicle);
        }

        /*
         * 
         * DODANIE NOWEGO SERIWUS 
         * 
         */

        [HttpGet]
        public ActionResult AddNewService()
        {
            var vehicleList = new SelectList(new VehicleService().GetAllVehicleList(), "Id", "Name");
            var TypeServiceList = new SelectList(new ServiceService().GetAllTypeService(), "Id", "Name");

            var model = new NewServiceFormForvarderViewModel()
            {

                VehicleList = vehicleList,
                TypeServiceList = TypeServiceList
            };
            return View(model);
        }

        [HttpPost]

        public ActionResult AddNewService(NewServiceFormForvarderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var serviceService = new ServiceService();
                try
                {
                    serviceService.ValidateAddService(model);
                    serviceService.AddServiceForvarder(model);

                    return RedirectToAction("ShowAllService", "Forvarder");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        /*
         * 
         * WYŚWIETLANIE NOWEGO SERWISU
         * 
         * 
         */

        [HttpGet]

        public ActionResult ShowAllService()
        {
            var showAllService = new ServiceService().GetAllService();

            return View(showAllService);
        }


        /*
         * 
         * 
         * WYŚWIETLANIE DANYCH PROFILU
         * 
         * 
         */

        [HttpGet]
        public ActionResult ShowProfile()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetEmployeeProfile(loginId);
            return View(model);
        }


        /*
        * 
        * DODAWANIE NOWEGO POJAZDU
        * 
        */

        [HttpGet]
        public ActionResult AddNewVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewVehicle(NewVehicleFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleService = new VehicleService();

                    vehicleService.SaveForvarder(model);
                    return RedirectToAction("ShowAllVehicle", "Forvarder");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }


        /*
        * 
        * WYŚWIETLANIE SZCZEGÓŁÓW POJAZDU
        * 
        * 
        */

        [HttpGet]
        public ActionResult ShowVehicleDetails(int vehicleId)
        {
            // wyświetlanie szczegółów spedytorowi
            var model = new VehicleService().GetDetailsVehicle(vehicleId);
            return View(model);
        }



        /*
        * 
        * WYŚWIETLANIE SZCZEGÓŁÓW SERWISU
        * 
        */

        [HttpGet]
        public ActionResult ShowDetailsService(int serviceId)
        {
            // wyświetlanie szczegółów spedytorowi
            var model = new ServiceService().GetDetailsService(serviceId);
            return View(model);
        }

    }
}