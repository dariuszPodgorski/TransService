using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransServiceWebApp.ViewModel
{
    public class NewEmployeeFormOfficeViewModel
    {
        [Display(Name ="Imię")]
        [Required]
        public string FirstName { get; set; }
        
        
        [Display(Name ="Nazwisko")]
        [Required]
        public string LastName { get; set; }

        [Display(Name ="Data urodzenia")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name ="Kraj")]
        [Required]
        public string Country { get; set; }

        [Display(Name ="Miejscowość")]
        [Required]
        public string City { get; set; }

        [Display(Name ="Ulica")]
        [Required]
        public string Street { get; set; }

        [Display(Name ="Nr budynku")]
        [Required]
        public string NumberOfBuilding { get; set; }

        [Display(Name ="Nr lokalu")]
        public string NumberApartment { get; set; }

        [Display(Name ="Telefon")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Display(Name ="Stanowisko")]
        [Required]
        public int EmployeType { get; set; }

        public SelectList EmployeeList { get; set; }

        [Display(Name ="Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name ="Hasło")]
        [Required]
        public string Password { get; set; }

        [Display(Name ="Powtórz hasło")]
        public string ChangePassword { get; set; }


    }
}