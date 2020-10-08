using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Fascade;
using System.Web.Mvc;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Controllers
{
    public class ClientController : Controller
    {
        /*
        * 
        * 
        * INDEX KLIENT 
        * 
        */

        [HttpGet]
        public ActionResult Index()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetClientName(loginId);
            return View(model);
        }


        /*
         * 
         *  WYŚWIETLANIE WSZYSTKICH ZLECEŃ 
         *  
         */

        [HttpGet]
        public ActionResult ShowAllOrders()
        {
            var loginId = new SessionContext().GetLoginId();
            var orderListViewModel = new OrderService().GetAllOrdersClient(loginId);
            return View(orderListViewModel);
        }



        /*
         * 
         *  SZCZEGÓŁY ZAMÓWIENIA 
         *  
         */

        [HttpGet]
        public ActionResult ShowOrderDetails(int orderId)
        {

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

            var typeCargoList = new SelectList(new CargoService().GetAllTypeCargo(), "Id", "Name");

            var model = new NewOrderFormClientViewModel()
            {

                TypeCargoList = typeCargoList

            };
            return View(model);

        }

        [HttpPost]
        public ActionResult AddNewOrder(NewOrderFormClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderService = new OrderService();
                try
                {
                    orderService.ValidateAddOrder(model);
                    orderService.AddOrderClient(model);
                    return RedirectToAction("ShowAllOrders", "Client");
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
         * WYŚWIETLANIE DANYCH PROFILU
         * 
         */

        [HttpGet]
        public ActionResult ShowProfile()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetClientProfile(loginId);
            return View(model);
        }


        /*
         * 
         * EDYCJA DANYCH PROFILU
         * 
         */

        [HttpGet]
        public ActionResult EditProfile()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetClientProfileToEdit(loginId);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditProfile(EditProfileClientFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                var registrationService = new RegistrationService();
                try
                {
                    registrationService.Edit(model);

                    return RedirectToAction("ShowProfile", "Client");
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
    }
}