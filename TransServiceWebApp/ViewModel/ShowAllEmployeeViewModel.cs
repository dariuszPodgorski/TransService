using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowAllEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Kontakt")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Stanowisko")]
        public string EmployeeType { get; set; }
    }
}