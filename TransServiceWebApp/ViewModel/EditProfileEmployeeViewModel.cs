using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransServiceWebApp.ViewModel
{
    public class EditProfileEmployeeViewModel
    {
        [Display(Name = "Imię")]
        [Required]
        public string FirstName { get; set; }


        [Display(Name = "Nazwisko")]
        [Required]
        public string LastName { get; set; }

        

        [Display(Name = "Kraj")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Miejscowość")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        [Required]
        public string Street { get; set; }

        [Display(Name = "Nr budynku")]
        [Required]
        public string NumberOfBuilding { get; set; }

        [Display(Name = "Nr lokalu")]
        public string NumberApartment { get; set; }

        [Display(Name = "Telefon")]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }


        public int IdEmployee { get; set; }

        public int IdLogin { get; set; }
    }
}