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
  
    
        [AuthorizeEnum(UserType.EmployeeOffice)]
        public class OfficeController : Controller
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
             * 
             * DODANIE NOWEGO KLIENTA
             * 
             */


            [HttpGet]

            public ActionResult AddNewClient()
            {
                return View();
            }

            [HttpPost]

            public ActionResult AddNewClient(NewClientFormViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var registrationService = new RegistrationService();
                    try
                    {
                        registrationService.ValidateRegistrationClientForvarder(model);
                        registrationService.SaveClientForvarder(model);
                        ViewBag.Message = "Zalozono konto";
                        return RedirectToAction("ShowAllClients", "Office");
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
             * WYŚWIETLANIE WSZYSTKICH KLIENTÓW
             * 
             */

            [HttpGet]

            public ActionResult ShowAllClients()
            {
                var showAllClients = new ClientService().GetAllClientsForvarder();

                return View(showAllClients);
            }


            /*
             * 
             * WYŚWIETLANIE WSZYSTKICH PRACOWNIKÓW
             * 
             */

            [HttpGet]
            public ActionResult ShowAllEmployee()
            {
                var showAllEmployee = new EmployeeService().GetAllEmployee();

                return View(showAllEmployee);
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


        /*
         * 
         * 
         * DODANIE NOWEGO PRACOWNIKA
         * 
         */

        [HttpGet]
        public ActionResult AddNewEmployee()
        {
            var employeeList = new SelectList(new EmployeeService().GetAllEmployeeList(), "Id", "Name");
  

            var model = new NewEmployeeFormOfficeViewModel()
            {

               EmployeeList = employeeList,
            };
            return View(model);
        }

        public ActionResult AddNewEmployee(NewEmployeeFormOfficeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationService = new EmployeeService();
                try
                {
                    registrationService.ValidateNewEmployee(model);
                    registrationService.SaveNewEmployee(model);
                    ViewBag.Message = "Zalozono konto";
                    return RedirectToAction("ShowAllEmployee", "Office");
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
           * WYŚWIETLANIE SZCZEGÓŁÓW PRACOWNIKÓW
           * 
           * 
           */

        [HttpGet]
        public ActionResult ShowEmployeeDetails(int employeeId)
        {
            // wyświetlanie szczegółów spedytorowi
            var model = new EmployeeService().GetDetailsEmployee(employeeId);
            return View(model);
        }

    }
}