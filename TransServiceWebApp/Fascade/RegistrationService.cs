using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.Helpers;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.Models;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class RegistrationService
    {
        /*
         * 
         * NOWY KLIENT
         * 
         */

        public void Save(RegistrationFormViewModel viewModel)
        {
            //VM -> Model
            Client principal = new Client();
            Login loginObject = new Login();

            principal.CompanyName = viewModel.CompanyName;
            principal.Country = viewModel.Country;
            principal.PostCode = viewModel.PostCode;
            principal.City = viewModel.City;
            principal.Street = viewModel.Street;
            principal.NumberOfBuilding = viewModel.NumerOfBuilding;
            principal.NumberApartment = viewModel.NumberApartment;
            principal.NIP = viewModel.NIP;
            principal.Email = viewModel.Email;
            principal.Phone = viewModel.Phone;
            principal.Fax = viewModel.Fax;
            principal.FirstNameContact = viewModel.FirstNameContact;
            principal.LastNameContact = viewModel.LastNameContact;
            principal.PhoneContact = viewModel.PhoneContact;
            principal.EmailContact = viewModel.EmailContact;

            loginObject.Login1 = viewModel.Login;

            loginObject.Password = SHAHelper.GenerateSHA512(viewModel.Password);
            principal.Login = loginObject;

            //Wywolanie metody z dao ktora zapisze dane 
            new RegistrationDao().Save(principal);
        }



        internal void Validate(RegistrationFormViewModel model)
        {

            var password = model.Password;
            var replayPassword = model.RepeatPassword;

            if (string.Compare(password, replayPassword) != 0)
            {
                throw new Exception("Walidacja sie nie udala");
            }

            //TODO nip walidacja

        }



        /*
         * 
         * EDYCJA DANYCH 
         * 
         */

        internal void Edit(EditProfileClientFormViewModel viewModel)
        {
            Client principal = new Client();
            principal.CompanyName = viewModel.CompanyName;
            principal.Country = viewModel.Country;
            principal.PostCode = viewModel.PostCode;
            principal.City = viewModel.City;
            principal.Street = viewModel.Street;
            principal.NumberOfBuilding = viewModel.NumerOfBuilding;
            principal.NumberApartment = viewModel.NumberApartment;
            principal.Fax = viewModel.Fax;
            principal.Phone = viewModel.Phone;
            principal.Email = viewModel.Email;
            principal.NIP = viewModel.NIP;
            principal.FirstNameContact = viewModel.FirstNameContact;
            principal.LastNameContact = viewModel.LastNameContact;
            principal.PhoneContact = viewModel.PhoneContact;
            principal.EmailContact = viewModel.EmailContact;
            principal.IdLogin = new SessionContext().GetLoginId();
            principal.IdCleint = new LoginDao().GetIdClient((int)principal.IdLogin);
            new ClientDao().Edit(principal);
        }


        internal void ValidateRegistrationClientForvarder(NewClientFormViewModel model)
        {

            var password = model.Password;
            var replayPassword = model.RepeatPassword;

            if (string.Compare(password, replayPassword) != 0)
            {
                throw new Exception("Walidacja sie nie udala");
            }

            //TODO nip walidacja

        }

        public void SaveClientForvarder(NewClientFormViewModel viewModel)
        {
            //VM -> Model
            Client principal = new Client();
            Login loginObject = new Login();

            principal.CompanyName = viewModel.CompanyName;
            principal.Country = viewModel.Country;
            principal.PostCode = viewModel.PostCode;
            principal.City = viewModel.City;
            principal.Street = viewModel.Street;
            principal.NumberOfBuilding = viewModel.NumerOfBuilding;
            principal.NumberApartment = viewModel.NumberApartment;
            principal.NIP = viewModel.NIP;
            principal.Email = viewModel.Email;
            principal.Phone = viewModel.Phone;
            principal.Fax = viewModel.Fax;
            principal.FirstNameContact = viewModel.FirstNameContact;
            principal.LastNameContact = viewModel.LastNameContact;
            principal.PhoneContact = viewModel.PhoneContact;
            principal.EmailContact = viewModel.EmailContact;

            loginObject.Login1 = viewModel.Login;

            loginObject.Password = SHAHelper.GenerateSHA512(viewModel.Password);
            principal.Login = loginObject;

            //Wywolanie metody z dao ktora zapisze dane 
            new RegistrationDao().Save(principal);
        }

    }
}