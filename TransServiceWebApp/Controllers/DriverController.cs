using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Fascade;
using System.Web.Mvc;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.Enum;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Controllers
{
    [AuthorizeEnum(UserType.EmployeeDriver)]
    public class DriverController : Controller
    {
        /*
         * 
         * INDEX
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
         * WYŚWIETLANIE WSZYSTKICH ZLECEŃ
         * 
         */

        [HttpGet]
        public ActionResult ShowAllOrder()
        {
            var loginId = new SessionContext().GetLoginId();
            var showOrderAll = new OrderService().GetDriverOrder(loginId);

            return View(showOrderAll);
        }



        /*
         * 
         * WYŚWIETLANIE WSZYSTKICH ZLEĆ DO ZDANIA
         * 
         */

        [HttpGet]
        public ActionResult ShowOrderPassAccept()
        {
            var loginId = new SessionContext().GetLoginId();
            var showOrderAll = new OrderService().GetDriverOrder(loginId);

            return View(showOrderAll);
        }

        /*
         * 
         * 
         * DODANIE ŁADUNKU
         * 
         * 
         */

        [HttpGet]
        public ActionResult AcceptCargo()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AcceptCargo(AcceptCargoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var forvarderService = new ForvarderService();
                try
                {
                    forvarderService.ValidateAcceptCargo(model);
                    forvarderService.AcceptCargo(model);

                    return RedirectToAction("ShowAllOrder", "Driver");
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
        * ZDANIE ŁADUNKU
        * 
        * 
        */

        [HttpGet]
        public ActionResult PassCargo()
        {

            return View();
        }


        [HttpPost]
        public ActionResult PassCargo(PassCargoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var forvarderService = new ForvarderService();
                try
                {
                    forvarderService.ValidatePassCargo(model);
                    forvarderService.PassCargo(model);

                    return RedirectToAction("ShowAllOrder", "Driver");
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