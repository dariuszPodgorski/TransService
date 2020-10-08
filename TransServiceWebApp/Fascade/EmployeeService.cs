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
    public class EmployeeService
    {
        internal List<ShowAllEmployeeViewModel> GetAllEmployee()
        {
            //1
            List<Employee> employeeList = new EmployeeDao().GetAllEmployee();
            List<ShowAllEmployeeViewModel> result = new List<ShowAllEmployeeViewModel>();

            //2
            foreach (var employeeAll in employeeList)
            {
                var model = new ShowAllEmployeeViewModel();

                model.FirstName = employeeAll.FirstName;
                model.LastName = employeeAll.LastName;
                model.PhoneNumber = employeeAll.PhoneNumber;
                model.EmployeeType = employeeAll.EmployeeType.Name;


                result.Add(model);
            }

            //3
            return result;
        }

        public List<EmployeeViewModel> GetAllEmployeeList()
        {
            var model = new EmployeeDao().GetAll();
            var result = new List<EmployeeViewModel>();
            foreach (var item in model)
            {
                result.Add(new EmployeeViewModel()
                {
                    Id = item.IdEmployeeType,
                    Name = item.Name,
                });
            }
            return result;
        }


        public void SaveNewEmployee(NewEmployeeFormOfficeViewModel viewModel)
        {
            //VM -> Model
            Employee employee = new Employee();
            Login loginObject = new Login();

            employee.FirstName = viewModel.FirstName;
            employee.LastName = viewModel.LastName;
            employee.DateOfBirth = viewModel.DateOfBirth;
            employee.Country = viewModel.Country;
            employee.City = viewModel.City;
            employee.Street = viewModel.Street;
            employee.NumberBuilding = viewModel.NumberOfBuilding;
            employee.NumberApartment = viewModel.NumberApartment;
            employee.PhoneNumber = viewModel.PhoneNumber;
            employee.Email = viewModel.Email;
            employee.IdEmployeeType = viewModel.EmployeType;
            loginObject.Login1 = viewModel.Login;

            loginObject.Password = SHAHelper.GenerateSHA512(viewModel.Password);
            employee.Login = loginObject;
            
            //Wywolanie metody z dao ktora zapisze dane 
            new EmployeeDao().Save(employee);
        }

        internal void ValidateNewEmployee(NewEmployeeFormOfficeViewModel model)
        {
      
        }



        public ShowAllDetailsEmployeViewModel GetDetailsEmployee(int employeeId)
        {
            var model = new EmployeeDao().GetEmployeeDetails(employeeId);

            var result = new ShowAllDetailsEmployeViewModel()
            {
                EmployeId = model.IdEmployee,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Country = model.Country,
                City = model.City,
                Adres = model.Street + " " + model.NumberBuilding + "/" + model.NumberApartment,
                Phone = model.PhoneNumber,
                Email = model.Email,
                Indentyficator = model.IndentyficatorEmployee,
                Login = model.Login.Login1,

                


            };
            return result;
        }

       
    }
}
