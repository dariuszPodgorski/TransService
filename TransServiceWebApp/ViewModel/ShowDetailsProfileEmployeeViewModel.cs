using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class ShowDetailsProfileEmployeeViewModel
    {

        public int OrderId { get; set; }
        [Display(Name = "Imię i Nazwisko")]
        public string NameAndLastName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Kraj")]
        public string Country { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Display(Name = "Adres")]
        public string Adress { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}