using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Fascade;
using System.Web.Mvc;
using TransServiceWebApp.Enum;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Controllers
{

    [AuthorizeEnum(UserType.EmployeeForwarder)]
    public class ForvarderController : Controller
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
         * DODAWANIE NOWEGO SERWISU
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
         * WYŚWIETLANIE WSZYSTKICH SERWISÓW
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

        [HttpGet]
        public ActionResult ShowDetailsNewOrder(int orderId)
        {
            // wyświetlanie szczegółów spedytorowi
            var model = new OrderService().GetDetailsNewOrder(orderId);
            return View(model);
        }




        /*
         * 
         * DODANIE NOWEGO ZLECENIA
         * 
         */

        [HttpGet]

        public ActionResult AddNewOrder()
        {
            var clientList = new SelectList(new ClientService().GetClient(), "Id", "Name");
            var typeCargoList = new SelectList(new CargoService().GetAllTypeCargo(), "Id", "Name");

            var model = new NewOrderFormForvarderViewModel()
            {

                TypeCargoList = typeCargoList,
                ClientList = clientList
            };
            return View(model);

        }

        [HttpPost]
        public ActionResult AddNewOrder(NewOrderFormForvarderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderService = new OrderService();
                try
                {
                    orderService.ValidateAddOrderForvarder(model);
                    orderService.AddOrderForvarder(model);

                    return RedirectToAction("ShowAllOrders", "Forvarder");
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
         * WYŚWIETLANIE WSZYSTKICH ZLECEŃ
         * 
         */

        [HttpGet]
        public ActionResult ShowAllOrders()
        {

            var showAllOrder = new OrderService().GetAllOrders();
            return View(showAllOrder);
        }

        /*
         * 
         * WYŚWIETLANIE WSZYSTKICH NOWYCH ZLECEŃ
         * 
         */

        [HttpGet]
        public ActionResult ShowAllNewOrders()
        {

            var showAllOrder = new OrderService().GetAllNewOrders();
            return View(showAllOrder);
        }


        /*
         * 
         * WYŚWIETLANIE WSZYSTKICH ZLECEŃ W TRAKCIE REALIZACJI 
         * 
         */

        [HttpGet]
        public ActionResult ShowAllOrdersInProgress()
        {

            var showAllOrder = new OrderService().GetAllOrdersInProgress();
            return View(showAllOrder);
        }


        [HttpGet]
        public ActionResult ShowAllOrdersClose()
        {

            var showAllOrder = new OrderService().GetAllOrdersClose();
            return View(showAllOrder);
        }


        /*
         * 
         * ZATWIERDZANIE ZAMÓWIENIA
         * 
         */

        [HttpGet]
        [AuthorizeEnum(UserType.EmployeeForwarder)]
        public ActionResult AcceptOrder(int orderId)
        {


            var vehicleList = new SelectList(new VehicleService().GetAllVehicleList(), "Id", "Name");
            var driverList = new SelectList(new DriverService().GetAll(), "Id", "Name");
            var model = new AcceptOrderViewModel()
            {
                DriverList = driverList,
                VehicleList = vehicleList,
                OrderId = orderId
            };
            return View(model);
        }

        [HttpPost]
        [AuthorizeEnum(UserType.EmployeeForwarder)]
        public ActionResult AcceptOrder(AcceptOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var forvarderService = new ForvarderService();
                try
                {
                    forvarderService.ValidateAcceptOrder(model);
                    forvarderService.AcceptOrder(model);

                    return RedirectToAction("ShowAllOrders", "Forvarder");
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
         * 
         * WYŚWIETLANIE SZCZEGÓŁÓW ZLECENIA
         * 
         * 
         */



        /*
        * 
        * WYŚWIETLANIE DANYCH PROFILU
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


        
    }
}
