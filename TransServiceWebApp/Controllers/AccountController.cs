using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TransServiceWebApp.Enum;
using TransServiceWebApp.Fascade;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Controllers
{
    public class AccountController : Controller
    {
        /* 
        * 
        * Logowanie 
        * 
        */

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //TODO sprawdzenie czy ktoś nie jest już zalogowany
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //TODO łapanie bledu itd 
                var loginService = new LoginService();
                var idLogin = new LoginService().CheckedLogin(loginViewModel);

                var userType = loginService.GetUserType(idLogin);
                new SessionContext().SetAuthToken(idLogin.ToString(), false, idLogin.ToString());

                if (!string.IsNullOrWhiteSpace(returnUrl)) return Redirect(returnUrl);

                if (userType == Enum.UserType.Client)
                {
                    return RedirectToAction("Index", "Client");
                }
                else if (userType == Enum.UserType.EmployeeForwarder)
                {
                    return RedirectToAction("Index", "Forvarder");
                }
                else if (userType == Enum.UserType.EmployeeServiceMan)
                {
                    return RedirectToAction("Index", "Serviceman");
                }
                else if (userType == Enum.UserType.EmployeeDriver)
                {
                    return RedirectToAction("Index", "Driver");
                }
                else if (userType == Enum.UserType.EmployeeOffice)
                {
                    return RedirectToAction("Index", "Office");
                }
                else
                {
                    return RedirectToAction("About", "Home");
                }


            }
            else
            {

                return View(loginViewModel);
            }

        }

        /*
         * 
         * REJESTRACJA NOWEGO UŻYTKOWNIKA 
         * 
         */


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrationService = new RegistrationService();
                try
                {
                    registrationService.Validate(model);
                    registrationService.Save(model);
                    ViewBag.Message = "Zalozono konto";
                    return RedirectToAction("Login", "Account");
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
         * ZMIANA HASŁA
         * 
         */

        [HttpGet]
        [AuthorizeEnum(UserType.EmployeeDriver, UserType.EmployeeForwarder, UserType.EmployeeServiceMan, UserType.Client)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeEnum(UserType.EmployeeDriver, UserType.EmployeeForwarder, UserType.EmployeeServiceMan, UserType.Client)]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginService = new LoginService();

                loginService.ValidateChangePassword(model);
                var loginId = new SessionContext().GetLoginId();
                model.Login = loginService.GetLogin(loginId);

                loginService.ChangePassword(model);

                var idLogin = new LoginService().CheckedLogin(model);

                var userType = loginService.GetUserType(idLogin);
                if (userType == Enum.UserType.Client)
                {
                    return RedirectToAction("Index", "Client");
                }
                else if (userType == Enum.UserType.EmployeeForwarder)
                {
                    return RedirectToAction("Index", "Forvarder");
                }
                else if (userType == Enum.UserType.EmployeeServiceMan)
                {
                    return RedirectToAction("Index", "Serviceman");
                }
                else if (userType == Enum.UserType.EmployeeDriver)
                {
                    return RedirectToAction("Index", "Driver");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
        }


        /*
         * 
         * WYLOGOWANIE
         * 
         */

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }




        [HttpGet]
        [AuthorizeEnum(UserType.EmployeeDriver, UserType.EmployeeForwarder, UserType.EmployeeServiceMan)]
        public ActionResult EditProfile()
        {
            var loginId = new SessionContext().GetLoginId();
            var model = new ProfileService().GetEmployeeProfileToEdit(loginId);
            return View(model);
        }


        [HttpPost]
        [AuthorizeEnum(UserType.EmployeeDriver, UserType.EmployeeForwarder, UserType.EmployeeServiceMan)]
        public ActionResult EditProfile(EditProfileEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var profileService = new ProfileService();
                try
                {
                    profileService.Edit(model);


                    return RedirectToAction("Index", "Home");
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