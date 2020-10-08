using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class ProfileService
    {
        /*
        * 
        * DANE KLIENTA NA STRONIE INEDEX
        * 
        */

        internal ShowDetailsIndexViewModel GetClientName(int loginId)
        {
            var model = new ProfilDao().GetClient(loginId);

            var result = new ShowDetailsIndexViewModel()
            {
                Name = model.CompanyName,
            };
            return result;
        }


        /*
         * 
         * PROFIL ZALOGOWANEGO KLIENTA
         * 
         */

        internal ShowDetailsProfileClientViewModel GetClientProfile(int loginId)
        {
            var model = new ClientDao().GetClient(loginId);

            var result = new ShowDetailsProfileClientViewModel()
            {

                CompanyName = model.CompanyName,
                Country = model.Country,
                PostCode = model.PostCode,
                City = model.City,
                Adres = model.Street + model.NumberOfBuilding,
                NumberApartment = model.NumberApartment,
                NIP = model.NIP,
                Phone = model.Phone,
                Fax = model.Fax,
                FirstNameContact = model.FirstNameContact,
                LastNameContact = model.LastNameContact,
                PhoneContact = model.PhoneContact,
                EmailContact = model.EmailContact
            };
            return result;
        }


        /*
         * 
         * 
         * EDYCJA DANYCH PROFILU KLIENTA
         * 
         */

        internal EditProfileClientFormViewModel GetClientProfileToEdit(int loginId)
        {
            var model = new ClientDao().GetClient(loginId);

            var result = new EditProfileClientFormViewModel()
            {
                CompanyName = model.CompanyName,
                Country = model.Country,
                PostCode = model.PostCode,
                City = model.City,
                Street = model.Street,
                NumerOfBuilding = model.NumberOfBuilding,
                NumberApartment = model.NumberApartment,
                NIP = model.NIP,
                Email = model.Email,
                Phone = model.Phone,
                Fax = model.Fax,
                FirstNameContact = model.FirstNameContact,
                LastNameContact = model.LastNameContact,
                PhoneContact = model.PhoneContact,
                EmailContact = model.EmailContact,


            };
            return result;
        }


        internal EditProfileEmployeeViewModel GetEmployeeProfileToEdit(int loginId)
        {
            var model = new EmployeeDao().GetEmployee(loginId);

            var result = new EditProfileEmployeeViewModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Country = model.Country,
                City = model.City,
                Street = model.Street,
                NumberOfBuilding = model.NumberBuilding,
                NumberApartment = model.NumberApartment,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
               
            };
            return result;
        }





        /*
         * 
         * DANE PRACOWNIKA NA STRONIE INEDEX
         * 
         */

        internal ShowDetailsIndexEmployeeViewModel GetEmployeeName(int loginId)
        {
            var model = new ProfilDao().GetEmployee(loginId);

            var result = new ShowDetailsIndexEmployeeViewModel()
            {
                Name = model.FirstName,
                LastName = model.LastName,
            };
            return result;
        }


        /*
         * 
         * PROFIL ZALOGOWANEGO PRACOWNIKA
         * 
         */

        internal ShowDetailsProfileEmployeeViewModel GetEmployeeProfile(int loginId)
        {
            var model = new ProfilDao().GetEmployee(loginId);

            var result = new ShowDetailsProfileEmployeeViewModel()
            {
                NameAndLastName = model.FirstName + " " + model.LastName,
                DateOfBirth = model.DateOfBirth,
                Country = model.Country,
                City = model.City,
                Adress = model.Street + " " + model.NumberBuilding + " / " + model.NumberApartment,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,


            };
            return result;
        }


        internal void Edit(EditProfileEmployeeViewModel model)
        {
            var employeeDao = new EmployeeDao();
            var modelDb = employeeDao.GetEmployee(new SessionContext().GetLoginId());

            modelDb.FirstName = model.FirstName;
            modelDb.LastName = model.LastName;
            modelDb.Country = model.Country;
            modelDb.City = model.City;
            modelDb.Street = model.Street;
            modelDb.NumberBuilding = model.NumberOfBuilding;
            modelDb.NumberApartment = model.NumberApartment;
            modelDb.PhoneNumber = model.PhoneNumber;
            modelDb.Email = model.Email;

            
            employeeDao.Update(modelDb);


        }


    }
}